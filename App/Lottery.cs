using System;
using System.Diagnostics;

namespace App
{
    public class Lottery : Scheduler, IScheduler
    {
        private const int TIMEQ = 50;
        
        /// <summary>
        /// Run the Lottery scheduler on the data
        /// </summary>
        /// <param name="testData"></param>
        /// <returns>Average turnaround time</returns>
        public int Run(string testData)
        {
            ReadTestData(testData);
            
            Random random = new Random();
            int randNum;
            // Do lottery
            while (ProcessQueue.Count > 0)
            {
                randNum = random.Next(0, _calcTotalPriority());

                bool winner = false;
                for (int i = 0; !winner; i++)
                {
                    randNum -= ((Process) ProcessQueue[i]).Priority;
                    if (randNum <= 0)
                    {
                        // Check burst
                        Process tempProcess = (Process) ProcessQueue[i];
                        
                        CSVProcess csvProc = new CSVProcess
                        {
                            Pid   = tempProcess.Pid,
                            CPUTime = CPUTime,
                            StartBurstTime = tempProcess.BurstTime,
                        };
                        
                        tempProcess.BurstTime -= TIMEQ;
                        if (tempProcess.BurstTime <= 0)
                        {
                            csvProc.EndBurstTime = 0;
                            csvProc.Complete = true;
                            CPUTime += tempProcess.BurstTime + TIMEQ;
                            TotalTurnAroundTime += CPUTime;
                            ProcessQueue.RemoveAt(i);
                        }
                        else
                        {
                            csvProc.EndBurstTime = tempProcess.BurstTime;
                            csvProc.Complete = false;
                            CPUTime += TIMEQ;
                            ProcessQueue[i] = tempProcess;
                        }
                        CsvProcesses.Add(csvProc);
                        winner = true;
                    }
                    CPUTime += SwitchTime;
                }
            }
            return GetAvgTurnAroundTime();
        }

        /// <summary>
        /// Calculate the total priority by adding all of the priorities from ProcessQueue
        /// </summary>
        private int _calcTotalPriority()
        {
            int TotalPriority = 0;

            foreach (Process process in ProcessQueue)
            {
                TotalPriority += process.Priority;
            }
            return TotalPriority;
        }
    }
}
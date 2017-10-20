using System;
using System.Diagnostics;

namespace App
{
    public class RoundRobin : Scheduler, IScheduler
    {
        private int _timeQ;

        public RoundRobin(int timeQ)
        {
            _timeQ = timeQ;
        }

        /// <summary>
        /// Run the Round Robin scheduler on the data with specified time quantum
        /// </summary>
        /// <param name="testData"></param>
        /// <returns>Average turnaround time</returns>
        public int Run(string testData)
        {
            ReadTestData(testData);

            // Loop till all elements removed from ArrayList
            while (ProcessQueue.Count > 0)
            {
                // Round Robin subtracting
                for (int i = 0; i < ProcessQueue.Count; i++)
                {
                    Process proc = (Process)ProcessQueue[i];
                    int burst = proc.BurstTime;
                    proc.BurstTime = burst - _timeQ;
                    ProcessQueue[i] = proc;                    
                    
                    CSVProcess csvProc = new CSVProcess
                    {
                        Pid = proc.Pid,
                        CPUTime = CPUTime,
                        StartBurstTime = burst,
                    };
                    
                    if (proc.BurstTime <= 0)
                    {
                        ProcessQueue.RemoveAt(i);
                        CPUTime += _timeQ - burst;
                        TotalTurnAroundTime += CPUTime;
                        i--;
                    }
                    else
                    {
                        CPUTime += _timeQ;
                    }
                    
                    CsvProcesses.Add(_completeCSVProcess(csvProc, proc.BurstTime));
                    CPUTime += SwitchTime;
                }
            }
            
            // Remove last CPU time for switch since not necessary
            CPUTime -= SwitchTime;

            return GetAvgTurnAroundTime();
        }

        private static CSVProcess _completeCSVProcess(CSVProcess csvProc, int burstTime)
        {
            if (burstTime <= 0)
            {
                csvProc.EndBurstTime = 0;
                csvProc.Complete = true;
            }
            else
            {
                csvProc.EndBurstTime = burstTime;
                csvProc.Complete = false;
            }
            return csvProc;
        }
        
    }
}
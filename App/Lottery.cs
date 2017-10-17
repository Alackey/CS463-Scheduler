using System;
using System.Diagnostics;

namespace App
{
    public class Lottery : Scheduler, IScheduler
    {
        private int _totalPriority;
        
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
                _calcTotalPriority();
                randNum = random.Next(0, _totalPriority);

                bool winner = false;
                for (int i = 0; !winner || i < ProcessQueue.Count; i++)
                {
                    randNum -= ((Process) ProcessQueue[i]).BurstTime;
                    if (randNum <= 0)
                    {
                        CPUTime += ((Process) ProcessQueue[i]).BurstTime;
                        TotalTurnAroundTime += CPUTime;
                        ProcessQueue.RemoveAt(i);
                        winner = true;
                    }
                    
                    // Switch time
                    if (i != ProcessQueue.Count)
                    {
                        CPUTime += SwitchTime;
                    }
                }
            }
            return GetAvgTurnAroundTime();
        }

        /// <summary>
        /// Calculate the total priority by adding all of the priorities from ProcessQueue
        /// </summary>
        private void _calcTotalPriority()
        {
            _totalPriority = 0;

            foreach (Process process in ProcessQueue)
            {
                _totalPriority += process.Priority;
            }
        }
    }
}
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

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

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
                    
                    if (proc.BurstTime <= 0)
                    {
                        ProcessQueue.RemoveAt(i);
                        TurnAroundTime += _timeQ - burst + SwitchTime;
                    }
                    else
                    {
                        TurnAroundTime += _timeQ + SwitchTime;
                    }
                }
            }
            
            // Remove last CPU time for switch since not necessary
            TurnAroundTime -= SwitchTime;
            
            stopWatch.Stop();
            Console.WriteLine($"Time Elapsed: {stopWatch.Elapsed.TotalMilliseconds}ms");
            
            return GetAvgTurnAroundTime();
        }
        
    }
}
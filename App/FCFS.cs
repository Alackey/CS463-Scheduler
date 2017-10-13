using System;
using System.Diagnostics;

namespace App
{
    public class FCFS : Scheduler, IScheduler
    {

        /// <summary>
        /// Run the First-Come First-Serve scheduler on the data
        /// </summary>
        /// <param name="testData"></param>
        /// <returns>Average turnaround time</returns>
        public int Run(string testData)
        {
            ReadTestData(testData);
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            AddBurstTimes();
            
            stopWatch.Stop();
            Console.WriteLine($"Time Elapsed: {stopWatch.Elapsed.TotalMilliseconds}ms");
            
            return GetAvgTurnAroundTime();
        }
        
    }
}
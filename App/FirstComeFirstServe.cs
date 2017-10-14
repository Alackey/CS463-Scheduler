using System;
using System.Diagnostics;

namespace App
{
    public class FirstComeCirstServe : Scheduler, IScheduler
    {

        /// <summary>
        /// Run the First-Come First-Serve scheduler on the data
        /// </summary>
        /// <param name="testData"></param>
        /// <returns>Average turnaround time</returns>
        public int Run(string testData)
        {
            ReadTestData(testData);
            
            // Call once before everything so the method is compiled by JIT and then cached. 
            // First call is longer that subsequent calls
            AddBurstTimes();
            TurnAroundTime = 0;
            // End first method call.

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            AddBurstTimes();
            
            stopWatch.Stop();
            Console.WriteLine($"Time Elapsed: {stopWatch.Elapsed.TotalMilliseconds}ms");
            
            return GetAvgTurnAroundTime();
        }
        
    }
}
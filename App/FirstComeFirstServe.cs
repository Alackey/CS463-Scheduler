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
            AddBurstTimes();
            
            return GetAvgTurnAroundTime();
        }
        
    }
}
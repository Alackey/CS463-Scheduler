using System;
using System.Collections;
using System.Diagnostics;

namespace App
{
    public class ShortestJobFirst : Scheduler, IScheduler
    {
        /// <summary>
        /// Run the Shortest Job First scheduler on the data
        /// </summary>
        /// <param name="testData"></param>
        /// <returns>Average turnaround time</returns>
        public int Run(string testData)
        {
            ReadTestData(testData);
            ProcessQueue.Sort(new SmallestBurstTime());
            AddBurstTimes();

            return GetAvgTurnAroundTime();
        }
        
        public class SmallestBurstTime : IComparer  {
            int IComparer.Compare( object x, object y )
            {
                // Explanation of whats the single return statement is doing
//                int result;
//                int difference = ((Process) x).BurstTime - ((Process) y).BurstTime;

//                if (difference < 0)
//                {
//                    result = -1;
//                }
//                else if (difference > 0)
//                {
//                    result = 1;
//                }
//                else
//                {
//                    result = 0;
//                }
//                return result;
                
                return ((Process) x).BurstTime - ((Process) y).BurstTime;
            }

        }
    }
}
using System;
using System.Collections;
using System.Diagnostics;

namespace App
{
    public class SJS : Scheduler, IScheduler
    {
        public int Run(string testData)
        {
            ReadTestData(testData);
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            ProcessQueue.Sort(new SmallestBurstTime());
            AddBurstTimes();
            
            stopWatch.Stop();
            Console.WriteLine($"Time Elapsed: {stopWatch.Elapsed.TotalMilliseconds}ms");
            
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
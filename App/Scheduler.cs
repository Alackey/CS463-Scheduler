using System;
using System.Collections;

namespace App
{
    public class Scheduler
    {
        protected const int SwitchTime = 3;
        protected int TurnAroundTime { get; set; }
        protected ArrayList ProcessQueue { get; set; }
        
        protected Scheduler()
        {
        }

        /// <summary>
        /// Reads the file with the processes and put them in a queue
        /// </summary>
        /// <param name="testData"></param>
        protected void ReadTestData(string testData)
        {
            TurnAroundTime = 0;
            ProcessQueue = new ArrayList();
            
            string[] lines = System.IO.File.ReadAllLines(testData);

            // Get list of processes
            int count = 0;
            Process currentProc = default(Process);
            foreach (string line in lines)
            {
                switch (count % 3)
                {
                    case 0:
                        // Push process to queue
                        if (!Equals(currentProc, default(Process)))
                        {
                            ProcessQueue.Add(currentProc);
                        }
                        
                        // Create new process
                        currentProc = new Process();
                        currentProc.Pid = Int32.Parse(line);
                        break;
                    case 1:
                        currentProc.BurstTime = Int32.Parse(line);
                        break;
                    case 2:
                        currentProc.Priority = Int32.Parse(line);
                        break;
                }

                count++;
            }
        }

        /// <summary>
        /// Calculates the average TurnAround time
        /// </summary>
        /// <returns>Average turnaround time</returns>
        protected int GetAvgTurnAroundTime()
        {
            return TurnAroundTime / ProcessQueue.Count;
        }

        /// <summary>
        /// Add all of the bursttimes with switch times
        /// </summary>
        protected void AddBurstTimes()
        {
            foreach (Process currProc in ProcessQueue)
            {
                TurnAroundTime += currProc.BurstTime + SwitchTime;
            }
            // Remove last CPU time for switch since not necessary
            TurnAroundTime -= SwitchTime;
        }
    }
    
    
    
    public struct Process
    {
        public int Pid, BurstTime, Priority;

        public override string ToString()
        {
            return $"{Pid} {BurstTime} {Priority}";
        }
    }
}
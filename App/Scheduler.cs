using System;
using System.Collections;
using System.Collections.Generic;

namespace App
{
    public class Scheduler
    {
        protected const int SwitchTime = 3;
        protected int CPUTime { get; set; }
        protected int TotalTurnAroundTime { get; set; }
        protected int QueueLength { get; set; }
        protected ArrayList ProcessQueue { get; set; }
        public List<CSVProcess> CsvProcesses { get; set; }

        /// <summary>
        /// Reads the file with the processes and put them in a queue
        /// </summary>
        /// <param name="testData"></param>
        protected void ReadTestData(string testData)
        {
            CPUTime = 0;
            TotalTurnAroundTime = 0;
            ProcessQueue = new ArrayList();
            CsvProcesses = new List<CSVProcess>();
            
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
            ProcessQueue.Add(currentProc);

            QueueLength = ProcessQueue.Count;
        }

        /// <summary>
        /// Calculates the average TurnAround time
        /// </summary>
        /// <returns>Average turnaround time</returns>
        protected int GetAvgTurnAroundTime()
        {
            Console.WriteLine($"{TotalTurnAroundTime}:{CPUTime}:{QueueLength}");
            return TotalTurnAroundTime / QueueLength;
        }

        /// <summary>
        /// Add all of the bursttimes with switch times
        /// </summary>
        protected void AddBurstTimes()
        {
            foreach (Process currProc in ProcessQueue)
            {
//                Console.WriteLine(currProc.BurstTime);
//                Console.WriteLine("b: " + CPUTime);
                
                CPUTime += currProc.BurstTime;
                TotalTurnAroundTime += CPUTime;

                CSVProcess csvProc = new CSVProcess
                {
                    Pid   = currProc.Pid,
                    CPUTime = CPUTime,
                    StartBurstTime = currProc.BurstTime,
                    EndBurstTime = 0,
                    Complete = true
                };
                CsvProcesses.Add(csvProc);
                
                CPUTime += SwitchTime;
                //Console.WriteLine("a: " + CPUTime);
            }
            // Remove last CPU time for switch since not necessary
            CPUTime -= SwitchTime;
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
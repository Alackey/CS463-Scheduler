using System;
using System.Diagnostics;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstComeCirstServe FCFS = new FirstComeCirstServe();
            ShortestJobFirst SJS = new ShortestJobFirst();
            RoundRobin RR30 = new RoundRobin(30);
            RoundRobin RR60 = new RoundRobin(60);
            
            // TestData1
            Console.WriteLine("TestData1\n");

            Console.WriteLine($"First-Come First-Serve");
            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata1.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Shortest-Job-First");
            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata1.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 30");
            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata1.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 60");
            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata1.txt")}");
            Console.WriteLine();
            
            
        }
    }
}
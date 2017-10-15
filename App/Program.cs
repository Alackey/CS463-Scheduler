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
            Lottery Lottery = new Lottery();
            
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
            Console.WriteLine($"Lottery");
            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata1.txt")}");
            Console.WriteLine();
            
            // TestData2
            Console.WriteLine("TestData2\n");

            Console.WriteLine($"First-Come First-Serve");
            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata2.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Shortest-Job-First");
            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata2.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 30");
            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata2.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 60");
            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata2.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Lottery");
            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata2.txt")}");
            Console.WriteLine();
            
            // TestData3
            Console.WriteLine("TestData3\n");

            Console.WriteLine($"First-Come First-Serve");
            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata3.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Shortest-Job-First");
            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata3.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 30");
            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata3.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 60");
            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata3.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Lottery");
            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata3.txt")}");
            Console.WriteLine();
            
            // TestData4
            Console.WriteLine("TestData4\n");

            Console.WriteLine($"First-Come First-Serve");
            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata4.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Shortest-Job-First");
            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata4.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 30");
            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata4.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Round Robin 60");
            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata4.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Lottery");
            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata4.txt")}");
            Console.WriteLine();
            
            
        }
    }
}
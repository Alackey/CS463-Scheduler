using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            FCFS sFCFS = new FCFS();
            SJS sSJS = new SJS();
            
            // TestData1
            Console.WriteLine("TestData1\n");

            Console.WriteLine($"First-Come First-Serve");
            Console.WriteLine($"Average TurnAround Time: {sFCFS.Run("testdata1.txt")}");
            Console.WriteLine();
            Console.WriteLine($"Shortest-Job-First");
            Console.WriteLine($"Average TurnAround Time: {sSJS.Run("testdata1.txt")}");
            Console.WriteLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CsvHelper;

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
            
//            var records = new List<CSVProcess>
//            {
//                new CSVProcess { Name = "one", Time = 9},
//                new CSVProcess { Name = "two", Time = 4}
//            };
//            
//            csv.WriteRecords( records );
//            csv.WriteHeader<CSVProcess>();
//            csv.NextRecord();
//            csv.WriteComment( "This is a comment. ");
//            csv.WriteField( "field" );
//            csv.NextRecord();
//            csv.WriteField( " " );
//            csv.NextRecord();
//            csv.WriteRecords( records );
//            writer.Close();

            // TestData1
            StreamWriter writer;// = File.CreateText("Result1.csv");
            CsvWriter csv;// = new CsvWriter(writer);
            
            
            Console.WriteLine("TestData1\n");

            // First-Come First-Serve
            Console.WriteLine($"First-Come First-Serve");
            writer = File.CreateText("Result1.csv");
            csv = new CsvWriter(writer);
            csv.WriteComment("First-Come First-Serve");
            csv.NextRecord();

            int avgTAT = FCFS.Run("testdata1.txt"); 
            Console.WriteLine($"Average TurnAround Time: {avgTAT}");
            
            csv.WriteRecords(FCFS.CsvProcesses);
            csv.WriteField( " " );
            csv.NextRecord();
            csv.WriteField( $"Average Turn Around Time: {avgTAT}" );
            csv.NextRecord();
            writer.Flush();
            Console.WriteLine();
            csv.WriteField( " " );
            csv.NextRecord();
            csv.WriteField( " " );
            csv.NextRecord();
            
            // Shortest-Job-First
            Console.WriteLine($"Shortest-Job-First");
            csv.WriteComment("Shortest-Job-First");
            csv.NextRecord();
            csv.WriteHeader<CSVProcess>();
            csv.NextRecord();

            avgTAT = SJS.Run("testdata1.txt"); 
            Console.WriteLine($"Average TurnAround Time: {avgTAT}");
            
            csv.WriteRecords(SJS.CsvProcesses);
            csv.WriteField( " " );
            csv.NextRecord();
            csv.WriteField( $"Average Turn Around Time: {avgTAT}" );
            csv.NextRecord();
            writer.Flush();
            Console.WriteLine();
            csv.WriteField( " " );
            csv.NextRecord();
            csv.WriteField( " " );
            csv.NextRecord();
            
            
//            Console.WriteLine($"Round Robin 30");
//            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata1.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 60");
//            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata1.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Lottery");
//            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata1.txt")}");
//            Console.WriteLine();

            // TestData2
//            Console.WriteLine("TestData2\n");
//
//            Console.WriteLine($"First-Come First-Serve");
//            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata2.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Shortest-Job-First");
//            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata2.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 30");
//            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata2.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 60");
//            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata2.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Lottery");
//            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata2.txt")}");
//            Console.WriteLine();
//            
//            // TestData3
//            Console.WriteLine("TestData3\n");
//
//            Console.WriteLine($"First-Come First-Serve");
//            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata3.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Shortest-Job-First");
//            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata3.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 30");
//            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata3.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 60");
//            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata3.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Lottery");
//            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata3.txt")}");
//            Console.WriteLine();
//            
//            // TestData4
//            Console.WriteLine("TestData4\n");
//
//            Console.WriteLine($"First-Come First-Serve");
//            Console.WriteLine($"Average TurnAround Time: {FCFS.Run("testdata4.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Shortest-Job-First");
//            Console.WriteLine($"Average TurnAround Time: {SJS.Run("testdata4.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 30");
//            Console.WriteLine($"Average TurnAround Time: {RR30.Run("testdata4.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Round Robin 60");
//            Console.WriteLine($"Average TurnAround Time: {RR60.Run("testdata4.txt")}");
//            Console.WriteLine();
//            Console.WriteLine($"Lottery");
//            Console.WriteLine($"Average TurnAround Time: {Lottery.Run("testdata4.txt")}");
//            Console.WriteLine();


        }
    }
}
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
            const string READ_FILE1 = "testdata1.txt";
            const string READ_FILE2 = "testdata2.txt";
            const string READ_FILE3 = "testdata3.txt";
            const string READ_FILE4 = "testdata4.txt";
           
            FirstComeCirstServe FCFS = new FirstComeCirstServe();
            ShortestJobFirst SJF = new ShortestJobFirst();
            RoundRobin RR30 = new RoundRobin(30);
            RoundRobin RR60 = new RoundRobin(60);
            Lottery LOT = new Lottery();
            StreamWriter writer;
            CsvWriter csv;
            
            
            /*
             *
             * Test Data 1
             * 
             */
            
            Console.WriteLine("TestData1\n");

            writer = File.CreateText("Result1.csv");
            csv = new CsvWriter(writer);
            
            // First-Come First-Serve
            _FCFSInit(READ_FILE1, FCFS, csv, writer);
            
            // Shortest-Job-First
            _SJFInit(READ_FILE1, SJF, csv, writer);
            
            // Round Robin 30
            _RR30Init(READ_FILE1, RR30, csv, writer);

            // Round Robin 60
            _RR60Init(READ_FILE1, RR60, csv, writer);

            // Lottery
            _LotteryInit(READ_FILE1, LOT, csv, writer);
            
            
            /*
             *
             * Test Data 2
             * 
             */
            
            Console.WriteLine("TestData2\n");

            writer = File.CreateText("Result2.csv");
            csv = new CsvWriter(writer);
            
            // First-Come First-Serve
            _FCFSInit(READ_FILE2, FCFS, csv, writer);
            
            // Shortest-Job-First
            _SJFInit(READ_FILE2, SJF, csv, writer);
            
            // Round Robin 30
            _RR30Init(READ_FILE2, RR30, csv, writer);

            // Round Robin 60
            _RR60Init(READ_FILE2, RR60, csv, writer);

            // Lottery
            _LotteryInit(READ_FILE2, LOT, csv, writer);
            
            
            /*
             *
             * Test Data 3
             * 
             */
            
            Console.WriteLine("TestData3\n");

            writer = File.CreateText("Result3.csv");
            csv = new CsvWriter(writer);
            
            // First-Come First-Serve
            _FCFSInit(READ_FILE3, FCFS, csv, writer);
            
            // Shortest-Job-First
            _SJFInit(READ_FILE3, SJF, csv, writer);
            
            // Round Robin 30
            _RR30Init(READ_FILE3, RR30, csv, writer);

            // Round Robin 60
            _RR60Init(READ_FILE3, RR60, csv, writer);

            // Lottery
            _LotteryInit(READ_FILE3, LOT, csv, writer);
            
            
            /*
             *
             * Test Data 4
             * 
             */
            
            Console.WriteLine("TestData4\n");

            writer = File.CreateText("Result4.csv");
            csv = new CsvWriter(writer);
            
            // First-Come First-Serve
            _FCFSInit(READ_FILE4, FCFS, csv, writer);
            
            // Shortest-Job-First
            _SJFInit(READ_FILE4, SJF, csv, writer);
            
            // Round Robin 30
            _RR30Init(READ_FILE4, RR30, csv, writer);

            // Round Robin 60
            _RR60Init(READ_FILE4, RR60, csv, writer);

            // Lottery
            _LotteryInit(READ_FILE4, LOT, csv, writer);
            
        }

        private static void _FCFSInit(string readFile, FirstComeCirstServe FCFS, CsvWriter csv, StreamWriter writer)
        {
            Console.WriteLine($"First-Come First-Serve");
            
            csv.WriteComment("First-Come First-Serve");
            csv.NextRecord();

            int avgTAT = FCFS.Run(readFile); 
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
        }
        
        
        private static void _SJFInit(string readFile, ShortestJobFirst SJF, CsvWriter csv, StreamWriter writer)
        {
            Console.WriteLine($"Shortest-Job-First");
            
            csv.WriteComment("Shortest-Job-First");
            csv.NextRecord();
            csv.WriteHeader<CSVProcess>();
            csv.NextRecord();

            int avgTAT = SJF.Run(readFile); 
            Console.WriteLine($"Average TurnAround Time: {avgTAT}");
            
            csv.WriteRecords(SJF.CsvProcesses);
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
        }
        
        private static void _RR30Init(string readFile, RoundRobin RR30, CsvWriter csv, StreamWriter writer)
        {
            Console.WriteLine($"Round Robin 30");
            csv.WriteComment("Round Robin 30");
            csv.NextRecord();
            csv.WriteHeader<CSVProcess>();
            csv.NextRecord();

            int avgTAT = RR30.Run(readFile); 
            Console.WriteLine($"Average TurnAround Time: {avgTAT}");
            
            csv.WriteRecords(RR30.CsvProcesses);
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
        }
        
        private static void _RR60Init(string readFile, RoundRobin RR60, CsvWriter csv, StreamWriter writer)
        {
            Console.WriteLine($"Round Robin 60");
            csv.WriteComment("Round Robin 60");
            csv.NextRecord();
            csv.WriteHeader<CSVProcess>();
            csv.NextRecord();

            int avgTAT = RR60.Run(readFile); 
            Console.WriteLine($"Average TurnAround Time: {avgTAT}");
            
            csv.WriteRecords(RR60.CsvProcesses);
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
        }
        
        private static void _LotteryInit(string readFile, Lottery LOT, CsvWriter csv, StreamWriter writer)
        {
            Console.WriteLine("Lottery");
            csv.WriteComment("Lottery");
            csv.NextRecord();
            csv.WriteHeader<CSVProcess>();
            csv.NextRecord();

            int avgTAT = LOT.Run(readFile); 
            Console.WriteLine($"Average TurnAround Time: {avgTAT}");
            
            csv.WriteRecords(LOT.CsvProcesses);
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
        }
        
        
    }
}
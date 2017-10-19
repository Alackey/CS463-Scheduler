namespace App
{
    public class CSVProcess
    {
        public int Pid { get; set; }
        public int CPUTime { get; set; }
        public int StartBurstTime { get; set; }
        public int EndBurstTime { get; set; }
        public bool Complete { get; set; }
    }
}
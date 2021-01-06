using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace PointsApp
{
    class Program
    {
        public delegate void ProcessFinished(int id);
        public static event ProcessFinished Message;
        static void Main(string[] args)
        {
            ProcessMonitor processMonitor = new ProcessMonitor();
            Message += processMonitor.GetNoticeForEvent;
            CalculationPoints parseFile = new CalculationPoints();
            var result = parseFile.RunTaskForCalculation();

            while (!result.IsCompleted)
            {
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now + " - In Progress....");
            }

            if (result.Result.Any())
            {
                Message?.Invoke(result.Result.Last().id);
            }
        }
    }
}

using System;
using System.Threading;

namespace PointsApp
{
    class ProcessMonitor
    {
        public void GetNoticeForEvent(int id)
        {
            try
            {
                Console.WriteLine($"File was written successfully! \nID of last point: {id}" +
                                  $" \nAutomatically exit 10 seconds");
                Console.WriteLine("");
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }
    }
}

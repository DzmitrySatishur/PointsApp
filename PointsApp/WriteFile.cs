using System;
using System.Collections.Generic;
using System.IO;

namespace PointsApp
{
    class WriteFile
    {
        public void WriteToTextFile(int countOfPoints, List <Point> source)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(@"D:\AppPointsResult.txt", false, System.Text.Encoding.Default);
                writer.WriteLine("Count of Point: " + $"{countOfPoints};");
                writer.WriteLine("Most distant points from Null:");
                foreach (var p in source)
                {
                    writer.WriteLine($"ID ={p.id}: X = {p.coordinateX}, Y = {p.coordinateY};");
                }
            }
            catch (IOException ex) { Console.WriteLine(ex); throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
        }

    }
}

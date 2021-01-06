using System;
using System.IO;

namespace PointsApp
{
    class WriteFile
    {
        public void WriteToTextFile(int countOfPoints, Point point)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(@"D:\AppPointsResult.txt", false, System.Text.Encoding.Default);
                writer.WriteLine("Count of Point: " + $"{countOfPoints};");
                writer.WriteLine("Most distant from Null: " + $" ID = {point.id}: " +
                                      $"X = {point.coordinateX},Y = {point.coordinateY};");
            }
            catch (IOException ex) { Console.WriteLine(ex); throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
        }
    }
}

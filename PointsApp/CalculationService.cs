using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsApp
{
    class CalculationService : CalculationServiceBase, ICalculationService
    {
        public bool GetResultOfIncorrectMultiply(long x, long y)
        {
            try
            {
                return x * y == Math.Abs(666);
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }

        public bool GetResultOfIncorrectDivision(long x, long y)
        {
            try
            {
                return x / y == Math.Abs(13) || y / x == Math.Abs(13);
            }
            catch (DivideByZeroException) { return false; throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }

        public List<Point> GetPointMostDistantFromNull(List<Point> source)
        {
            try
            {
                List<Point> tempList = new List<Point>();
                Point tempPoint = source.First();
                
                foreach (var point in source)
                {
                    if (Math.Abs((Math.Sqrt((Math.Pow((0 - point.coordinateX), 2)))
                        + (Math.Pow((0 - point.coordinateY), 2)))) > Math.Abs((Math.Sqrt(
                            ((Math.Pow((0 - tempPoint.coordinateX), 2))) + (Math.Pow((0 - tempPoint.coordinateY), 2))))))
                    {
                        tempPoint.id = point.id;
                        tempPoint.coordinateX = point.coordinateX;
                        tempPoint.coordinateY = point.coordinateY;
                    }
                }

                foreach (var p in source)
                {
                    if (tempPoint.coordinateX == p.coordinateX && tempPoint.coordinateY == p.coordinateY)
                    {
                        tempList.Add(p);
                    }
                }
                return tempList;
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
            catch (InvalidOperationException ex) { Console.WriteLine(ex); throw; }
        }


    }
}
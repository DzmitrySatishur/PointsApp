using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsApp
{
    class CalculationService : CalculationServiceBase, ICalculationService
    {
        public bool GetResultOfIncorrectMultiply(int x, int y)
        {
            try
            {
                return x * y == Math.Abs(666);
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }

        public bool GetResultOfIncorrectDivision(int x, int y)
        {
            try
            {
                return x / y == Math.Abs(13) || y / x == Math.Abs(13);
            }
            catch (DivideByZeroException) { return false; throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }

        public Point GetPointMostDistantFromNull(List<Point> source)
        {
            try
            {
                Point maxPoint = source.First();
                foreach (var point in source)
                {
                    if (point.coordinateX > maxPoint.coordinateX && point.coordinateY > maxPoint.coordinateY)
                    {
                        maxPoint.coordinateX = point.coordinateX;
                        maxPoint.coordinateY = point.coordinateY;
                    }
                }
                return maxPoint;
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
            catch (InvalidOperationException ex) { Console.WriteLine(ex); throw; }
        }
    }
}
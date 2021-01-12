using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsApp
{
    class CalculationService : CalculationServiceBase
    {
        public override IEnumerable<Point> Filter(IEnumerable<Point> source)
        {
            var result = base.Filter(source);
            return result.Where(p => p.coordinateX * p.coordinateY != 666
                                     || p.coordinateX / p.coordinateY != 13 || p.coordinateY / p.coordinateX != 13);

        }

        public List<Point> GetPointMostDistantFromNull(List<Point> source)
        {
            try
            {
                var tempList = new List<Point>();
                var tempPoint = source.First();

                foreach (var point in source.Where(point => Math.Sqrt((Math.Pow((0 - point.coordinateX), 2)))
                    + (Math.Pow((0 - point.coordinateY), 2)) > (Math.Sqrt(
                        ((Math.Pow((0 - tempPoint.coordinateX), 2))) + (Math.Pow((0 - tempPoint.coordinateY), 2))))))
                {
                    tempPoint.id = point.id;
                    tempPoint.coordinateX = point.coordinateX;
                    tempPoint.coordinateY = point.coordinateY;
                }
                
                tempList.Add(tempPoint);
                tempList.AddRange(source.Where(p => tempPoint.coordinateX == p.coordinateX 
                                                    && tempPoint.coordinateY == p.coordinateY && tempPoint.id != p.id));
                return tempList;
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
            catch (InvalidOperationException ex) { Console.WriteLine(ex); throw; }
        }
    }
}
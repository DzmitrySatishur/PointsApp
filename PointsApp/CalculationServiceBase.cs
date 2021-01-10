using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace PointsApp
{
    class CalculationServiceBase
    {
        public List<Point> GetNegativePoints(List<Point> source)
        {
            try
            {
                return (List<Point>) source.Where(p => p.coordinateX < 0 || p.coordinateY < 0).ToList();
            }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }

        public IEnumerable<TSource> SkipPointsInList<TSource>(IEnumerable<TSource> source)
        {
            try
            {
                return source.Skip(5).SkipLast(10);
            }
            catch (InvalidOperationException ex) { Console.WriteLine(ex); throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsApp
{
    class CalculationServiceBase
    {
        public bool CheckNegtativePoint(List<Point> source)
        {
            try
            {
                return source.Any(p => p.coordinateX < 0 || p.coordinateY < 0);
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

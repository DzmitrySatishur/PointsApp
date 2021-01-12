using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsApp
{
    class CalculationServiceBase : ICalculationService
    {
        public virtual IEnumerable<Point> Filter(IEnumerable<Point> source)
        {
            try
            {
                var result = source.Skip(5).SkipLast(10);
                return (IEnumerable<Point>) result.Where(p => (p.coordinateX < 0 || p.coordinateY < 0));
            }
            catch (InvalidOperationException ex) { Console.WriteLine(ex); throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
            catch (FormatException ex) { Console.WriteLine(ex); throw; }
        }
    };
}

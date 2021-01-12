using System.Collections.Generic;

namespace PointsApp
{
    interface ICalculationService
    {
        IEnumerable<Point> Filter(IEnumerable<Point> source);
    }
}

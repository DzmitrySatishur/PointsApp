using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace PointsApp
{
    class ReadFile
    {
        public List<Point> GetListFromFile(string filePath)
        {
            try
            {
                XDocument xDocument = XDocument.Load(filePath);
                var points = from p in xDocument.Element("points")?.Elements("point")
                             select new Point
                             {
                                 id = Convert.ToInt64(p.Attribute("id")?.Value),
                                 coordinateX = Convert.ToInt64(p.Element("X")?.Value),
                                 coordinateY = Convert.ToInt64(p.Element("Y")?.Value)
                             };
                return points.ToList();
            }
            catch (XmlException ex) { Console.WriteLine(ex); throw; }
            catch (ArgumentException ex) { Console.WriteLine(ex); throw; }
        }
    }
}

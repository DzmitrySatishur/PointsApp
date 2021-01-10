using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PointsApp
{
    class CalculationPoints
    {
        public Task<List<Point>> RunTaskForCalculation()
        {
            return
            Task.Run(() =>
            {
                Thread.Sleep(2000); //FOR ILLUSTRATION
                CalculationServiceBase calculationServiceBase = new CalculationServiceBase();
                CalculationService calculationService = new CalculationService();
                List<Point> pointsList = new List<Point>();
                Point point = new Point();
                string filePath = @"D:\points.xml";
                ReadFile readFile = new ReadFile();
                var points = readFile.GetListFromFile(filePath);
                var pointsWithSkips = calculationServiceBase.SkipPointsInList(points).ToList();
                
                var negativePoints = calculationServiceBase.GetNegativePoints(pointsWithSkips);
                foreach (var p in negativePoints)
                {
                    if (calculationService.GetResultOfIncorrectMultiply(p.coordinateX, p.coordinateY))
                    {
                        continue;
                    }

                    if (calculationService.GetResultOfIncorrectDivision(p.coordinateX, p.coordinateY))
                    {
                        continue;
                    }
                    pointsList.Add(p);
                    Console.WriteLine($"ID = {p.id}: X = {p.coordinateX}, Y = {p.coordinateY};");
                }

                var mostDistantPoint = calculationService.GetPointMostDistantFromNull(negativePoints);
                WriteFile writeFile = new WriteFile();
                writeFile.WriteToTextFile(pointsList.Count(), mostDistantPoint);
                return pointsList;
            });
        }
    }
}

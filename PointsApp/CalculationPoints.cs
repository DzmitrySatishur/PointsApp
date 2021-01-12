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
            const string filePath = @"D:\points.xml";
            return
            Task.Run(() =>
            {
                Thread.Sleep(2000); //FOR ILLUSTRATION
                var calculationService = new CalculationService();
                var pointsList = new List<Point>();
                var readFile = new ReadFile();
                var points = readFile.GetListFromFile(filePath);
                var filterPoints = calculationService.Filter(points).ToList();
                foreach (var p in filterPoints)
                {
                    pointsList.Add(p);
                    Console.WriteLine($"ID = {p.id}: X = {p.coordinateX}, Y = {p.coordinateY};");
                }

                var mostDistantPoint = calculationService.GetPointMostDistantFromNull(filterPoints).ToList();
                var writeFile = new WriteFile();
                writeFile.WriteToTextFile(pointsList.Count(), mostDistantPoint);
                return pointsList;
            });
        }
    }
}

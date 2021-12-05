using System;
using System.Collections.Generic;
using System.Drawing;

namespace solutions.Five
{
    public class Part1
    {
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Five\input.txt");
            List<Line> lines = new List<Line>();
            int[,] coveredPoints = new int[1000, 1000]; // this is used to check how many lines are covering a certain point 
            foreach (var line in inpLines)
            {
                string[] lineParts = line.Split(" ");
                List<Point> points = new List<Point>();
                for(int i = 0; i < lineParts.Length; i++)
                {
                    if (lineParts[i].Equals("->"))
                    {
                        continue;
                    }
                    else
                    {
                        string[] pointParts = lineParts[i].Split(",");
                        Point p1 = new Point(int.Parse(pointParts[0]), (int.Parse(pointParts[1])));
                        points.Add(p1);
                    }
                }
                // we have two points now hopefully, make a line.
                lines.Add(new Line(points[0],points[1]));
            }
            // now go over all the lines and add them to coveredPoints
            foreach (var line in lines)
            {
                // get the array of points covered by line segment
                if (IsStraight(line))  // if it isn't straight, don't consider it?
                {
                    foreach (var point in GetPointsCovered(line))
                    {
                        // for every point covered by a straight line, add 1
                        coveredPoints[point.X, point.Y] += 1;
                    }
                }
            }
            // now check where at least 2 points overlap
            int dangerousPoints = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    if (coveredPoints[x, y] >= 2)
                    {
                        dangerousPoints++;
                    }
                }
            }
            Console.WriteLine("number of points to watch out for: " + dangerousPoints);
        }

        private static List<Point> GetPointsCovered(Line line)
        {
            // go in y direction
            List<Point> pointsCovered = new List<Point>();
            for (int y = Math.Min(line.start.Y, line.end.Y); y <= Math.Max(line.end.Y, line.start.Y); y++)
            {
                Point p = new Point(line.start.X, y);
                if (!pointsCovered.Contains(p))
                {
                    pointsCovered.Add(p);
                }
            }
            // go in x direction
            for (int x =  Math.Min(line.start.X, line.end.X); x <= Math.Max(line.end.X, line.start.X); x++)
            {
                Point p = new Point(x, line.start.Y);
                if (!pointsCovered.Contains(p))
                {
                    pointsCovered.Add(p);
                }
            }
            //Console.WriteLine("for " + line.ToString() + ", following points covered list size " + pointsCovered.Count);
            return pointsCovered;
        }
        
        // Checks if the line is straight or not.
        private static bool IsStraight(Line line)
        {
            if (line.start.X == line.end.X)
            {
                return true;
            } else if (line.start.Y == line.end.Y)
            {
                return true;
            }

            return false;
        }
    }

    public class Line
    {
        public Point start;
        public Point end;
        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public override string ToString()
        {
            return start + "," + end;
        }
    }
}
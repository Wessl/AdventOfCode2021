using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Nine
{
    public class Part1
    {
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Nine\input.txt");
            int[,] nums = new int[inpLines[0].Length, inpLines.Length];
            for (int y = 0; y < inpLines.Length; y++)
            {
                for (int x = 0; x < inpLines[0].Length; x++)
                {
                    nums[x, y] = int.Parse(inpLines[y][x].ToString());
                }
            }
            // Now, for each number check the surroundings if its a low point
            int riskLevel = 0;
            int maxY = nums.GetLength(1);
            int maxX = nums.GetLength(0);
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    int p1 = y-1 < 0 ? int.MaxValue : nums[x, y-1];
                    int p2 = x+1 >= maxX ? int.MaxValue : nums[x+1, y];
                    int p3 = y+1 >= maxY ? int.MaxValue : nums[x, y+1];
                    int p4 = x-1 < 0 ? int.MaxValue : nums[x-1, y];
                    //Console.WriteLine("Comparing our number, " + nums[x,y] + " to these: " + p1 + " " + p2 + " " + p3 + " " + p4) ;
                    if (nums[x, y] < Math.Min(p1, Math.Min(p2, Math.Min(p3, p4))))
                    {
                        // its a low point, nice
                        Console.WriteLine("low point found: " + nums[x,y]);
                        riskLevel += nums[x, y] + 1;
                    }
                }
            }
            Console.WriteLine("total risk level: " + riskLevel);
        }
    }
}
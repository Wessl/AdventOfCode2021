using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Nine
{
    public class Part2
    {
        private static int[,] nums;
        private static int counter;
        
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Nine\input.txt");
            nums = new int[inpLines[0].Length, inpLines.Length];
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
            List<int> vals = new List<int>();
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    FindBasins(x, y);
                    vals.Add(counter);
                    counter = 0;
                }
            }
            vals = vals.OrderByDescending(c => c).ToList();
            int result = vals[0] * vals[1] * vals[2];
            Console.WriteLine("total basin result: " + result);
        }
        
        static void FindBasins(int x, int y)
        {
            // idea: for each adjacent tile that is less than 9, go to it and recursively find every adjacent tile also less than 9
            // mark used tiles by changing them to a 9
            int maxY = nums.GetLength(1);
            int maxX = nums.GetLength(0);
            int p1 = y-1 < 0 ? int.MaxValue : nums[x, y-1];
            if (p1 < 9)
            {
                nums[x, y - 1] = 9;
                counter++;
                FindBasins(x,y-1);
            }
            int p2 = x+1 >= maxX ? int.MaxValue : nums[x+1, y];
            if (p2 < 9)
            {
                nums[x+1, y] = 9;
                counter++;
                FindBasins(x+1,y);
            }
            int p3 = y+1 >= maxY ? int.MaxValue : nums[x, y+1];
            if (p3 < 9)
            {
                nums[x, y + 1] = 9;
                counter++;
                FindBasins(x,y+1);
            }
            int p4 = x-1 < 0 ? int.MaxValue : nums[x-1, y];
            if (p4 < 9)
            {
                nums[x - 1, y] = 9;
                counter++;
                FindBasins(x-1,y);
            }
        }
        
    }
    
}
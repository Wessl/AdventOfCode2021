using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Seven
{
    public class Part2
    {
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Seven\input.txt");
            List<int> nums = Array.ConvertAll(inpLines[0].Split(","), int.Parse).ToList();
            int goal = (int)Math.Floor((double)nums.Sum()/(double)nums.Count);  // you should try both floor and ceil and pick the lowest result
            int diffSum = 0;
            foreach (var num in nums)
            {
                // triangular number sequence T = (n)(n + 1) / 2
                int n = Math.Abs(num - goal);
                diffSum += (n * (n + 1) / 2);
            }
            Console.WriteLine("The total fuel spent: " + diffSum);
        }
    }
}
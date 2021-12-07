using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Seven
{
    public class Part1
    {
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Seven\input.txt");
            List<int> nums = Array.ConvertAll(inpLines[0].Split(","), int.Parse).ToList();
            nums.Sort();
            int goal = nums[nums.Count / 2];
            int diffSum = 0;
            foreach (var num in nums)
            {
                diffSum += Math.Abs(num - goal);
            }
            Console.WriteLine("The total fuel spent: " + diffSum);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace solutions.Six
{
    public class Part1
    {
        public static void Solve()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Six\input.txt");
            List<int> nums = Array.ConvertAll(inpLines[0].Split(","), int.Parse).ToList();
            for (int i = 0; i < 80; i++)
            {
                List<int> toAdd = new List<int>();
                for (int y = 0; y < nums.Count; y++)
                {
                    int n = nums[y] - 1;
                    if (n == -1)
                    {
                        n = 6;
                        toAdd.Add(8);
                    }
                    nums[y] = n;
                }
                nums.AddRange(toAdd);
                
            }
            
            Console.WriteLine(nums.Count);
        }
    }
}
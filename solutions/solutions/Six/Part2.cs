using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace solutions.Six
{
    public class Part2
    {
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Six\input.txt");
            int[] snums = Array.ConvertAll(inpLines[0].Split(","), int.Parse);
            Dictionary<int, long> nums = new Dictionary<int, long>();
            // populate initial dict
            for (int i = 0; i < 9; i++)
            {
                nums.Add(i,0);
            }
            foreach (var snum in snums)
            {
                nums[snum] = nums[snum] + 1;
            }
            

            for (int i = 0; i < 256; i++)
            {
                Dictionary<int, long> tempNums = new Dictionary<int, long>(nums);
                for (int y = 8; y >= 0; y--)
                {
                    long n = nums[y];
                    if (y == 0)
                    {
                        tempNums[0] -= n;
                        tempNums[8] += n;
                        tempNums[6] += n;
                    }
                    else
                    {
                        tempNums[y] -= n;
                        tempNums[y - 1] += n;
                    }
                }
                nums = tempNums;
            }

            long sum = 0;
            foreach (var num in nums)
            {
                Console.WriteLine(num.Key + ", "  + num.Value);
                sum += num.Value;
            }
            Console.WriteLine(sum);
        }
    }
}
using System;
using System.Collections.Generic;

namespace solutions
{
    class One
    {
        static void Solve()
        {
            // Three measurement sliding window
            string line;
            List<int> numbers = new List<int>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                numbers.Add(int.Parse(line));
            }

            int amountIncreases = -1;
            int prevSum = 0;
            for (int i = 1; i < numbers.Count - 1; i++)
            {
                int currentSum = numbers[i - 1] + numbers[i] + numbers[i + 1];
                if (currentSum > prevSum)
                {
                    amountIncreases++;
                }
                prevSum = currentSum;
            }

            Console.WriteLine(amountIncreases);
        }
    }
}
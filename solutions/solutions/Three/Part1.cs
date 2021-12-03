using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Three
{
    public class Part1
    {
        public static void Solution()
        {
            string line;
            List<string> lines = new List<string>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                lines.Add(line);
            }

            int length = lines.Count;
            char[,] linesArr = new char[lines[0].Length, length];
            Console.WriteLine("linearr dimensions: " + linesArr.GetLength(0) + "," + linesArr.GetLength(1));
            Console.WriteLine("lines dimensions: " + lines.Count + "," + lines[0].Length);
            // transpose
            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //Console.WriteLine("i:" + i + ", j:" + j);
                    linesArr[i, j] = lines[j][i];
                }
            }

            string binaryGamma = "";
            string binaryEpsilon = "";
            // Now we have all the lines, let's go through them
            for (int x = 0; x < linesArr.GetLength(0); x++)
            {
                int sumOne = 0;
                int sumTwo = 1;
                int gamma = -1;
                int epsilon = -1;
                for (int y = 0; y < linesArr.GetLength(1); y++)
                {
                    Console.WriteLine("what is x,y? " + x + "," + y);
                    if (linesArr[x, y] == '1')
                    {
                        sumOne++;
                    }
                    else
                    {
                        sumTwo++;
                    }
                }

                if (sumOne > sumTwo)
                {
                    gamma = 1;
                    epsilon = 0;
                }
                else
                {
                    gamma = 0;
                    epsilon = 1;
                }
                binaryGamma += gamma;
                binaryEpsilon += epsilon;
            }
            Console.WriteLine(binaryGamma);
            Console.WriteLine(binaryEpsilon);
            int sumGamma = Convert.ToInt32(binaryGamma, 2);
            int sumEpsilon = Convert.ToInt32(binaryEpsilon, 2);
            Console.WriteLine("Sum gamma: " + sumGamma);
            Console.WriteLine("Sum epsilon: " + sumEpsilon);
            Console.WriteLine("Multiplication result: " + sumGamma * sumEpsilon);
        }
    }
}
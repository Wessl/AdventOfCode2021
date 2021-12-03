using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace solutions.Three
{
    public class Part2
    {
        private static List<string> lines;
        static char[,] lArr;
        private static int oxygen = 0;
        private static int co2 = 0;
        public static void Main()
        {
            string line;
            lines = new List<string>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                lines.Add(line);
            }
            // Now we have all the lines. First convert lines to char[,] to make it easier to work with
            lArr = new char[lines[0].Length, lines.Count];
            for (int y = 0; y < lArr.GetLength(1); y++)
            {
                for (int x = 0; x < lArr.GetLength(0); x++)
                {
                    lArr[x, y] = lines[y][x];
                }
            }
            // oxygen generator, so find most common value and keep it. if #1 == #0, keep 1.  
            
            int nOfRowsLeft = lArr.GetLength(1);
            for (int x = 0; x < lArr.GetLength(0); x++)
            {
                int sum1 = 0;
                int sum0 = 0;
                for (int y = 0; y < lArr.GetLength(1); y++)
                {
                    if (lArr[x, y] == '1')
                    {
                        sum1++;
                    }
                    else if (lArr[x,y] == '0')
                    {
                        sum0++;
                    }
                }

                if (sum1 == sum0 || sum1 > sum0)
                {
                    // remove 0's
                    for (int y = 0; y < lArr.GetLength(1); y++)
                    {
                        if (lArr[x, y] == '0')
                        {
                            string sb = "";
                            for (int xx = 0; xx < lArr.GetLength(0); xx++)
                            {
                                // invalidate row by setting it to 2 instead
                                lArr[xx, y] = '2';
                                sb += lArr[xx, y];
                            }

                            nOfRowsLeft--;
                            if (nOfRowsLeft == 1)
                            {
                                // nothng left. we done
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // remove 1's
                    for (int y = 0; y < lArr.GetLength(1); y++)
                    {
                        if (lArr[x, y] == '1')
                        {
                            string sb = "";   
                            for (int xx = 0; xx < lArr.GetLength(0); xx++)
                            {
                                // invalidate row by setting it to 2 instead
                                lArr[xx, y] = '2';
                                sb += lArr[xx, y];
                            }
                            nOfRowsLeft--;
                            if (nOfRowsLeft == 1)
                            {
                                // nothing left to remove. we done. 
                                break;
                            }
                        }

                        
                    }
                }

                if (nOfRowsLeft == 1)
                {
                    break;
                }
            }
            // There should only be one row left, let's find it. 
            for (int y = 0; y < lArr.GetLength(1); y++)
            {
                if (lArr[0, y] != '2')
                {
                    string resultOxygenBinary = "";
                    for (int x = 0; x < lArr.GetLength(0); x++)
                    {
                        resultOxygenBinary += lArr[x, y];
                    }
                    Console.WriteLine("Binary found, it was: " + resultOxygenBinary);
                    oxygen = Convert.ToInt32(resultOxygenBinary,2);
                    Console.WriteLine("In int form, that is " + oxygen);
                }
            }
            // now do CO2 scrubber rating
            // reset variables 
            // i know this is extremely shitty code practice and I don't care
            lArr = new char[lines[0].Length, lines.Count];
            for (int y = 0; y < lArr.GetLength(1); y++)
            {
                for (int x = 0; x < lArr.GetLength(0); x++)
                {
                    lArr[x, y] = lines[y][x];
                }
            }
            
            nOfRowsLeft = lArr.GetLength(1);
            for (int x = 0; x < lArr.GetLength(0); x++)
            {
                int sum1 = 0;
                int sum0 = 0;
                for (int y = 0; y < lArr.GetLength(1); y++)
                {
                    if (lArr[x, y] == '1')
                    {
                        sum1++;
                    }
                    else if (lArr[x,y] == '0')
                    {
                        sum0++;
                    }
                }

                if (sum1 == sum0 || sum1 > sum0)
                {
                    // keep 0's since they are least common, so remove 1s
                    for (int y = 0; y < lArr.GetLength(1); y++)
                    {
                        if (lArr[x, y] == '1')
                        {
                            string sb = "";
                            for (int xx = 0; xx < lArr.GetLength(0); xx++)
                            {
                                // invalidate row by setting it to 2 instead
                                lArr[xx, y] = '2';
                                sb += lArr[xx, y];
                            }

                            nOfRowsLeft--;
                            if (nOfRowsLeft == 1)
                            {
                                // nothng left. we done
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // remove 0's
                    for (int y = 0; y < lArr.GetLength(1); y++)
                    {
                        
                        if (lArr[x, y] == '0')
                        {
                            string sb = "";   
                            for (int xx = 0; xx < lArr.GetLength(0); xx++)
                            {
                                // invalidate row by setting it to 2 instead
                                lArr[xx, y] = '2';
                                sb += lArr[xx, y];
                            }
                            nOfRowsLeft--;
                            if (nOfRowsLeft == 1)
                            {
                                // nothing left to remove. we done. 
                                break;
                            }
                        }

                        
                    }
                }

                if (nOfRowsLeft == 1)
                {
                    break;
                }
            }
            // There should only be one row left, let's find it. 
            for (int y = 0; y < lArr.GetLength(1); y++)
            {
                if (lArr[0, y] != '2')
                {
                    string resultingCO2binary = "";
                    for (int x = 0; x < lArr.GetLength(0); x++)
                    {
                        resultingCO2binary += lArr[x, y];
                    }
                    Console.WriteLine("Binary found, it was: " + resultingCO2binary);
                    co2 = Convert.ToInt32(resultingCO2binary, 2);
                    Console.WriteLine("In int form, that is " + co2);
                }
            }
            Console.WriteLine("result: " + oxygen * co2);
            
        }
    }
    
    
}
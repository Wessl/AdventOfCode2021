using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Ten
{
    public class Part1
    {
        
        public static void Solution()
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Ten\test.txt");
            char[] openers = new char[] {'(', '[', '{', '<'};
            char[] closers = new char[] {')', ']', '}', '>'};
            Dictionary<char, char> corresponding = new Dictionary<char, char>()
                {{'(', ')'}, {'[', ']'}, {'{', '}'}, {'<', '>'}};
            Stack<char> charStack = new Stack<char>();
            int errorSum = 0;
            for (int i = 0; i < inpLines.Length; i++)
            {
                for (int y = 0; y < inpLines[i].Length; y++)
                {
                    char c = inpLines[i][y];
                    if (openers.Contains(c))
                    {
                        charStack.Push(inpLines[i][y]);
                    }
                    else if (closers.Contains(c))
                    {
                        var prevOpen = charStack.Pop();
                        if (corresponding[prevOpen] != c)
                        {
                            // Illegal character. 
                            errorSum += GetPoints(c);
                        }
                    }
                }
            }

            Console.WriteLine("Illegal sum: " + errorSum);
        }

        private static int GetPoints(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
                default:
                    return 3;
            }
        }
    }
}
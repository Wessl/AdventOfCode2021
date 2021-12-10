using System;
using System.Collections.Generic;
using System.Linq;

namespace solutions.Ten
{
    public class Part2
    {
        public static void Main(string[] args)
        {
            string[] inpLines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Ten\input.txt");
            List<string> incompleteLines = inpLines.ToList();
            char[] openers = new char[] {'(', '[', '{', '<'};
            char[] closers = new char[] {')', ']', '}', '>'};
            Dictionary<char, char> openToClose = new Dictionary<char, char>()
                {{'(', ')'}, {'[', ']'}, {'{', '}'}, {'<', '>'}};
            Stack<char> charStack = new Stack<char>();
            
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
                        if (openToClose[prevOpen] != c)
                        {
                            // illegal character, discard this line
                            incompleteLines[i] = "x";
                        }
                    }
                }
            }
            // now go over incomplete lines and complete them
            List<long> incompleteSums = new List<long>();
            for (int i = 0; i < incompleteLines.Count; i++)
            {
                if (incompleteLines[i].Equals("x"))
                {
                    continue;       // this line was marked as erroneous, skip it
                }
                incompleteSums.Add(0);
                charStack = new Stack<char>();
                for (int y = 0; y < incompleteLines[i].Length; y++)
                {
                    char c = incompleteLines[i][y];
                    if (openers.Contains(c))
                    {
                        charStack.Push(inpLines[i][y]);
                    }
                    else if (closers.Contains(c))
                    {
                        charStack.Pop();
                    }
                }
                // now we have gone over all the things. The remaining strings are incomplete. 
                foreach (var c in charStack)
                {
                    // There are only openers left
                    char correspondingChar = openToClose[c];
                    incompleteSums[^1] = incompleteSums[^1] * 5 + GetPoints(correspondingChar);
                }
            }
            incompleteSums.Sort();
            Console.WriteLine("Illegal sum: " + incompleteSums[incompleteSums.Count / 2]);
        }

        private static int GetPoints(char c)
        {
            switch (c)
            {
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '}':
                    return 3;
                case '>':
                    return 4;
                default:
                    Console.WriteLine("this should not happen");
                    return 0;
            }
        }
    }
}
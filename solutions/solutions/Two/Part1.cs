using System;
using System.Collections.Generic;
using System.Numerics;

namespace solutions.Two
{
    public class Part1
    {
        public static void Solve()
        {
            string line;
            List<string> commandLines = new List<string>();
            Vector2 pos = new Vector2();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                commandLines.Add(line);
                string[] splitted = line.Split(" ");
                int n = int.Parse(splitted[1]);
                if (splitted[0].Equals("forward"))
                {
                    pos.X += n;
                } else if (splitted[0].Equals("up"))
                {
                    pos.Y -= n;
                } else if (splitted[0].Equals("down"))
                {
                    pos.Y += n;
                }
            }

            Console.WriteLine(pos.ToString());
        }
    }
}
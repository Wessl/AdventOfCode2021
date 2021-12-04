using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace solutions.Four
{
    public class Part2
    {
        private static List<int[,]> bingoBoards;
        private static List<int[,]> bingoBoardSpotsGot;
        public static void Main(string[] args)
        {
            bingoBoards = new List<int[,]>();
            bingoBoardSpotsGot = new List<int[,]>();
            
            
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\love\Documents\Github Desktop\AdventOfCode2021\solutions\solutions\Four\input.txt");
            string[] inputNumbers = lines[0].Split(",");
            string line;
            // populate boards with numbers
            for (int x = 1; x < lines.Length; x++)
            {
                string currLine = lines[x];
                if (currLine == "")
                {
                    int[,] board = new int[5,5];
                    for (int y = 0; y < 5; y++)
                    {
                        // split string on any length of whitespace
                        var nextLine = Regex.Split(lines[x + 1 + y], @"\s+").Where(s => s != string.Empty).ToList();
                        for (int xx = 0; xx < 5; xx++)
                        {
                            board[xx, y] = int.Parse(nextLine[xx]);
                        }
                    }
                    bingoBoards.Add(board);
                }
            }
            // populate the corresponding checking board
            bingoBoardSpotsGot = InitializeConfirmationBoard(bingoBoards);
            // now go through the inputnumbers and update the boards
            // item1 = winning board, item2 = winning number;
            Tuple<int,int> winners = GoOverInputs(inputNumbers);
            // now if we have a winning board, find every non winning number
            int sum = 0;
            int[,] winningBoard = bingoBoards[winners.Item1];
            int[,] winningBoardSpots = bingoBoardSpotsGot[winners.Item1];
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (winningBoardSpots[x, y] != 1)
                    {
                        sum += bingoBoards[winners.Item1][x, y];
                    }
                }
            }

            Console.WriteLine("Sum is " + sum + ". Multiplied with winning number the result is: " +
                              sum * winners.Item2);
        }

        private static Tuple<int,int> GoOverInputs(string[] inputNumbers)
        {
            int boardsLeft = bingoBoards.Count;
            List<int> finishedBoards = new List<int>();
            int winningBoard = 0;
            int winningNumber = 0;
            foreach (var inputNumber in inputNumbers)
            {
                int num = int.Parse(inputNumber);
                for (int i = 0; i < bingoBoards.Count; i++)
                {
                    for (int y = 0; y < bingoBoards[i].GetLength(1); y++)
                    {
                        for (int x = 0; x < bingoBoards[i].GetLength(0); x++)
                        {
                            if (bingoBoards[i][x, y] == num)
                            {
                                bingoBoardSpotsGot[i][x, y] = 1;
                                // check if row or column is complete
                                if (CheckRow(bingoBoardSpotsGot[i], x) || CheckCol(bingoBoardSpotsGot[i], y))
                                {
                                    if (!finishedBoards.Contains(i))
                                    {
                                        finishedBoards.Add(i);
                                        boardsLeft--;
                                        if (boardsLeft == 0)
                                        {
                                            winningBoard = i;
                                            winningNumber = num;
                                            return new Tuple<int,int>(winningBoard, winningNumber);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // nothing was found? that sucks. 
            Console.WriteLine("nothing was found .sad. ");
            return null;
        }
        
        // returns true if this row is all 1's, else false
        private static bool CheckRow(int[,] board, int x)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (board[x, y] != 1) return false;
            }
            return true;
        }
        
        // returns true if this col is all 1's else false
        private static bool CheckCol(int[,] board, int y)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                if (board[x, y] != 1) return false;
            }
            return true;
        }

        private static List<int[,]> InitializeConfirmationBoard(List<int[,]> boards)
        {
            List<int[,]> newBoards = new List<int[,]>();
            foreach (var board in boards)
            {
                int[,] newBoard = new int[5,5];
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        newBoard[x, y] = -1;
                    }
                }
                newBoards.Add(newBoard);
            }

            return newBoards;
        }

        private static void ConfirmBoards(List<int[,]> bingoBoards)
        {
            foreach (var board in bingoBoards)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        Console.Write(board[x,y] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
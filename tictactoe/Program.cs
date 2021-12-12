using System;
using System.Collections.Generic;
using System.Linq;

namespace tictactoe
{
    class Program
    {
        static readonly string[] item = new string[] {" ","o","x"};
        static void Main(string[] args)
        {
            bool Win = false;
            int[] board = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
            int turn = 1;

            int disposV = Console.CursorTop + 1;
            int disposH ="It is '".Length+1;
            Console.WriteLine($"  Tic-Tac-Toe\n It is '{item[turn]}' turn!\n");

            int MaxLine = Console.CursorTop;
            int MinLine = Console.CursorTop+2;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"   [{item[board[(i * 3)]]}] [{item[board[(i * 3) + 1]]}] [{item[board[(i * 3) + 2]]}]");
            }

            int Vp = MaxLine;
            int Hp = 1;
            int WinType = 0;

            while (Win != true)
            {
                Console.SetCursorPosition(Hp*4, Vp);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (Vp == MaxLine)
                            {
                                break;
                            }
                            else
                            {
                                Vp--;
                            }
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (Vp == MinLine)
                            {
                                break;
                            }
                            else
                            {
                                Vp++;
                            }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (Hp == 3)
                            {
                                break;
                            }
                            else
                            {
                                Hp++;
                            }
                            break;
                        }

                    case ConsoleKey.LeftArrow:
                        {
                            if (Hp == 1)
                            {
                                break;
                            }
                            else
                            {
                                Hp--;
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            int index = (Vp - MaxLine) * 3 + Hp - 1;
                            if (board[index] == 0)
                            {
                                if (turn == 1)
                                {
                                    board[index] = turn;
                                    Console.Write("o");
                                    if (WinPos(board, turn) != 0)
                                    {
                                        WinType = WinPos(board, turn);
                                        Win = true;
                                        break;
                                    }
                                    turn = 2;
                                }
                                else
                                {
                                    board[index] = turn;
                                    Console.Write("x");
                                    if (WinPos(board, turn) != 0)
                                    {
                                        WinType = WinPos(board, turn);
                                        Win = true;
                                        break;
                                    }
                                    turn = 1;
                                }
                                Console.SetCursorPosition(disposH, disposV);
                                Console.Write(item[turn]);
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            for (int i = 0; i < 3; i++)
                            {
                                Console.WriteLine($"   [{item[board[(i * 3)]]}] [{item[board[(i * 3) + 1]]}] [{item[board[(i * 3) + 2]]}]");
                            }
                            break;
                        }
                }
            }

            Console.Clear();
            if (WinType == 3)
            {
                Console.WriteLine("Game Tied");
            }

            else
            {
                Console.WriteLine($"{item[WinType]} wins!");
            }

            Console.ReadLine();
        }

        static int WinPos(int[] board, int turn)
        {
            // 0,undecided 1,o-win 2,x-win 3,tied
            int State = 0;

            int[][] winning = new int[][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 },
            };
            for (int i = 0; i < winning.Length; i++)
            {
                bool check = true;
                for (int j = 0; j < 3; j++)
                {
                    int position1in3 = winning[i][j];
                    if (board[position1in3] != turn)
                    {
                        //check if value on board == x or o
                        check = false;
                    }
                }
                if (check == true)
                {
                    return turn;
                }

            }

            if (board.Contains(0))
            {
                //Check if there is an empty space tile
                //if yes, not tied, contiune game
                State = 0;
            }
            else
            {
                //game tied
                State = 3;
            }
            return State;
        }
    }
}

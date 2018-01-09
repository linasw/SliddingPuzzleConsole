using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSlider
{
    class Program
    {
        private static string[,] gameGrid = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", ""} };
        private static string[,] completedGrid = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "" } };
        private static int[] emptyPos = { 0, 0 };
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            Shuffle(rnd, gameGrid);
            FindEmptyElement();
            do
            {
                Draw(gameGrid);         
                Menu();
                if (gameGrid.Cast<string>().SequenceEqual(completedGrid.Cast<string>()))
                {
                    Draw(gameGrid);
                    Console.WriteLine("\n\n***** Y O U   W O N *****");
                    Console.WriteLine("Do you want to play again? y/n");

                    do
                    {
                        ConsoleKeyInfo answer = Console.ReadKey();
                        if (Char.ToLower(answer.KeyChar) == 'y')
                        {
                            Shuffle(rnd, gameGrid);
                            FindEmptyElement();
                            break;
                        }

                        if (Char.ToLower(answer.KeyChar) == 'n')
                        {
                            return;
                        }
                    } while (true);
                }
            } while (true);
        }

        private static void Draw(string[,] gameGrid)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("S L I D E   P U Z Z L E");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(gameGrid[i,0] + " | " + gameGrid[i,1] + " | " + gameGrid[i,2] + " | ");
            }
            Console.WriteLine("-------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("W: Slide up");
            Console.WriteLine("S: Slide down");
            Console.WriteLine("A: Slide left");
            Console.WriteLine("D: Slide right");
            Console.WriteLine();
            Console.WriteLine("R: Shuffle");
            Console.WriteLine("Q: Quit");
        }

        private static void Menu()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (Char.ToLower(key.KeyChar))
            {
                case 'w':
                    Slide(key.KeyChar);
                    break;
                case 's':
                    Slide(key.KeyChar);
                    break;
                case 'a':
                    Slide(key.KeyChar);
                    break;
                case 'd':
                    Slide(key.KeyChar);
                    break;
                case 'r':
                    //SHUFFLE
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You missclicked...");
                    break;
            }
        }

        private static void Slide(char key)
        {
            int i = emptyPos[0];
            int n = emptyPos[1];
            
            if (key == 's')
            {
                if (i - 1 >= 0)
                {
                    Swap(i, n, i - 1, n);
                    return;
                }
            }

            if (key == 'w')
            {
                if (i + 1 <= 2)
                {
                    Swap(i, n, i + 1, n);
                    return;
                }
            }

            if (key == 'a')
            {
                if (n + 1 <= 2)
                {
                    Swap(i, n, i, n + 1);
                    return;
                }
            }

            if (key =='d')
            {
                if (n - 1 >= 0)
                {
                    Swap(i, n, i, n - 1);
                    return;
                }
            }
        }

        private static void Swap(int iEmpty, int nEmpty, int iToSwap, int nToSwap)
        {
            gameGrid[iEmpty, nEmpty] = gameGrid[iToSwap, nToSwap];
            gameGrid[iToSwap, nToSwap] = "";
            emptyPos[0] = iToSwap;
            emptyPos[1] = nToSwap;
        }

        public static void Shuffle<T>(Random random, T[,] array)
        {
            int lengthRow = array.GetLength(1);

            for (int i = array.Length - 1; i > 0; i--)
            {
                int i0 = i / lengthRow;
                int i1 = i % lengthRow;

                int j = random.Next(i + 1);
                int j0 = j / lengthRow;
                int j1 = j % lengthRow;

                T temp = array[i0, i1];
                array[i0, i1] = array[j0, j1];
                array[j0, j1] = temp;
            }
        }

        public static void FindEmptyElement()
        {
            for (int i = 0; i < 2; i++)
                for (int n = 0; n < 2; n++)
                {
                    if (gameGrid[i, n] == "")
                    {
                        emptyPos[0] = i;
                        emptyPos[1] = n;
                    }
                }
        }
    }
}

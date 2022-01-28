using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full2048
{
    internal class my2048
    {

        private int[][] arr = new int[4][];
        private int score;
        private Random rnd = new Random();

        public my2048()
        {
            arr[0] = new int[] { 0, 0, 0, 0 };
            arr[1] = new int[] { 0, 0, 0, 0 };
            arr[2] = new int[] { 0, 0, 0, 0 };
            arr[3] = new int[] { 0, 0, 0, 0 };
            score = 0;
        }

        

        private void ToRight()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int count = arr[i].Length -1;
                for (int j = arr[i].Length - 1; j >= 0; j--)
                {
                    if (arr[i][j] != 0)
                    {
                        int x = arr[i][j];
                        arr[i][j] = 0;
                        arr[i][count] = x;
                        count--;
                    }
                }
            }
        }

        private void MergeRight()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr[i].Length - 1; j > 0; j--)
                {
                    if (arr[i][j] == arr[i][j - 1]  && arr[i][j] != 0)
                    {
                        arr[i][j - 1] = 0;
                        score += arr[i][j];
                        arr[i][j] *= 2;
                    }
                }
            }
        }



        public void MoveRight()
        {
            ToRight();
            MergeRight();
        }

        private void ToLeft()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] != 0)
                    {
                        int x = arr[i][j];
                        arr[i][j] = 0;
                        arr[i][count] = x;
                        count++;
                    }
                }
            }
        }

        private void MergeLeft()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length -1; j++)
                {
                    if (arr[i][j] == arr[i][j + 1] && arr[i][j] != 0)
                    {
                        arr[i][j + 1] = 0;
                        score += arr[i][j];
                        arr[i][j] *= 2;
                    }
                }
            }
        }

        public void MoveLeft()
        {
            ToLeft();
            MergeLeft();
        }

        private void ToUp()
        {


            int[] rows = new int [arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] != 0)
                    {
                        int x = arr[i][j];
                        arr[i][j] = 0;
                        arr[rows[j]][j] = x;
                        rows[j]++;
                    }
                }
            }
        }
        private void MergeUp()
        {
            for (int i = 0; i < arr.Length -1; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == arr[i + 1][j] && arr[i][j] != 0)
                    {
                        arr[i + 1][j] = 0;
                        score += arr[i][j];
                        arr[i][j] *= 2;
                    }
                }
            }
        }
        public void MoveUp()
        {
            ToUp();
            MergeUp();
        }


        private void ToDown()
        {


            int[] rows = {arr[0].Length -1, arr[0].Length - 1 , arr[0].Length - 1 , arr[0].Length - 1 };
            for (int i = arr.Length -1; i >= 0; i--)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] != 0)
                    {
                        int x = arr[i][j];
                        arr[i][j] = 0;
                        arr[rows[j]][j] = x;
                        rows[j]--;
                    }
                }
            }
        }
        private void MergeDown()
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == arr[i - 1][j] && arr[i][j] != 0)
                    {
                        arr[i - 1][j] = 0;
                        score += arr[i][j];
                        arr[i][j] *= 2;
                    }
                }
            }
        }

        public void MoveDown()
        {
            ToDown();
            MergeDown();
        }

        public void AddNum()
        {
            int line = rnd.Next(arr.Length);
            int place = rnd.Next(arr[0].Length);

            while(arr[line][place] != 0)
            {
                line = rnd.Next(arr.Length);
                place = rnd.Next(arr[0].Length);
            }

            if (rnd.Next(101) >= 85)
            {
                arr[line][place] = 4;
            }
            else
            {
                arr[line][place] = 2;
            }
        }

        private ConsoleColor Color(int num)
        {
            ConsoleColor c = (ConsoleColor)(Math.Log(num, 2));
            return c;
        }

        public bool MergeOne()
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length - 1; j++)
                {
                    if (arr[i][j] == arr[i][j + 1] && arr[i][j] != 0)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool MergeTwo()
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == arr[i + 1][j] && arr[i][j] != 0)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsIn(int num)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == 0)
                    {
                        count++;
                    }
                }
            }
            if (count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Draw()
        {
            AddNum();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {

                    //Console.ForegroundColor = Color(arr[i][j]);

                    if (arr[i][j] < 10)
                    {
                        if (arr[i][j] == 0)
                        {
                            Console.Write(" " + "    ");
                        }
                        else
                        {
                            Console.ForegroundColor = Color(arr[i][j]);
                            Console.Write(arr[i][j] + "    ");
                        }
                    }
                    else if (arr[i][j] > 10 && arr[i][j] < 100)
                    {
                        Console.ForegroundColor = Color(arr[i][j]);
                        Console.Write(arr[i][j] + "   ");
                    }
                    else if (arr[i][j] > 100 && arr[i][j] < 1000)
                    {
                        Console.ForegroundColor = Color(arr[i][j]);
                        Console.Write(arr[i][j] + "  ");
                    }
                    else if (arr[i][j] > 1000)
                    {
                        Console.ForegroundColor = Color(arr[i][j]);
                        Console.Write(arr[i][j] + " ");
                    }

                    /*else if (arr[i][j] > 10 && arr[i][j] < 100)
                    {
                        Console.BackgroundColor = Color(arr[i][j]);
                        Console.Write(arr[i][j] + " ");
                        Console.Write("  " + arr[i][j] + " ");
                    }
                    else if (arr[i][j] > 100 && arr[i][j] < 1000)
                    {
                        Console.BackgroundColor = Color(arr[i][j]);
                        Console.Write(arr[i][j] + " ");
                        Console.Write(" " + arr[i][j] + " ");
                    }
                    else if (arr[i][j] > 100 && arr[i][j] < 1000)
                    {
                        Console.BackgroundColor = Color(arr[i][j]);
                        Console.Write(arr[i][j] + " ");
                        Console.Write(arr[i][j] + " ");
                    }*/

                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        public void DrawScore()
        {
            Console.ForegroundColor= ConsoleColor.White;
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Score: " + score);
        }
    }
}

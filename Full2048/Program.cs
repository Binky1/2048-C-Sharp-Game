using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full2048
{
    internal class Program
    {
        static void Main(string[] args)
        {
            my2048 m = new my2048();
            bool cont = true;

            while (cont)
            {
                m.Draw();
                m.DrawScore();
                ConsoleKeyInfo key = Console.ReadKey();


                if (key.Key == ConsoleKey.RightArrow)
                {
                    m.MoveRight();
                }

                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    m.MoveLeft();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    m.MoveUp();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    m.MoveDown();
                }
                if (!m.IsIn(0)&&!m.MergeOne()&& !m.MergeTwo())
                {
                    cont = false;
                }
                Console.Clear();
            }
            Console.WriteLine("Game over");
            Console.ReadKey();
        }

    }
}

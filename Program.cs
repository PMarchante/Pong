using System;

namespace SpaceGame
{
    class Program
    {

        public void gameSpace()
        {
            String paddle = "|";
            String ball = "*";
            int paddleLocation = 5;
            string wall = "                                                            |";
            string[,] space = new string[20, 30];

            for (int x = 0; x < 20; x++)
            {

                Console.Write("\n");
                for (int y = 0; y < 30; y++)
                {

                    space[5, 5] = paddle;
                    if (y >= 29)
                    {
                        space[x, y] = wall;

                        if (paddleLocation == x)
                        {
                            space[x, y] = wall.Replace(wall, "                                                           |");
                        }
                    }

                    if (x == 0 || x == 19)
                    {
                        space[x, y] = "__";
                    }

                    Console.Write(space[x, y]);
                }
            }
        }




        static void Main(string[] args)
        {
            Program test = new Program();

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                //clears console and redraws
                Console.Clear();
                test.gameSpace();
            }

        }
    }
}

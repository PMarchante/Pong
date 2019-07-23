using System;

namespace SpaceGame
{
    class Program
    {
        int paddleLocation = 6;
        public void gameSpace(ConsoleKey input)
        {
            String paddle = "P";
            String ball = "*";
            string wall = "                                                            |";
            string paddleWall = "                                                           |";
            string[,] space = new string[20, 30];

            Console.Clear();
            if (input == ConsoleKey.UpArrow)
            {
                paddleLocation++;

            }

            if (input == ConsoleKey.DownArrow)
            {
                paddleLocation--;

            }

            for (int x = 0; x < 20; x++)
            {
                bool paddleHere = false;
                space[paddleLocation, 5] = paddle;


                if (x == paddleLocation)
                {
                    paddleHere = true;
                    space[x, 6] = paddleWall;
                }
                Console.Write("\n");
                for (int y = 0; y < 30; y++)
                {

                    if (y >= 29 && !paddleHere)
                    {
                        space[x, y] = wall;
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
                //Console.Clear();
                test.gameSpace(Console.ReadKey().Key);

            }


        }
    }
}

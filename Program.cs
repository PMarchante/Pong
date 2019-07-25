using System;


namespace SpaceGame
{
    class Program
    {
        int paddleLocation = 10;
        int ballLocation = 0;
        int height = 20;
        int length = 30;
        public void gameSpace(ConsoleKey input)
        {
            String paddle = "P";
            String ball = "*";
            string wall = "|";
            string paddleWall = " |";
            string[,] space = new string[length, height];

            Console.Clear();

            if ((input == ConsoleKey.UpArrow && (paddleLocation >= 2 && paddleLocation <= height)))
            {
                paddleLocation--;
                Console.WriteLine("in if " + paddleLocation);
            }

            if ((input == ConsoleKey.DownArrow && (paddleLocation >= 1 && paddleLocation <= height - 3)))
            {
                paddleLocation++;
                Console.WriteLine("in if " + paddleLocation);
            }

            for (int y = 0; y < height; y++)
            {
                bool paddleHere = false;

                Console.Write("\n");
                for (int x = 0; x < length; x++)
                {
                    if (y == paddleLocation) { paddleHere = true; }
                    space[1, paddleLocation] = paddle;

                    if (paddleHere && x < length - 1)
                    {
                        space[x + 1, y] = " ";
                    }
                    //fills in the game board with spaces
                    if (x < length && !paddleHere)
                    {
                        space[x, y] = " ";
                    }

                    //places the wall at the end of the gameboard
                    if (x == length - 1)
                    {
                        space[x, y] = wall;
                        if (paddleHere)
                        {
                            space[x, y] = paddleWall;
                        }
                    }

                    //draws the top and bottom lines of the game board
                    if (y == 0 || (y == height - 1))
                    {
                        space[x, y] = "_";
                    }

                    Console.Write(space[x, y]);
                }
            }
        }




        static void Main(string[] args)
        {
            Program test = new Program();
            while (true)
            {
                test.gameSpace(Console.ReadKey().Key);
            }






        }
    }
}

using System;
using System.Threading;

namespace SpaceGame
{
    class Program
    {
        int paddleLocation = 10;
        int ballLocationY = 11;
        int ballLocationX = 2;
        int height = 20;
        int length = 30;
        bool hitWall = false;
        bool hitBkWall = false;
        bool goingBack = false;
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

            //pressing spacebar makes ball travel up diagnal
            if ((ballLocationY >= 1 && ballLocationX <= (length - 1)) && !hitWall)
            {
                Console.WriteLine("inside first if");
                switch (hitBkWall)
                {
                    case false:
                        ballLocationX++;
                        ballLocationY--;
                        Console.WriteLine("inside first case");
                        break;

                    case true:
                        ballLocationX--;
                        ballLocationY--;
                        Console.WriteLine($"inside 2nd case x{ballLocationX} y{ballLocationY}");
                        if (ballLocationY == 1 || ballLocationY == (height - 1))
                        {
                            hitWall = true;
                            hitBkWall = false;
                            goingBack = true;
                        }
                        break;
                }


            }
            if (goingBack)
            {
                ballLocationX--;
                ballLocationY++;
            }
            if ((ballLocationX + 1) == paddleLocation || (ballLocationY + 1 == paddleLocation) || (ballLocationX + 2) == paddleLocation || (ballLocationY + 2 == paddleLocation))
            {
                goingBack = false;
                ballLocationX++;
                ballLocationY--;
            }

            if ((ballLocationY == 1 || ballLocationY == (height - 3) || hitWall) && !hitBkWall && !goingBack)
            {
                //Console.WriteLine($"in spacebar wall hit if x{ballLocationX} y{ballLocationY}");
                ballLocationX++;
                ballLocationY++;
                hitWall = true;
                hitBkWall = false;
            }
            if (hitWall && ballLocationY == (height - 2))
            {
                ballLocationY--;
                ballLocationX++;
            }
            //checks if ball hit back wall
            if (ballLocationX == (length - 2) && (ballLocationY >= 1 || ballLocationY <= (height - 3)))
            {
                //Console.WriteLine($"in spacebar hit back wall if x{ballLocationX} y{ballLocationY}");
                ballLocationX--;
                ballLocationY--;
                hitBkWall = true;
                hitWall = false;
            }

            for (int y = 0; y < height; y++)
            {
                bool paddleHere = false;
                bool ballHere = false;

                Console.Write("\n");
                for (int x = 0; x < length; x++)
                {
                    //if the paddle is located in this y coordinate
                    if (y == paddleLocation) { paddleHere = true; }

                    //
                    if (y == ballLocationY || x == ballLocationX) { ballHere = true; }

                    space[1, paddleLocation] = paddle;

                    space[ballLocationX, ballLocationY] = ball;

                    if ((paddleHere || ballHere) && x < length - 1)
                    {
                        space[x + 1, y] = " ";
                    }

                    //fills in the game board with spaces
                    if ((x < length && !paddleHere && !ballHere))
                    {
                        space[x, y] = " ";
                    }

                    //places the wall at the end of the gameboard
                    if (x == length - 1)
                    {
                        space[x, y] = wall;
                        if (paddleHere || ballHere)
                        {
                            space[x, y] = paddleWall;
                        }

                    }

                    //draws the top and bottom lines of the game board
                    if (y == 0 || (y == height - 1))
                    {
                        space[x, y] = "-";
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

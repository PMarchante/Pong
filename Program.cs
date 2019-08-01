using System;
using System.Threading;
using System.Threading.Tasks;
namespace Pong
{
    public class Paddle
    {
        public int yPosition;
        public string icon = "[ ";
        public Paddle(int yPosition)
        {
            this.yPosition = yPosition;
        }
        public void movePadUp()
        {
            yPosition--;
        }
        public void movePadDown()
        {
            yPosition++;
        }

    }

    public class Ball
    {
        public string icon = "*";
        public int ballLocationY = 10;
        public int ballLocationX = 2;

        public Ball() { }

        public Ball(int ballLocationY, int ballLocationX)
        {
            this.ballLocationX = ballLocationX;
            this.ballLocationY = ballLocationY;
        }
        public int moveBallXCoord()
        {
            return ballLocationX++;
        }

        public int moveBallYCoord()
        {
            return ballLocationY++;
        }

    }

    class Display
    {
        string bkWall = "|";
        string topNBotWall = "-";
        int fps = 0;
        public string[,] gameSpace(int length, int height, Ball ball, Paddle paddle, ConsoleKey input)
        {

            string[,] space = new string[length, height];
            Console.Clear();
            Console.WriteLine($"fps: {fps++}");

            if (input == ConsoleKey.UpArrow)
            {
                paddle.movePadUp();
            }

            for (int y = 0; y < height; y++)
            {

                Console.Write("\n");
                for (int x = 0; x < length; x++)
                {


                    //fills gameboard with space
                    if (y >= 1 && y < height - 1)
                    {
                        if ((y == paddle.yPosition && x < length - 1))
                        {
                            space[1, paddle.yPosition] = paddle.icon;
                            space[(x + 1), paddle.yPosition] = " ";
                        }
                        else
                            space[x, y] = " ";
                    }
                    //draws back wall
                    if (x == length - 1)
                    {
                        space[x, y] = bkWall;
                    }
                    //draws the top and bottom lines of the game board
                    if (y == 0 || (y == height - 1))
                    {
                        space[x, y] = topNBotWall;
                    }

                    Console.Write(space[x, y]);
                }

            }
            //Thread.Sleep(1000);
            return space;
        }
    }
    class Program
    {
        int height = 20;
        int length = 30;
        string bkWall = "|";
        string topNBotWall = "-";
        int fps = 0;
        /*
    public void gameSpace(ConsoleKey input, Paddle paddle, Ball ball)
    {


        string[,] space = new string[length, height];

        Console.Clear();
        Console.WriteLine($"fps: {fps}\n");
        if (input == ConsoleKey.UpArrow && paddle.yPosition >= 2)
        {
            paddle.movePadUp();

        }
        if (input == ConsoleKey.DownArrow && paddle.yPosition < (height - 2))
        {
            paddle.movePadDown();

        }



        for (int y = 0; y < height; y++)
        {

            bool paddleHere = false;
            bool ballHere = false;

            Console.Write("\n");
            for (int x = 0; x < length; x++)
            {


                //fills gameboard with space
                if (y >= 1 && y < height - 1)
                {
                    //places the paddle on the board
                    if ((y == paddle.yPosition && x < length - 1))
                    {
                        space[1, paddle.yPosition] = paddle.icon;
                        space[(x + 1), paddle.yPosition] = " ";
                        paddleHere = true;

                    }

                    else
                        space[x, y] = " ";

                    if (y == ball.ballLocationY && x == ball.ballLocationX)
                    {
                        space[ball.ballLocationX, ball.ballLocationY] = ball.icon;

                        if (ball.ballLocationX >= 1 && ball.ballLocationY == 1)
                        {
                            Console.WriteLine("hit top wall");
                        }

                    }

                }
                //draws back wall
                if (x == length - 1)
                {
                    space[x, y] = bkWall;
                }
                //draws the top and bottom lines of the game board
                if (y == 0 || (y == height - 1))
                {
                    space[x, y] = topNBotWall;
                }

                Console.Write(space[x, y]);
            }

            fps++;


            Thread.Sleep(1000);
        }

    }
    */



        static void Main(string[] args)
        {
            Program test = new Program();
            Paddle p = new Paddle(10);
            Ball b = new Ball();
            Display display = new Display();
            ConsoleKey input = Console.ReadKey().Key;


            Task.Run(async () =>
            {

                while (true)
                {
                    display.gameSpace(25, 20, b, p, input);
                    await Task.Delay(1000);
                }
            });
            while (true)
            {

            }




        }
    }
}

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
        string bkWall = " |";
        string topNBotWall = "-";
        int fps = 0;
        bool ballHere = false;
        bool paddleHere = false;
        public string[,] gameSpace(int length, int height, Ball ball, Paddle paddle)
        {
            
            string[,] space = new string[length, height];
            Console.Clear();
            Console.WriteLine($"fps: {fps++}");
            
            
            for (int y = 0; y < height; y++)
            {
                
                Console.Write("\n");
                for (int x = 0; x < length; x++)
                {
                    if (x == ball.ballLocationX && y == ball.ballLocationY)
                    {
                        space[ball.ballLocationX, ball.ballLocationY] = ball.icon;
                        ballHere = true;
                    }

                    //fills gameboard with space
                    if ((y >= 1 && y < height - 1))
                    {
                        if ((y == paddle.yPosition && x < length - 1))
                        {
                            
                            space[1, paddle.yPosition] = paddle.icon;
                          
                            paddleHere = true;
                        }

                    }

                    //whereever the paddle and ball are not located, place an empty space
                    if (y != paddle.yPosition && y != ball.ballLocationY && x != ball.ballLocationX)
                    {
                        space[x, y] = " ";
                    }
                    //adds spaces to line up back wall
                    if (x < length - 2)
                    {
                        space[(x + 1), ball.ballLocationY] = " ";
                        if (x < length - 3)
                        {
                            space[(x + 1), paddle.yPosition] = " ";
                            
                        }
                        if (space[x, y] == paddle.icon && space[(x), y] == ball.icon)
                        {
                            Console.WriteLine("ok");
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

            }
            
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
                    

                    display.gameSpace(25, 20, b, p);
                    await Task.Delay(150);

                    
                }
            });

            while (true) {
                input = Console.ReadKey().Key;
                
                if (input == ConsoleKey.UpArrow)
                {
                    p.movePadUp();
                   
                }

                if (input == ConsoleKey.DownArrow)
                {
                    p.movePadDown();

                }
            }

        }
    }
}

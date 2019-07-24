using System;


namespace SpaceGame
{
    class Program
    {
        int paddleLocation = 10;
        int ballLocation = 7;
        public void gameSpace(ConsoleKey input)
        {
            String paddle = "P";
            String ball = "*";
            string wall = "|";
            string paddleWall = " |";
            string[,] space = new string[20, 20];

            Console.Clear();
            if ((input == ConsoleKey.UpArrow && (paddleLocation >= 2 && paddleLocation <= 19)))
            {
                paddleLocation--;
                Console.WriteLine("in if " + paddleLocation);
            }

            if ((input == ConsoleKey.DownArrow && (paddleLocation >= 1 && paddleLocation <= 18)))
            {
                paddleLocation++;
                Console.WriteLine("in if " + paddleLocation);
            }

            for (int y = 0; y < 20; y++)
            {
                bool paddleHere = false;
                space[paddleLocation, 5] = paddle;


                if (y == paddleLocation)
                {
                    paddleHere = true;
                    //space[paddleLocation, 6] = paddleWall;
                }
                Console.Write("\n");
                for (int x = 0; x < 20; x++)
                {
                    if (!paddleHere)
                    {
                        space[x, y] = "";

                    }
                    if (paddleHere)
                    {
                        space[paddleLocation, 19] = "N";
                    }

                    if (y >= 19)
                    {
                        space[x, y] = wall;
                    }

                    if (x == 0 || x == 19)
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

            do
            {
                //Console.WriteLine("WELCOME TO PONG!");
                test.gameSpace(Console.ReadKey().Key);
            }
            while (true);







        }
    }
}

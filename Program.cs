using System;

namespace SpaceGame
{
    class Program
    {

        public char[][] gameSpace()
        {
            char[][] space = new char[30][];

            for (int x = 0; x < space.Length; x++)
            {


                for (int y = 0; y < space.Length; y++)
                {
                    //if (x == 30)
                    space[x][y] = '-';
                }
                Console.WriteLine(space);
            }

            return space;
        }



        static void Main(string[] args)
        {
            /*
            Program test = new Program();
            for (int x = 0; x == 100; x++)
            {
                Console.WriteLine(test.gameSpace());
            }
            */

            string[,] space = new string[20, 30];

            for (int x = 0; x < 20; x++)
            {

                Console.Write("\n");
                for (int y = 0; y < 30; y++)
                {
                    if (y >= 29)
                    {
                        space[x, y] = "                                                            |";
                    }

                    if (x == 0 || x == 19)
                    {
                        space[x, y] = "__";
                    }

                    Console.Write(space[x, y]);
                }

            }


        }
    }
}

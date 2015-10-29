using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{

    class Program
    {
        public static void playerMove(int x, int y, Board b)
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    b.board[x,y].symbol = ".";
                    x -= 1;
                    //Finish movement
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Down");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("Right");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("Left");
                    break;
            }

        }
        static void Main(string[] args)
        {

            /*
            //Creates the player 
            Player player = new Player();
            Console.ReadKey();
            Console.Clear();
            int dieRoll = DieRoller.totalRoll(3, 6);
            int targetRoll = DieRoller.targetRoll(3, 6, 4);
            */

            Board b = new Board(20,20);            
            b.showBoard();
            Console.ReadKey();
            

        }
    }
}

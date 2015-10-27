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

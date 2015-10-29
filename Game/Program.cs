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

            Console.WriteLine("Choose a character class");
            Console.WriteLine("1. Fighter \n" +
                              "2. Frat \n" +
                              "3. Lover \n" +
                              "4. Gentleman \n" +
                              "5. Joker \n" +
                              "6. Klutz");

            int c_class;
            string number;
            do
            {
                Console.Write("\n(1-6): ");
                number = Console.ReadKey().KeyChar.ToString();

                try { c_class = int.Parse(number); }
                catch (FormatException e) { c_class = 0; }

            } while (c_class < 1 || c_class > 6);

            Player p1 = new Player(c_class);


        }
    }
}

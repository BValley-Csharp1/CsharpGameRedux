using System;
using System.Media;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    
    class Program
    {    
        public static void Intro()
        {
            Console.WriteLine("*** WELCOME ***");
            Console.WriteLine("Before we begin the game, there are a few things you need to know.");
            Console.WriteLine("\nMovement: \nTo move, press the corresponding arrow key as to where you'd like to go.");
            Console.WriteLine("\nGame Symbols and Their Meanings: \n# = walls \n. = floor \n☻ = bar patrons \n@ = player \no░o = a table and two stools");
            Console.WriteLine("\n░░░░░░\noooooo = the bar and stools \n\n███\n███ = the pool table");
            Console.WriteLine("\nWalk around, order a drink, and chat with the patrons until the bar closes or you pass out.");
            Console.ReadKey();
            Console.Clear();
        }
        public static void BarClosed()
        {
            Console.Clear();
            Console.WriteLine("*** BAR CLOSED ***");
            Console.WriteLine("\nAfter another typical night and many stumbling happy, sad, and pathetic drunks. The bar is now closed.");
            Console.WriteLine("\nBasically this is our nice way of saying: Go Home!!");
            Console.ReadKey();
            Console.Clear();
        }
        public static void PassedOut()
        {
            Console.Clear();
            Console.WriteLine("*** YOU PASSED OUT ***");
            Console.WriteLine("\nAfter a crazy night of heavy drinking you FINALLY passed out and now the bar can rejoice without you distrupting the patrons.");
            Console.WriteLine("\nYou have problems.");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            Intro();                   
             Console.WriteLine("Choose a character class");
             Console.WriteLine("1. Scrapper \n" +
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

             Console.Clear();

            //Generates the NPCS
            generateNPC npcs = new generateNPC();            

            //Creates and displays board
            Board board = new Board(20, 40);
            board.placeNPC(npcs.characters);
            board.placePlayer(p1.coordX, p1.coordY, p1);
            board.showBoard();

            /*
             int d;
             Console.WriteLine("Choose a drink:");
             Console.WriteLine("1. Beer \n" +
                               "2. RumCoke \n" +
                               "3. Screwdriver \n" +
                               "4. Wine \n" +
                               "5. Whiskey \n" +
                               "6. Gin Tonic \n" +
                               "7. Long Island Tea \n" +
                               "Press Esc to exit.");
             if (Console.ReadKey(true).Key == ConsoleKey.Escape)
             {
                 Environment.Exit(0);
             }
             number = Console.ReadKey().KeyChar.ToString();
             try { d = int.Parse(number); }
             catch (FormatException e) { d = 0; }

             //p1.chooseDrink(d);   
             */

            //Game ends at 1000 steps
            int gameoverCount = 0;
            //Main game loop
            while (gameoverCount != 1000)
            {
                //Select a random NPC to move
                int randomNPC = StaticRandom.Instance.Next(0, npcs.characters.Count);
                
                //Checks if the NPC has reached it's destination, if not move. 
                if (npcs.characters[randomNPC].destination)
                {
                    Movement.npcMove(board, npcs.characters[randomNPC]);
                }                
                else
                {
                    //Gives NPC new location
                    npcs.characters[randomNPC].destinationX = StaticRandom.Instance.Next(3, 14);
                    npcs.characters[randomNPC].destinationY = StaticRandom.Instance.Next(3, 14);
                    npcs.characters[randomNPC].destination = true;
                }
                gameoverCount++;
                Movement.playerMove(p1.coordX, p1.coordY, board, p1, p1.bac, p1.stepsTaken, npcs.characters[randomNPC]);
                
                //If player moves to bar, call the chooseDrink() method
                if (board.board[p1.coordX, p1.coordY].isBar)
                {
                    p1.chooseDrink();
                }                
                Console.Clear();
                board.showBoard();
            }
            BarClosed();         
        }
    }
}

/* Beer - basic plus
 * 
 * Screwdriver - agg plus
 * Gin & Tonic - mox plus
 * Coke & rum - hum plus
 * 
 * Whiskey - agg big plus
 * Wine - mox big plus
 * Long Island Iced Tea - hum big plus
*/

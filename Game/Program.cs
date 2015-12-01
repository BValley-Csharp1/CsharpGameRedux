using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    
    class Program
    {
        public static void playerMove(int x, int y, Board b, Player p, int bac, int steps)
        {
            
            //If statement to decrease BAC a level every 100 steps.
            if (p.stepsTaken == 100)
            {
                p.stepsTaken = 0;
                p.bac -= 1;
            }
            //50 for drink possession
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (b.board[x - 1, y].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        x -= 1;
                        b.board[x, y].playerHere = true;
                        p.coordX = x;
                        p.stepsTaken++;
                    }                    
                    break;
                case ConsoleKey.DownArrow:
                    if (b.board[x + 1, y].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        x += 1;
                        b.board[x, y].playerHere = true;
                        p.coordX = x;
                        p.stepsTaken++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (b.board[x, y + 1].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        y += 1;
                        b.board[x, y].playerHere = true;
                        p.coordY = y;
                        p.stepsTaken++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (b.board[x, y - 1].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        y -= 1;
                        b.board[x, y].playerHere = true;
                        p.coordY = y;
                        p.stepsTaken++;
                    }
                    break;
            }
            
            

        }
        static void Main(string[] args)
        {     
                                   
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
            
            //Creates and displays board
            Board board = new Board(20, 40);
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

            int gameoverCount =0;
            //Test loop for player movement, will be arranged for main game loop
            while (gameoverCount != 1000)
            {
                
                gameoverCount++;
                playerMove(p1.coordX, p1.coordY, board, p1, p1.bac, p1.stepsTaken);
                
                if (gameoverCount == 1000)
                {
                    //Create an intro and end game function(Writelines, ect are just placeholders.)
                    Console.Clear();
                    Console.WriteLine("You've run out of time!");
                    Console.ReadKey();
                    break;
                }
                if (board.board[p1.coordX, p1.coordY].isBar)
                {
                    p1.chooseDrink();

                }
                Console.Clear();
                board.showBoard();
            }          
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

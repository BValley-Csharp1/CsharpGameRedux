using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{

    class Program
    {
        public static void playerMove(int x, int y, Board b, Player p)
        {
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
                    }                    
                    break;
                case ConsoleKey.DownArrow:
                    if (b.board[x + 1, y].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        x += 1;
                        b.board[x, y].playerHere = true;
                        p.coordX = x;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (b.board[x, y + 1].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        y += 1;
                        b.board[x, y].playerHere = true;
                        p.coordY = y;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (b.board[x, y - 1].isPassable)
                    {
                        b.board[x, y].playerHere = false;
                        y -= 1;
                        b.board[x, y].playerHere = true;
                        p.coordY = y;
                    }
                    break;
            }
            Console.Clear();
            b.showBoard();
            

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

            /*
            //Creates and displays board
            Board board = new Board(20, 40);
            board.placePlayer(p1.coordX, p1.coordY, p1);
            board.showBoard();

            //Test loop for player movement, will be arranged for main game loop
            while (true)
            {
                playerMove(p1.coordX, p1.coordY, board, p1);
            }
            */
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

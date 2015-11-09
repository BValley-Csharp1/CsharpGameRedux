using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
             
namespace Game
{
    class Board
    {
        public Tile[,] board;
        int height;
        int length;
        int i;
        int j;

        //List used to connect rooms
        List<int[]> midpoints = new List<int[]>();

        //List for stair creation
        static string[] stairSymbols = { "#", "@"};
        List<string> stairs = new List<string>(stairSymbols);

        public Board(int x, int y)
        {
            height = x;
            length = y;

            //Sets the tile to the x and y coordinates
            board = new Tile [x, y];

            //Nested for loops that creates the 2d array of # as a game board
            for (int i = 0; i <= x - 1; i++){
               for (int j = 0; j <= y - 1; j++ ){
                    board[i,j] = new Tile ("#","#",ConsoleColor.Blue, ConsoleColor.Blue);
                    board[i, j].isPassable = false;     
               }
             }
            int roomx = 1;
            int roomh = 16;
            int roomy = 1;
            int rooml = 16;

            if (checkRoom(roomx, roomy, roomh, rooml))
            {
                createRoom(roomx, roomy, roomh, rooml);

            }

            //All of this will be placed in a loop to make sure it gets placed.
            int barx = StaticRandom.Instance.Next(1, height -1);
            int barh = 1;
            int bary = StaticRandom.Instance.Next(1, height - 1);
            int barl = StaticRandom.Instance.Next(5,15);
            if (checkBar(barx, bary, barh, barl))
            {
                createBar(barx, bary, barh, barl);

            }
            int tablex = StaticRandom.Instance.Next(1, height - 1);
            int tabley = StaticRandom.Instance.Next(1, height - 1);
            if (checkTable(tablex, tabley, 1, 1))
            {
                createTable(tablex, tabley, 1, 1);

            }

            //Testing the placeObject function and saving the ascii blocks for future use.
            //placeObject("stairs", "▀", stairs, ConsoleColor.Magenta, true);
            //placeObject("chair", "▄", stairs, ConsoleColor.Green, false);
            //placeObject("stool", "█", stairs, ConsoleColor.Red, false);
        }   
        public bool checkRoom(int x, int y, int h, int l)
        {
            //Loop starts at x and y coordinate to only loop through potential room
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    //If statement for checking the height and width
                    if (i >= height - 2 || j >= length - 2)
                    {
                        return false;
                    }
                    //Checks if its a wall
                    if (board[i, j].symbol != "#")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void createRoom(int x, int y, int h, int l)
        {
            //Sets the midpoint for each room
            int mpX = h / 2 + x;
            int mpY = l / 2 + y;

            //Loop for creating a room in desired area and width and height.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                  board[i, j].originalColor = ConsoleColor.Gray;
                  board[i, j].isPassable = true;
                  board[i, j].originalSymbol = ".";
                  board[i, j].symbol = ".";
                }
            }
            midpoints.Add(new int[] { mpX, mpY });

        }

        public bool checkBar(int x, int y, int h, int l)
        {
            //Loop starts at x and y coordinate to only loop through potential bar
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    //If statement for checking the height and width
                    if (i >= height - 2 || j >= length - 2)
                    {
                        return false;
                    }
                    //Checks if its in a room
                    if (board[i, j].symbol != "." )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void createBar(int x, int y, int h, int l)
        {
            //Sets the midpoint for the bar
            int mpX = h / 2 + x;
            int mpY = l / 2 + y;

            //Loop for creating a bar in desired area and width and height.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    board[i, j].originalColor = ConsoleColor.Green;
                    board[i, j].isPassable = false;
                    board[i, j].originalSymbol = "░";
                    board[i + 1, j].originalColor = ConsoleColor.Green;
                    board[i + 1, j].isPassable = true;
                    board[i + 1, j].originalSymbol = "o";
                }
            }
            midpoints.Add(new int[] { mpX, mpY });

        }

        public bool checkTable(int x, int y, int h, int l)
        {
            //Loop starts at x and y coordinate to only loop through potential bar
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    //If statement for checking the height and width
                    if (i >= height - 2 || j >= length - 2)
                    {
                        return false;
                    }
                    //Checks if its on a wall
                    if (board[i, j].symbol == "#")
                    {
                        return false;
                    }
                    //Checks if its in a room
                    if (board[i, j].symbol != ".")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void createTable(int x, int y, int h, int l)
        {
            //Sets the midpoint for the bar
            int mpX = h / 2 + x;
            int mpY = l / 2 + y;

            //Loop for creating a bar in desired area and width and height.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    board[i, j].originalColor = ConsoleColor.Green;
                    board[i, j].isPassable = false;
                    board[i, j].originalSymbol = "░";
                    board[i, j + 1].originalColor = ConsoleColor.Green;
                    board[i, j + 1].isPassable = true;
                    board[i, j + 1].originalSymbol = "o";
                    board[i, j - 1].originalColor = ConsoleColor.Green;
                    board[i, j - 1].isPassable = true;
                    board[i, j - 1].originalSymbol = "o";
                }
            }
            midpoints.Add(new int[] { mpX, mpY });

        }
        //Showboard method
        public void showBoard()
        {
            for (int i = 0; i <= height - 1; i++)
            {
                for (int j = 0; j <= length - 1; j++)
                {
                    Console.ForegroundColor = board[i, j].originalColor;
                    if (board[i, j].playerHere == true)
                    {
                        board[i, j].symbol = "@";
                        board[i, j].color = ConsoleColor.White;
                        Console.Write(board[i, j].symbol);
                    }         
                    else
                    {
                        Console.Write(board[i, j].originalSymbol);
                    }                                       
                }
                Console.WriteLine("");
            }     

       }   
   
    public Player placePlayer(int x, int y, Player p)
    {
        Player player = p;        
        int playerX = x;
        int playerY = y;

       //Generates player coordinates
        playerX = StaticRandom.Instance.Next(0, height - 1);
        playerY = StaticRandom.Instance.Next(0,length - 1);

        //While player coordinates are on a wall or stairs loop with new coordinates
        while (board[playerX, playerY].symbol == "#" || board[playerX, playerY].symbol == ">")
        {
            playerX = StaticRandom.Instance.Next(0, height - 1);
            playerY = StaticRandom.Instance.Next(0, length - 1);

        }
        board[playerX, playerY].playerHere = true;
        board[playerX, playerY].symbol = "@";

        //Sets player location to player.
        player.coordY = playerY;
        player.coordX = playerX;

        return player;

        }
        public void placeObject(string objectToPlace, string symbol, List<string> cantPlace, ConsoleColor color, bool passable)
        {         
            //Generates coordinates
            int X = StaticRandom.Instance.Next(0, height - 1);
            int Y = StaticRandom.Instance.Next(0, length - 1);

            //While player coordinates are on a wall or stairs loop with new coordinates
            while (board[X, Y].symbol == cantPlace[0])
            {
                X = StaticRandom.Instance.Next(0, height - 1);
                Y = StaticRandom.Instance.Next(0, length - 1);

            }            
            board[X, Y].isPassable = passable;
            board[X, Y].originalColor = color;
            board[X, Y].originalSymbol = symbol;

        }       
    }
    }


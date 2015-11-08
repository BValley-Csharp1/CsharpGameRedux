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
        List<int[]> midpoints = new List<int[]>();

        public Board(int x, int y)
        {
            height = x;
            length = y;

            //Sets the tile to the x and y coordinates
            board = new Tile [x, y];

            //Nested for loops that creates the 2d array of # as a game board
            for (int i = 0; i <= x - 1; i++){
               for (int j = 0; j <= y - 1; j++ ){
                    board[i,j] = new Tile ("#", ConsoleColor.Blue);
                    board[i, j].isPassable = false;     
               }
             }
            int roomx = 1;
            int roomh = 15;

            int roomy = 1;
            int rooml = 15;

            if (checkRoom(roomx, roomy, roomh, rooml))
            {
                createRoom(roomx, roomy, roomh, rooml);

            }
            placeStairs();
        
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
                  board[i, j].color = ConsoleColor.Gray;
                  board[i, j].isPassable = true;
                  board[i, j].symbol = ".";
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
                    if (board[i, j].playerHere == true)
                    {
                        board[i, j].symbol = "@";
                        board[i, j].color = ConsoleColor.White;
                    }                                      
                    Console.ForegroundColor = board[i, j].color;
                    Console.Write(board[i, j].symbol);                                      
                }
                Console.WriteLine("");
            }     

       } 
   
    public void placeStairs()
    {
        //Generates stairs' coordinates
            int stairsX = StaticRandom.Instance.Next(0, height - 1);
            int stairsY = StaticRandom.Instance.Next(0, length - 1);

            //While stairs coordinates are on a wall loop with new coordinates
            while(board[stairsX, stairsY].symbol == "#")
            {
                stairsX = StaticRandom.Instance.Next(0, height - 1);
                stairsY = StaticRandom.Instance.Next(0, length - 1);
            }            
            board[stairsX, stairsY].color = ConsoleColor.White;
            board[stairsX, stairsY].stairsHere = true;
            board[stairsX, stairsY].symbol = ">";


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
        public void placeObject(string n, string s)
        {
            //pass in object and symbol or list of possible ascii locations
            
            //Generates player coordinates
            int X = StaticRandom.Instance.Next(0, height - 1);
            int Y = StaticRandom.Instance.Next(0, length - 1);

            //While player coordinates are on a wall or stairs loop with new coordinates
            while (board[X, Y].symbol == "#" || board[X, Y].symbol == ">")
            {
                X = StaticRandom.Instance.Next(0, height - 1);
                Y = StaticRandom.Instance.Next(0, length - 1);

            }

            board[X, Y].color = ConsoleColor.White;
            board[X, Y].playerHere = true;
            board[X, Y].symbol = "@";

        }       
    }
    }


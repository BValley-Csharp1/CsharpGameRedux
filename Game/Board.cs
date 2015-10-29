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

        public Board(int x, int y)
        {
            height = x;
            length = y;

            //Sets the tile to the x and y coordinates
            board = new Tile [x, y];

            //Nested for loops that creates the 2d array of # as a game board
            for (int i = 0; i <= x - 1; i++){
               for (int j = 0; j <= y - 1; j++ ){
                board[i,j] = new Tile ("#", ConsoleColor.DarkMagenta);       
               }
             }
            createRoom();
            placeStairs();
            placePlayer();
        
        }

        //Function used to create a room    
        public void createRoom()
        {
            for (int i = 0; i <= height - 1; i++)
            {
                for (int j = 0; j <= length - 1; j++)
                {
                    if (i > 0 & i < height - 1)
                    {
                        if (j > 0 & j < length - 1)
                            board[i, j].symbol = ".";
                    }
                }
            }
        }
        
        //Showboard method
        public void showBoard()
        {
            for (int i = 0; i <= height - 1; i++)
            {
                for (int j = 0; j <= length - 1; j++)
                {
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
    public void placePlayer()
    {
        //Generates player coordinates
        int playerX = StaticRandom.Instance.Next(0, height - 1);
        int playerY = StaticRandom.Instance.Next(0,length - 1);

        //While player coordinates are on a wall or stairs loop with new coordinates
        while (board[playerX, playerY].symbol == "#" || board[playerX, playerY].symbol == ">")
        {
            playerX = StaticRandom.Instance.Next(0, height - 1);
            playerY = StaticRandom.Instance.Next(0, length - 1);

        }

        board[playerX, playerY].color = ConsoleColor.White;
        board[playerX, playerY].playerHere = true;
        board[playerX, playerY].symbol = "@";

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


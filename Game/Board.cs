using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace Game
{
    class Board
    {
        public Tile[,] board;
        int height;
        int length;
        int i;
        int j;

        //List used for center of room to place island bar
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
                    board[i,j] = new Tile ("#",ConsoleColor.Blue, true);
                    board[i, j].isPassable = false;
                }
             }
            
            //Creates the room and sets the bar
            if (checkRoom(1, 1, 17, 37))
            {
                createRoom(1, 1, 17, 37);
            }
            //Loop for creating a pool table
            for (int index = 0; index < 1; index++)
            {
                int poolx = StaticRandom.Instance.Next(2, height - 3);
                int pooly = StaticRandom.Instance.Next(2, length - 3);
                int poolh = 2;
                int pooll = 3;

                //Creates the pool table if coordinates are available.
                if (checkBar(poolx + 2, pooly + 2, poolh + 2, pooll + 2))
                {
                    createPoolTable(poolx, pooly, poolh, pooll);
                }
                else
                {
                    index--;
                }
            }
            if (checkBar(2, 3, 2, 8))
            {
                createBar(2, 3, 2, 8);
            }           

            //For loop to generate 4 tables randomly
            for (int index = 0; index <= 4; index++)
            {
                int tablex = StaticRandom.Instance.Next(3, height - 2);
                int tabley = StaticRandom.Instance.Next(3, length - 2);
                if (checkTable(tablex, tabley, 1, 3))
                {
                    createTable(tablex, tabley, 1, 3);
                }
                else
                {
                    index--;
                }
            }           

            //createIsland(11, 11, 3, 7);

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
                    if (board[i, j].originalSymbol != "#")
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
                  board[i, j].originalSymbol = ".";
                  board[i, j].isPassable = true;
                  board[i, j].isOccupied = false;
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
                    //Checks if its not in a room
                    if (board[i, j].originalSymbol != "." )
                    {
                        return false;
                    }
                    if (board[i, j].isOccupied == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void createBar(int x, int y, int h, int l)
        {
            int origX = x;

            //Loop for creating a bar in desired area and width and height.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    if (i == origX)
                    {
                        //Checks for specific row and places the bar by that and the stools by that.
                        board[i, j].originalColor = ConsoleColor.Yellow;
                        board[i, j].isPassable = false;
                        board[i, j].originalSymbol = "░";
                        board[i, j].isOccupied = true;
                        board[i, j].isBar = true;
                    }
                    else
                    {
                        board[i, j].originalColor = ConsoleColor.White;
                        board[i, j].isPassable = true;
                        board[i, j].originalSymbol = "o";
                        board[i, j].isOccupied = true;
                        board[i, j].isBar = true;                        
                    }                   
                }
            }
        }
        public void createPoolTable(int x, int y, int h, int l)
        {
            int origX = x;
            int origY = y;

            //Loop for creating a pool table in desired area and width and height.
            for (i = x; i < x + h; i++) {

               for (j = y; j < y + l; j++)
                {                    
                   board[i, j].originalColor = ConsoleColor.DarkGreen;
                   board[i, j].originalSymbol = "█";
                   board[i, j].isPassable = false;                        
                   board[i, j].isOccupied = true;                    
                }
            }           

        }
        public bool checkTable(int x, int y, int h, int l)
        {
            //Loop starts at x and y coordinate to only loop through potential table
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
                    if (board[i, j].originalSymbol != ".")
                    {
                        return false;
                    }

                    //Checks if it's occupied
                    if (board[i, j].isOccupied == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void createTable(int x, int y, int h, int l)
        {
            int origY = y;

            //Loop for creating a table within the set height and width.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    if (j == origY || j == origY + 2)
                    {
                        //Creates seats at the table 
                        board[i, j].originalColor = ConsoleColor.White;
                        board[i, j].isPassable = true;
                        board[i, j].isOccupied = true;
                        board[i, j].originalSymbol = "o";
                    }
                    else
                    {
                        //Creates the table
                        board[i, j].originalColor = ConsoleColor.Yellow;
                        board[i, j].isPassable = false;
                        board[i, j].isOccupied = true;
                        board[i, j].originalSymbol = "░";
                    }                
                }
            }          
        }

        //Showboard function
        public void showBoard()
        {
            for (int i = 0; i <= height - 1; i++)
            {
                for (int j = 0; j <= length - 1; j++)
                {
                    Console.ForegroundColor = board[i, j].originalColor;
                    //Checks if player or npc are temporarily on the current spot 
                    if (board[i, j].playerHere == true || board[i, j].npcHere == true)
                    {
                        
                        if (board[i, j].playerHere == true)
                        {
                            board[i, j].symbol = "@";
                            board[i, j].color = ConsoleColor.White;
                            Console.ForegroundColor = board[i, j].color;
                            Console.Write(board[i, j].symbol);
                        }
                        if (board[i, j].npcHere == true)
                        {
                            board[i, j].symbol = "☻";
                            board[i, j].color = ConsoleColor.Red;
                            Console.ForegroundColor = board[i, j].color;
                            Console.Write(board[i, j].symbol);
                        }                        
                    } 
                    //Otherwise, display the normal symbol.                   
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
        while (board[playerX, playerY].originalSymbol == "#" || board[playerX, playerY].isOccupied == true || board[playerX, playerY].npcHere == true)
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

        //Function used for placing npcs
        public void placeNPC(List<NPC> npcs)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                npcs[i].coordX = StaticRandom.Instance.Next(3, height - 2);
                npcs[i].coordY = StaticRandom.Instance.Next(3, length - 2);

                //Loop with new coordinates while it is occupied.
                while (board[npcs[i].coordX, npcs[i].coordY].isOccupied)
                {
                    npcs[i].coordX = StaticRandom.Instance.Next(3, height - 2);
                    npcs[i].coordY = StaticRandom.Instance.Next(3, length - 2);

                }
                //For each npc in list, give them a location and a destination.                
                board[npcs[i].coordX, npcs[i].coordY].npcHere = true;
                npcs[i].destinationX = StaticRandom.Instance.Next(1, height - 2);
                npcs[i].destinationY = StaticRandom.Instance.Next(1, length - 2);
                npcs[i].destination = true;
            }

        }

        public void createIsland(int x, int y, int h, int l)
        {
            int mpX = h / 2 + x;
            int mpY = l / 2 + y;

            //For loop that creates the eye
            for (i = x; i < x + h; i++)
            {
                if (i == x || i == h)
                {
                    for (j = y + 2; j < y + l - 2; j++)
                    {
                        board[i, j].color = ConsoleColor.Red;
                        board[i, j].originalSymbol = "#";
                    }
                }
                else
                {
                    for (j = y; j < y + l; j++)
                    {                        
                        board[i, j].color = ConsoleColor.Red;
                        board[i, j].originalSymbol = "#";
                    }
                }
            }
            //For loop sets the middle of the island
            for (i = mpX - 1; i <= h; i++)
            {
                board[i, mpY].originalSymbol = " ";
            }            
        }
    }
  }




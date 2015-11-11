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

        //Used for NPC movement
        List<int[]> barStools = new List<int[]>();
        List<int[]> poolTable = new List<int[]>();
        List<int[]> tables = new List<int[]>();

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
            int roomh = 17;
            int roomy = 1;
            int rooml = 37;

            if (checkRoom(roomx, roomy, roomh, rooml))
            {
                createRoom(roomx, roomy, roomh, rooml);
            }
            
            for (int index = 0; index < 1; index++)
            {
                int barx = StaticRandom.Instance.Next(1, height - 1);                
                int bary = StaticRandom.Instance.Next(1, height - 1);
                int barh = 1;
                int barl = StaticRandom.Instance.Next(5, 15);
                
                //Eventually add a roll for 
                if (checkBar(barx, bary, barh, barl))
                {
                    createBar(barx, bary, barh, barl);

                }              
                else
                {
                    index--;
                }
            }

            for (int index = 0; index < 1; index++)
            {
                int poolx = StaticRandom.Instance.Next(1, height - 1);                
                int pooly = StaticRandom.Instance.Next(1, height - 1);
                int poolh = 1;
                int pooll = 4;

                //Decides if the pool table will be vertical or horizontal
                int roll = StaticRandom.Instance.Next(1, 6);
                if (roll < 4)
                {
                    int temp = poolh;
                    poolh = 2;
                    pooll = 2;

                }
                //Creates the pool table if coordinates are available.
                if (checkBar(poolx, pooly, poolh, pooll))
                {
                    createPoolTable(poolx, pooly, poolh, pooll);

                }
                else
                {
                    index--;
                }
            }

            //For loop to generate a 4 tables randomly
            for (int index = 0; index <= 4; index++)
            {
                int tablex = StaticRandom.Instance.Next(1, height - 1);
                int tabley = StaticRandom.Instance.Next(1, height - 1);
                if (checkTable(tablex, tabley, 1, 1))
                {
                    createTable(tablex, tabley, 1, 1);
                }
                else
                {
                    index--;
                }
            }           
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
            //Loop for creating a bar in desired area and width and height.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    //Checks for specific row and places the bar by that and the stools by that.
                    board[i, j].originalColor = ConsoleColor.Yellow;
                    board[i, j].isPassable = false;
                    board[i, j].originalSymbol = "░";
                    board[i, j].isOccupied = true;

                    board[i + 1, j].originalColor = ConsoleColor.White;
                    board[i + 1, j].isPassable = true;
                    board[i + 1, j].originalSymbol = "o";
                    board[i + 1, j].isOccupied = true;

                    //Adds bar stools to list for NPC movement
                    barStools.Add(new int[] { i + 1, j });
                }
            }
            

        }
        public void createPoolTable(int x, int y, int h, int l)
        {
            //Sets the midpoint for the pool table
            int mpX = h / 2 + x;
            int mpY = l / 2 + y;

            //Loop for creating a pool table in desired area and width and height.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    board[i, j].originalColor = ConsoleColor.DarkGreen;
                    board[i, j].isPassable = false;
                    board[i, j].originalSymbol = "█";
                    board[i, j].isOccupied = true;

                    //Adds table coordinates for NPC movement
                    poolTable.Add(new int[] { i, j });
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
            //Sets the midpoint for the table
            int mpX = h / 2 + x;
            int mpY = l / 2 + y;

            //Loop for creating a table within the set height and width.
            for (i = x; i < x + h; i++)
            {
                for (j = y; j < y + l; j++)
                {
                    board[i, j].originalColor = ConsoleColor.Yellow;
                    board[i, j].isPassable = false;
                    board[i, j].originalSymbol = "░";

                    //Creates seats at the table 
                    board[i, j + 1].originalColor = ConsoleColor.White;
                    board[i, j + 1].isPassable = true;
                    board[i, j + 1].originalSymbol = "o";                    
                    board[i, j - 1].originalColor = ConsoleColor.White;
                    board[i, j - 1].isPassable = true;
                    board[i, j - 1].originalSymbol = "o";

                    //Adds seats to the list for NPC movement
                    tables.Add(new int[] { i, j + 1 });
                    tables.Add(new int[] { i, j - 1});
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
        while (board[playerX, playerY].symbol == "#" || board[playerX, playerY].isOccupied == true)
        {
            playerX = StaticRandom.Instance.Next(0, height - 1);
            playerY = StaticRandom.Instance.Next(0, length - 1);

        }
        board[playerX, playerY].playerHere = true;
        board[playerX, playerY].symbol = "@";

        //Sets player location to player.
        player.coordY = playerY;
        player.coordX = playerX;
        //if its a person, don't set original symbol. if we want them to move, otherwise it wont matter

            return player;

        }
        public void placeObject(string objectToPlace, string symbol, ConsoleColor color, bool passable)
        {         
            //Generates coordinates
            int X = StaticRandom.Instance.Next(0, height - 1);
            int Y = StaticRandom.Instance.Next(0, length - 1);

            //While player coordinates are occupied or a wall, create new coordinates
            while (board[X, Y].isOccupied == true || board[X,Y].symbol == "#")
            {
                X = StaticRandom.Instance.Next(0, height - 1);
                Y = StaticRandom.Instance.Next(0, length - 1);

            }
            //Sets tile properties for object
            board[X, Y].isPassable = passable;
            board[X, Y].isOccupied = true;
            board[X, Y].originalColor = color;
            board[X, Y].originalSymbol = symbol;

        }
        //Will use variation for NPC movement, have yet to modify
        public void createCorridors()
        {
            //Loop that runs for the length of array
            for (int index = 1; index < midpoints.Count; index++)
            {
                //Sets the x and y coordinates together in an array
                int[] m1 = midpoints[index - 1];
                int[] m2 = midpoints[index];

                //Set coordinates to specific variables
                int x1 = m1[0];
                int y1 = m1[1];
                int x2 = m2[0];
                int y2 = m2[1];

                //If statement X Coordinate
                if (x1 > x2)
                {
                    //For loop that writes the X axis corridor
                    for (i = x1; i > x2; i--)
                    {
                        board[i, y1].color = ConsoleColor.White;
                        board[i, y1].symbol = "."; 
                    }
                }
                else if (x1 <= x2)
                {
                    for (i = x1; i < x2; i++)
                    {
                        board[i, y1].color = ConsoleColor.White;
                        board[i, y1].symbol = ".";
                        }
                    }
                }
                //If statement for Y coordinate
                if (y1 > y2)
                {
                    //For loop that creates the Y axis corridor
                    for (j = y1; j > y2; j--)
                    {
                        board[i, j].color = ConsoleColor.White;
                        board[i, j].symbol = ".";
                        }
                    }
                }
                else if (y1 <= y2)
                {
                    for (j = y1; j < y2; j++)
                    {
                        board[i, j].color = ConsoleColor.White;
                        board[i, j].symbol = ".";
                        }
                    }
                }
            }

        }
    }
    }



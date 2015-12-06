using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Movement
    {
        public static void playerMove(int x, int y, Board b, Player p, int bac, int steps, NPC npc)
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
                    //If player runs into an npc, start the conversation
                    if (b.board[x - 1, y].npcHere)
                    {
                        npc.talk();
                        Console.ReadKey();
                    }
                    //Makes sure the player can go where it intends to
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
                    if (b.board[x + 1, y].npcHere)
                    {
                        npc.talk();
                        Console.ReadKey();
                    }
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
                    if (b.board[x, y + 1].npcHere)
                    {
                        npc.talk();
                        Console.ReadKey();
                    }
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
                    if (b.board[x, y - 1].npcHere)
                    {
                        npc.talk();
                        Console.ReadKey();
                    }
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

        public static void npcMove(Board b, NPC npc)
        {
            //Moves npcs on the X axis
            if (npc.coordX > npc.destinationX)
            {
                //If npc comes into contact with something that cannot be passed, sets flag to get new route
                if (b.board[npc.coordX - 1, npc.coordY].isPassable)
                {
                    b.board[npc.coordX, npc.coordY].npcHere = false;
                    b.board[npc.coordX, npc.coordY].isPassable = true;
                    npc.coordX -= 1;
                    b.board[npc.coordX, npc.coordY].npcHere = true;
                    b.board[npc.coordX, npc.coordY].isPassable = false;
                }
                else
                {
                    npc.destination = false;
                }
            }
            else if (npc.coordX < npc.destinationX)
            {
                if (b.board[npc.coordX + 1, npc.coordY].isPassable)
                {
                    b.board[npc.coordX, npc.coordY].npcHere = false;
                    b.board[npc.coordX, npc.coordY].isPassable = true;
                    npc.coordX += 1;
                    b.board[npc.coordX, npc.coordY].npcHere = true;
                    b.board[npc.coordX, npc.coordY].isPassable = false;
                }
                else
                {
                    npc.destination = false;
                }

            }
            //Once it is on it's X axis, move to the destination Y
            if (npc.coordX == npc.destinationX)
            {
                if (npc.coordY < npc.destinationY)
                {
                    if (b.board[npc.coordX, npc.coordY + 1].isPassable)
                    {
                        b.board[npc.coordX, npc.coordY].npcHere = false;
                        b.board[npc.coordX, npc.coordY].isPassable = true;
                        npc.coordY += 1;
                        b.board[npc.coordX, npc.coordY].npcHere = true;
                        b.board[npc.coordX, npc.coordY].isPassable = false;
                    }
                    else
                    {
                        npc.destination = false;
                    }
                }
                else if (npc.coordY > npc.destinationY)
                {
                    if (b.board[npc.coordX, npc.coordY - 1].isPassable)
                    {
                        b.board[npc.coordX, npc.coordY].npcHere = false;
                        b.board[npc.coordX, npc.coordY].isPassable = true;
                        npc.coordY -= 1;
                        b.board[npc.coordX, npc.coordY].npcHere = true;
                        b.board[npc.coordX, npc.coordY].isPassable = false;
                    }
                    else
                    {
                        npc.destination = false;
                    }
                }

                //Once it has reached it's destination set it to false to receive a new destination
                if (npc.coordY == npc.destinationY)
                {
                    npc.destination = false;
                }
            }
        }
        }
}

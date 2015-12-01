using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Tile
    {
        public string symbol{ get; set;}
        public string originalSymbol { get; set; }

        public ConsoleColor color { get; set; }
        public ConsoleColor originalColor { get; set; }

        //Used to keep track of player's location on the board
        public bool playerHere { get; set; }

        //Used for setting elements within the bar
        public bool isOccupied { get; set; }

        //Checks to see if player can move past the tile
        public bool isPassable { get; set; }

        //Used for ordering drinks
        public bool isBar { get; set; }

        //Constructor for tile class
        public Tile(string os, ConsoleColor oc, bool occp)
        {
            //symbol = s;
            originalSymbol = os;
            //color = c;
            originalColor = oc;
            isOccupied = occp;
        }
        
    }
}

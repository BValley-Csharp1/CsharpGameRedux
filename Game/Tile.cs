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
        public ConsoleColor color { get; set; }
        public bool playerHere { get; set; }
        public bool stairsHere { get; set; }
        //Checks to see if player can move past the tile
        public bool isPassable { get; set; }
        
        //Constructor for tile class
        public Tile(string s , ConsoleColor c)
        {
            symbol = s;
            color = c;
        }
        
    }
}

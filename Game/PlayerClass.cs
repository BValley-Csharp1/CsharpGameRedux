using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        public int coordY;
        public int coordX;
        int aggression;
        int moxie;
        int humor;
        public Player(int c_class)
        {
            if (c_class == 1)
            { // Fighter
                aggression = 9;
                moxie = 3;
                humor = 5;
            }
            else if (c_class == 2)
            { // Frat
                aggression = 9;
                moxie = 5;
                humor = 3;
            }
            else if (c_class == 3)
            { // Lover
                aggression = 3;
                moxie = 9;
                humor = 5;
            }
            else if (c_class == 4)
            { // Gentleman
                aggression = 5;
                moxie = 9;
                humor = 3;
            }
            else if (c_class == 5)
            { // Joker
                aggression = 3;
                moxie = 5;
                humor = 9;
            }
            else if (c_class == 6)
            { // Klutz
                aggression = 5;
                moxie = 3;
                humor = 9;
            }

        }
       
       
    }
}

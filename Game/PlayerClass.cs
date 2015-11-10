using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        int moxie;
        int aggression;
        int humor;
        public enum charclass
        {
            fighter, frat, lover, gentleman, joker, klutz
        }
        public Player(int c_class)
        {
            charclass playerClass = new charclass();
            
            case (c_class == 1):
                playerClass = charclass.fighter;
                break;

            case (c_class == 2):
                playerClass = charclass.frat;
                break;
            case (c_class == 3):
                playerClass = charclass.lover;
                break;
            case (c_class == 4):
                playerClass = charclass.gentleman;
                break;
            case (c_class == 5):
                playerClass = charclass.joker;
                break;
            case (c_class == 6):
                playerClass = charclass.klutz;
                break;

        }
       
    }
}

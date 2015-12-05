using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NPC
    {
        //Used for tracking player location
        public int coordY;
        public int coordX;

        //Used for NPC Movement
        public int destinationX;
        public int destinationY;        
        public bool destination = false;

        public string name;
        int aggression, moxie, humor;
        /* TODO
         * finish base NPC
         * make sub NPC types
         * have sub NPCs have a list of possible sayings
         * fixate sayings per playthrough
         * implement 2 of each sub NPCs in genNPC
         */
        public NPC(string n, int a = 5, int m = 5, int h = 5)
        {
            name = n;
            aggression = a;
            moxie = m;
            humor = h;
        }
        
        public virtual void talk()
        {
            Console.Write("HI!");
            Console.WriteLine("1. Scrapper \n" +
                              "2. Frat \n" +
                              "3. Lover \n" +
                              "4. Gentleman \n" +
                              "5. Joker \n" +
                              "6. Klutz");
        }
        public bool aggressionTest(int a)
        {
            if (aggression > a)
                return false;
            else
                return true;
        }
        public bool moxieTest(int m)
        {
            if (moxie > m)
                return false;
            else
                return true;
        }
        public bool humorTest(int h)
        {
            if (humor > h)
                return false;
            else
                return true;
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NPC
    {
        //Used for NPC Movement (LOUIS: Feel free to move wherever you find neccesary, I'm just testing. )
        public int[] destination = new int[2];

        string name;
        int aggression, moxie, humor;
        public NPC(string n, int a = 5, int m = 5, int h = 5)
        {
            name = n;
            aggression = a;
            moxie = m;
            humor = h;
        }
        public void talk()
        {
            Console.Write("HI!");
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

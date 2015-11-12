using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NPC
    {
        string name;
        
        /* TODO
         * finish base NPC
         * make sub NPC types
         * have sub NPCs have a list of possible sayings
         * fixate sayings per playthrough
         * implement 2 of each sub NPCs in genNPC
         */
        public NPC(string n)
        {
            name = n;
        }
        public void talk()
        {
            Console.Write("HI!")
        }
    }
}

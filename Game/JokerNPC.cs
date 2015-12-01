using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class JokerNPC:NPC
    {
        public JokerNPC(string name, int a=3, int m=5, int h=9)
            : base(name, a, m, h)
        {
            
        }
        public void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("Hey, hey, pull my finger");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class FratNPC : NPC
    {
        public FratNPC(string name, int a=9, int m=5, int h=3)
            : base(name, a, m, h)
        {
            
        }
        public override void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("Breh, wat cha want");
            phrases.Add("Breh, wanna help me with this keg?");
            phrases.Add("Breh, check out my bedsh- I mean toga");
            Console.Write(phrases[StaticRandom.Instance.Next(1, phrases.Count - 1)]);
        }
    }
}

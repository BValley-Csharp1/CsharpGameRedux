using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ScrapperNPC:NPC
    {
        public ScrapperNPC(string name, int a=9, int m=3, int h=5)
            : base(name, a, m, h)
        {
            
        }
        public override void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("Hey. Heard you talkin' shit"); // Might need to remove profanity
            Console.Write(phrases[StaticRandom.Instance.Next(1, phrases.Count - 1)]);

        }
    }
}

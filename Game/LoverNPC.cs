using System;
using System.Collections.Generic;

namespace Game
{
    class LoverNPC : NPC
    {
        public LoverNPC(string name, int a = 3, int m = 9, int h = 5)
            : base(name, a, m, h)
        {

        }
        public override void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("Bonjour, mon ami");
            Console.Write(phrases[StaticRandom.Instance.Next(1, phrases.Count - 1)]);

        }
    }
}

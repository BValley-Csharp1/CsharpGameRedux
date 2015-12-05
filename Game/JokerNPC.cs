using System;
using System.Collections.Generic;

namespace Game
{
    class JokerNPC : NPC
    {
        public JokerNPC(string name, int a = 3, int m = 5, int h = 9)
            : base(name, a, m, h)
        {

        }
        public override void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("Hey, hey, pull my finger");
            Console.Write(phrases[StaticRandom.Instance.Next(1, phrases.Count - 1)]);

        }
    }
}

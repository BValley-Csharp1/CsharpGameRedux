using System;
using System.Collections.Generic;

namespace Game
{
    class KlutzNPC : NPC
    {
        public KlutzNPC(string name, int a = 5, int m = 3, int h = 9)
            : base(name, a, m, h)
        {

        }
        public override void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("*stumbles*");
            Console.Write(phrases[StaticRandom.Instance.Next(0, phrases.Count - 1)]);
            Console.ReadKey();

        }
    }
}

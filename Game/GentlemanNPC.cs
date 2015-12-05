using System;
using System.Collections.Generic;

namespace Game
{
    class GentlemanNPC : NPC
    {
        public GentlemanNPC(string name, int a = 5, int m = 9, int h = 3)
            : base(name, a, m, h)
        {

        }
        public override void talk()
        {
            List<string> phrases = new List<string>();
            phrases.Add("Greetings, good sir or madame");
            Console.Write(phrases[StaticRandom.Instance.Next(0, phrases.Count - 1)]);
            Console.ReadKey();

        }
    }
}

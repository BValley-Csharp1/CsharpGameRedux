using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class generateNPC
    {
        List<NPC> characters = new List<NPC>();

        public generateNPC()
        {
            //male
            characters.Add(new ScrapperNPC("Butch"));
            characters.Add(new FratNPC("Broseph"));
            characters.Add(new GentlemanNPC("Smith"));
            characters.Add(new LoverNPC("Rico"));
            characters.Add(new KlutzNPC("Malcolm"));
            characters.Add(new JokerNPC("Andrew"));

            //female
            characters.Add(new ScrapperNPC("Rachel"));
            characters.Add(new FratNPC("Amanda"));
            characters.Add(new GentlemanNPC("Sophia"));
            characters.Add(new LoverNPC("Sasha"));
            characters.Add(new KlutzNPC("Rebecca"));
            characters.Add(new JokerNPC("Tina"));


        }

        public NPC getNPC()
        {
            return characters[StaticRandom.Instance.Next(1, characters.Count - 1)];
        }
    }
}

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

        public generateNPC(){
            characters.Add(new NPC("Steve"));
            characters.Add(new NPC("Joe"));
            characters.Add(new NPC("Sarah"));

        }

        public NPC getNPC()
        {
            return characters[StaticRandom.Instance.Next(1, characters.Count - 1)];
        }
    }
}

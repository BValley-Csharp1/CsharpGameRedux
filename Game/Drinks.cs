using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Drinks
    {
        int aggression, moxie, humor;
        public int Aggression {get; set;}
        public int Moxie { get; set; }
        public int Humor { get; set; }
        public Drinks()
        {
            
        }

        public Drinks(int aggression, int moxie, int humor)
        {
            this.aggression = aggression;
            this.moxie = moxie;
            this.humor = humor;
        }

        public void beer(int aggression, int moxie, int humor)
        {
            
            aggression = (aggression + 1);
            moxie = (moxie + 1);
            humor = (humor + 1);
            Aggression = aggression;
            Moxie = moxie;
            Humor = humor;

        }
        public void rumcoke(int humor)
        {
            humor = (humor + 1);
            Humor = humor;
        }
        public void screwdriver(int[] stats)
        {
            aggression = (stats[0] + (1));
            Aggression = aggression;
        }
        public void wine(int moxie)
        {
            moxie = (moxie + 1);
            Moxie = moxie;
        }
        public void whiskey(int aggression)
        {
            aggression = (aggression + 2);
            Aggression = aggression;
        }
        public void gintonic(int moxie)
        {
            moxie = moxie + 2;
            Moxie = moxie;
        }
        public void longislandtea(int humor)
        {
            humor = humor + 2;
            Humor = humor;
        }
    }
}

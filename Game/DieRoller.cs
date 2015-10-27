using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    //dieRoller class containing targetRoll and totalRoll methods
    public static class DieRoller
    {
        //Target roll method for passing the 3d6 style die roll with a target num to beat
        public static int targetRoll(int dieNum, int sideNum, int target)
        {
            int roll = 0;
            int targetBeat = 0;

            //For loop that rolls however many die for the inserted range.
            for (int index = 1; index <= dieNum; index++)
            {
                roll = StaticRandom.Instance.Next(1, sideNum);
                if (roll >= target)
                {
                    targetBeat++;
                }
            }
            return targetBeat;
        }

        //Total roll method for passing a die roll in 3d6 type format 
        public static int totalRoll(int dieNum, int sideNum)
        {

            int total = 0;
            //For loop that rolls however many die for the inserted range.
            for (int index = 1; index <= dieNum; index++)
            {
                total += StaticRandom.Instance.Next(1, sideNum);
            }
            return total;
        }
    }

}
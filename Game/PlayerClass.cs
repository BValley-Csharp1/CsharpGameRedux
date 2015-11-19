using System;
using System.Collections.Generic;

namespace Game
{
    class Player
    {
        //Used for tracking player location
        public int coordY;
        public int coordX;

        public int aggression; // Stats
        public int moxie;
        public int humor;
        int bac { get; set; }
        List<int> evidence = new List<int>();
        public Player(int c)
        {
            determineClass(c);
        }

        public void determineClass(int c_class)
        {
            if (c_class == 1)
            { // Scrapper
                aggression = 9;
                moxie = 3;
                humor = 5;
            }
            else if (c_class == 2)
            { // Frat
                aggression = 9;
                moxie = 5;
                humor = 3;
            }
            else if (c_class == 3)
            { // Lover
                aggression = 3;
                moxie = 9;
                humor = 5;
            }
            else if (c_class == 4)
            { // Gentleman
                aggression = 5;
                moxie = 9;
                humor = 3;
            }
            else if (c_class == 5)
            { // Joker
                aggression = 3;
                moxie = 5;
                humor = 9;
            }
            else if (c_class == 6)
            { // Klutz
                aggression = 5;
                moxie = 3;
                humor = 9;
            }
        }
        public void chooseDrink(int d)
        {

            Drinks drink = new Drinks(aggression, moxie, humor);
            if (d == 1)
            {
                drink.beer(aggression, moxie, humor);
                aggression = drink.Aggression;
                moxie = drink.Moxie;
                humor = drink.Humor;
                Console.ResetColor();
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
            if (d == 2)
            {
                drink.rumcoke(humor);
                humor = drink.Humor;
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
            if (d == 3)
            {
                drink.screwdriver(aggression);
                aggression = drink.Aggression;
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
            if (d == 4)
            {
                drink.whine(moxie);
                moxie = drink.Moxie;
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
            if (d == 5)
            {
                drink.whiskey(aggression);
                aggression = drink.Aggression;
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
            if (d == 6)
            {
                drink.gintonic(moxie);
                moxie = drink.Moxie;
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
            if (d == 7)
            {
                drink.longislandtea(humor);
                humor = drink.Humor;
                Console.WriteLine("Aggression:" + aggression);
                Console.WriteLine("Moxie:" + moxie);
                Console.WriteLine("Humor:" + humor);
            }
        }
    }
}

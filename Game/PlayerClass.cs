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
        public int[] mods = new int[3];

        public int bac { get; set; }
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
        public void chooseDrink()
        {
            int d;
            string number;
            Console.WriteLine("Choose a drink:");
            Console.WriteLine("1. Beer \n" +
                              "2. RumCoke \n" +
                              "3. Screwdriver \n" +
                              "4. Wine \n" +
                              "5. Whiskey \n" +
                               "6. Gin Tonic \n" +
                              "7. Long Island Tea \n" +
                              "Press Esc to exit.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            number = Console.ReadKey().KeyChar.ToString();
            try { d = int.Parse(number); }
            catch (FormatException e) { d = 0; }


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
                drink.wine(moxie);
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
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        string name;
        string history;
        // TEST
        public Player()
        {
            //Loop for selecting desired player.
            string userInput = "";
            while (userInput != "Y")
            {
                Console.Clear();
                name = generateName();
                history = generateHistory();
                Console.WriteLine(name);
                Console.WriteLine(history);
                Console.WriteLine("Do you accept this character? (Y/N)");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
            }

        }
        //Get methods for player name and history
        public string getName() { return name; }
        public string getHistory() { return history; }

        private string generateName()
        {
            //Name prefixes and suffixes 
            string[] prefixes = new string[] { "Joe", "Ste", "Dak", "Lea", "Tod", "Sam", "Kev", "Ada", "Nic", "Chr", "Rya", "Mir", "Mor", "Jac", "Han", "Pey", "Wil", "Ash", "Rus", "Lau", "Ara", "Lex", "Ale", "Fro", "Pip", "Sea" };
            string[] suffixes = new string[] { "el", "phen", "ota", "dra", "lan", "ara", "in", "am", "las", "is", "an", "da", "gan", "kie", "nah", "ton", "iam", "ton", "sell", "ren", "gorn", "thor", "der", "ron", "gee", "ven" };

            string[] titles = new string[] { "Canadian", "Hobglobin", "Pathological Liar", "Unicyclist", "Art Critic", "Taxidermist", "Keebler Elf", "Gorgonzolla Thief", "Gremlin", "Elvis Impersonator", "Belieber", "Ramones Number One Fan" };
            //Select random items from arrays
            string prefix = prefixes[StaticRandom.Instance.Next(0, prefixes.Length - 1)];
            string suffix = suffixes[StaticRandom.Instance.Next(0, suffixes.Length - 1)];
            string title = titles[StaticRandom.Instance.Next(0, titles.Length - 1)];

            //Returns the concactenated name
            return prefix + suffix + " The " + title;
        }
        private string generateHistory()
        {
            //History information
            string[] backgrounds = new string[] { "\nYou infamously dated Richard Simmons. Sadly, he broke up with you...ouch.", "\nYou attended Mordor University, where one does not simply walk in.", "\nYou were infamously involved in The Great Elf Massacre of '97.", "\nYou grew up in The Shire. Like a boss.", "\nYou are among the few who've survived the lawless, post-apocalyptic world of a mosh pit.", "\nYou come from a long line of Hop Scotch World Championship holders", "\nYou are distantly related to the guy who invented Lucky Charms.", "\nYou grew up believing Yoda was \"The Man\"" };
            string[] jobs = new string[] { "most well known for your job as the Uruk-hai's makeup artist...Mordor appauds you for your services.", " currenly single and unemployed, but enjoys long walks on the beach and pina colodas while getting caught in the rain.", " doing just fine as a perfectly adequate hallmark card writer", " working at the local kiosk selling body soaps", " currently studying the ancient arts of sarcasm with a minor in needlework.", " working part-time as a boy band music video choreographer.", " watching your life fade away through the imprisonment of your title as \"The Mayor of Munchkin Land\"", " just waiting for your rap career to take off." };
            string[] extras = new string[] { " you're pretty much the epitome of failure", " you should keep up the good work!", " you can sing The Bee Gee's \"Stayin' Alive\" like a champ!", " your dance moves put Taylor Swift to shame", " you're always sipping that haterade", " you have some unresolved anger issues.", " you're a frequent guest on Oprah", " you've got a terrible drinking problem." };

            //Connecting phrases
            string[] phrases = new string[] { "\n\nWith high hopes and ambitions you're", "\n\nDue to the struggling economy you're", "\n\nAll because of Nicholas Cage you're", "\n\nBecause you fed a Grimlin after midnight you're", "\n\nAfter your failed jail break you're", "\n\nAfter a long, intense discussion with your self you've decided that you're", "\n\nAfter realizing you're not as good at karaoke as you thought you're", "\n\nAfter a long, unsuccessful career as a pastry chef you're" };
            string[] phrases2 = new string[] { "\n\nNeedless to say", "\n\nYour past mistakes constantly remind you that", "\n\nIn the end,", "\n\nTo put it nicely,", "\n\nThe haters won't let you forget", "\n\nI guess you could say", };

            //Selects a random item from each array
            string background = backgrounds[StaticRandom.Instance.Next(0, backgrounds.Length - 1)];
            string job = jobs[StaticRandom.Instance.Next(0, jobs.Length - 1)];
            string extra = extras[StaticRandom.Instance.Next(0, extras.Length - 1)];
            string phrase = phrases[StaticRandom.Instance.Next(0, phrases.Length - 1)];
            string phrase2 = phrases2[StaticRandom.Instance.Next(0, phrases2.Length - 1)];

            //returns the concatenated history of player
            return background + phrase + job + phrase2 + extra;
        }
       
    }

}

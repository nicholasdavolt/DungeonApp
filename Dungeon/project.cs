using CYRLibrary;
using System.Data;
using System.Threading.Tasks.Sources;

namespace Dungeon
{
    internal class project
    {
        static void Main(string[] args)
        {
            #region ASCII ART and homescreen
            Console.WriteLine(@"       )
         ( _   _._
          |_|-'_~_`-._
       _.-'-_~_-~_-~-_`-._
   _.-'_~-_~-_-~-_~_~-_~-_`-._
  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    |  []  []   []   []  [] |
jgs |           __    ___   |
  ._|  []  []  | .|  [___]  |_._._._._._._._._._._._._._._._._.
  |=|________()|__|()_______|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|
^^^^^^^^^^^^^^^ === ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    _______      ===
   <_Centriq_>       ===
      ^|^             ===
       |     ");

            Console.WriteLine("YOU MUST CLEAN YOUR HOUSE!!!!\n" +
                "Press any key to begin.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Game Intro
            Console.WriteLine("As you awake to another beautiful morning at Centriq, you check your calendar to realise it's Parent's day!\n" +
                "Your house is mess, and if your parents see you living in this squalor you are sure that you will lose the weekly allowance they have been sending you.\n" +
                "Can you navigate the labyrinthian halls, defeat any creatures that have taken residence, and contend with your roommates to get your house cleaned in time?");
            Console.WriteLine("Press any key to make your character.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Player Creation
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine($"What is your major?\n" +
                $"A. Physical Education\n" +
                $"B. Chemistry\n" +
                $"C. Engineering\n" +
                $"D. Undeclared\n");
            ConsoleKey choice = Console.ReadKey(true).Key;
            Major playerMajor = new Major();

            switch (choice)
            {
                case ConsoleKey.A:
                       playerMajor = Major.Physical_Education;
                    break;
                case ConsoleKey.B:
                    playerMajor = Major.Chemistry;
                    break;
                case ConsoleKey.C:
                    playerMajor = Major.Engineering;
                    break;
                case ConsoleKey.D:
                    playerMajor = Major.Undeclared;
                    break;

                default:
                    Console.WriteLine("Please pick a valid major");
                    break;
            }
            Weapon w1 = new Weapon("Broom", false, 8, 5, 1, 1, WeaponType.Stick);
            Player player = new(playerName, 50, 50, 10, 10, playerMajor, w1);
            Console.Clear ();
            Console.WriteLine("Here is your character:");
            Console.WriteLine(player);
            Console.WriteLine("Press any key to begin your adventure.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            int score = 0;
            bool mainLoop = true; //counter for the main game loop

            do
            {
                Console.WriteLine(GetRoom(score));
                Monster monster = GetMonster();

                Console.WriteLine($"There is a {monster.Name} here.");



                bool innerMenu = true; //counter for inner menu

                do
                {
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A. Attack\n" +
                        "B. Run Away\n" +
                        "C. Character Info\n" +
                        "D. Monster Info\n" +
                        "E. Exit\n");
                    choice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);

                            if (monster.MaxLife <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou defeated {monster.Name}!\n");
                                innerMenu = false;
                                score++;

                            }
                            break;
                        case ConsoleKey.B:
                            Console.WriteLine("Run Away");
                            Combat.DoAttack(monster, player);
                            innerMenu = false;
                            score--;
                            break;
                        case ConsoleKey.C:
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine($"Current Score: {score}");
                            
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Opponent Info");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.Escape:
                        case ConsoleKey.E:
                            Console.WriteLine("Thanks for playing!");
                            mainLoop=false;
                            break;

                        default:
                            Console.WriteLine("Invalid selection, try again");
                            break;
                    }

                    if (player.CurrentLife <= 0)
                    {
                        Console.WriteLine("As you have your final breaths, your only regret is that you spent your last moments cleaning the house.");
                        mainLoop = false;
                    }
                } while (innerMenu && mainLoop);
            } while (mainLoop);
            Console.WriteLine($"Final Score: {score}");
        }
        private static string GetRoom(int score)
        {
            List<string> rooms = new List<string>()
            {
                "YOUR ROOM\nYour room is probably the best in the house, but it is still filthy.", "THE UPSTAIRS HALLWAY\nThe upstairs hallway is dusty and dark, with one flickering overhead light", "UPSTAIRS BATHROOM\n For reasons that will never be explained, someone is brewing a strange liquor in the bathtub.", "STORAGE CLOSET\nThis closet has piles of newspapers and magazines dating back to the 1960's", "GEOF THE TECHNO VIKINGS ROOM!!\nThis room belongs to one of your roommates. There is a strange mix of computer equipment, and ancient artifacts.","STAIRS DOWN\nBe careful of the missing steps!","THE LIVING ROOM.\nThis room is dominated by a large projector screen, and filled with an odd assortment of patio furniture.","DOWNSTAIRS BATHROOM\nWhere once there was a toilet, now there is only a hole.", "BEDROOM\nThis bedroom has seen better days, and is littered with cookbooks and what appears to be alchemical equipment.","THE KTICHEN OF DOOM\nEverything in this kitchen is covered in type 00 flour and mold.","BASEMENT STAIRS\nThese stairs are old and rickety, there is a faint scent rising from the basement.",
            };

            return rooms[score];

        }
        private static  Monster GetMonster()
        {
            Critter m1 = new();
            return m1;
        }
    }
}
using CYRLibrary;
using System.Data;

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
   <_4sale_>       ===
      ^|^             ===
       |     ");

            Console.WriteLine("YOU MUST CLEAN YOUR HOUSE!!!!\n" +
                "Press any key to begin");
            Console.ReadKey();
            Console.Clear();
            #endregion
            //TODO Create a Player

            bool mainLoop = true; //counter for the main game loop

            do
            {
                //TODO Create a Monster
                //TODO Create a Room

                bool innerMenu = true; //counter for inner menu

                do
                {
                    Console.WriteLine("\n\nA. Attack\n" +
                        "B. Run Away\n" +
                        "C. Character Info\n" +
                        "D. Monster Info\n" +
                        "E. Exit\n");
                    string userSelection = Console.ReadLine().ToUpper();
                    Console.Clear();

                    switch (userSelection)
                    {
                        case "A":
                            Console.WriteLine("Attack");
                            //WIN innerMenu = false;
                            //Lose innerMenu = false; && mainLoop = false;
                            break;
                        case "B":
                            Console.WriteLine("Run Away");
                            innerMenu = false;
                            break;
                        case "C":
                            Console.WriteLine("Player Info");
                            //TODO Character Info
                            break;
                        case "D":
                            Console.WriteLine("Opponent Info");
                            //TODO Monster Info
                            break;
                        case "E":
                            Console.WriteLine("Thanks for playing!");
                            innerMenu=false;
                            mainLoop = false;
                            break;

                        default:
                            Console.WriteLine("Invalid selection, try again");
                            break;
                    }
                } while (innerMenu);
            } while (mainLoop);
        }
    }
}
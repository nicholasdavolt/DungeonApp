namespace Dungeon
{
    internal class DungeonMenu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon App");

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
                            Console.WriteLine("Character Info");
                            //TODO Character Info
                            break;
                        case "D":
                            Console.WriteLine("Monster Info");
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
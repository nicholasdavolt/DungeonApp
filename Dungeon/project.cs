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

            //Collects player input to create the starting character
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
            //defines and initialized the starting weapon and character
            Item broom = new Item("Broom",false,"Your trusty broom",8,10,1,1,0,0,0,EquipLocations.hands,true);
            Player player = new(playerName, 50, 50, 5, 3, playerMajor, broom);
            Console.Clear ();
            Console.WriteLine("Here is your character:");
            Console.WriteLine(player);
            Console.WriteLine("Press any key to begin your adventure. Be wary of how gross these rooms can be. Just being in them can hurt you.");
            Console.ReadKey();
            Console.Clear();
            #endregion

            int score = 0;
            bool mainLoop = true; //counter for the main game loop
            List<Item> inventory = new List<Item>();//creates list to be used for the player inventory


            do
            {
                Random rand = new Random();
                int grossOut = rand.Next(0, 4);//assigns rooms gross out factor
                Monster monster;
                if (score < 12)
                {
                    Console.WriteLine(GetRoom(score));//returns a room based on score, or randomly past a score value of 12
                    monster = GetMonster(score);//returns a monster based on the current player score

                    Console.WriteLine($"There is a {monster.Name} here.");
                }
                else
                {
                    Console.WriteLine("You have probably cleaned enough, but there is always more to do.\n" +
                        "Try for a high score!!!");
                    Console.WriteLine(GetRoom(score));
                    monster = GetMonster(score);

                    Console.WriteLine($"There is a {monster.Name} here.");
                }
                

                


                bool innerMenu = true; //counter for inner menu

                do
                {
                    Console.WriteLine($"The current grossout factor is {grossOut}." +
                        $" \nPlease choose an action:\n" +
                        "A. Attack\n" +
                        "R. Run Away\n" +
                        "C. Character Info\n" +
                        "M. Monster Info\n" +
                        "I. Inventory\n" +
                        "E. Exit\n");
                    choice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (choice)
                    {
                        case ConsoleKey.A: //handles one round of combat if the monster health is less than zero it resets the inner menu loop, getting a new room, monster and item
                            Combat.DoBattle(player, monster);
                            player.CurrentLife -= grossOut;
                            

                            if (monster.CurrentLife <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou defeated {monster.Name}!\n");
                                innerMenu = false;
                                score++;
                                Console.ResetColor();
                                if (inventory.Count >= 10)
                                {
                                    Console.WriteLine("Your inventory is full, and you cannot find any more items.");
                                }
                                else
                                {
                                    inventory.Add(GetItem());
                                    Console.WriteLine($"You have found a {inventory[inventory.Count - 1]}");
                                }

                            }
                            break;
                        case ConsoleKey.R://retreats from the current room. lowers score by 1 and does an attack of opportunity.
                            Console.WriteLine("Run Away");
                            Combat.DoAttack(monster, player);
                            innerMenu = false;
                            score--;
                            break;
                        case ConsoleKey.C://diplays player character info
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine($"Current Score: {score}");
                            
                            break;
                        case ConsoleKey.M://displays current monster info
                            Console.WriteLine("Opponent Info");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.I: //starts sub loops allowing for viewing and use of items in the inventory list.                        
                            bool inv = true;
                            while (inv)
                            {
                                int invCount = inventory.Count - 1;
                                bool innerInv = true;
                                while (innerInv)
                                {
                                    
                                    if (inventory.Count == 0)
                                    {
                                        Console.WriteLine("Your inventory is empty! Go out and find some stuff. Press any key to return to the action.");
                                        Console.ReadKey(true);
                                        innerInv = false;
                                        inv = false;
                                        Console.Clear();
                                        break;
                                    }
                                    
                                    Item invItem = inventory[invCount];
                                    Console.WriteLine($"You have a {invItem.Name}! {invItem.Description}\n" +
                                        $"P. Previous Item\tN. Next Item\tU. Use Item\tR. Remove Item\tE. Exit");
                                    choice = Console.ReadKey(true).Key;
                                    switch (choice)
                                    {
                                        case ConsoleKey.P:
                                            if (invCount == 0)
                                            {
                                                invCount = inventory.Count-1;
                                            }
                                            else
                                            {
                                                invCount--;
                                            }
                                            break;
                                        case ConsoleKey.N:
                                            if (invCount == inventory.Count - 1)
                                            {
                                                invCount = 0;
                                            }
                                            else
                                            {
                                                invCount++;
                                            }
                                            break;
                                        case ConsoleKey.U:
                                            if (invItem.IsConsumable == true)
                                            {
                                                if (invItem.AmountHealed + player.CurrentLife > player.MaxLife)
                                                {
                                                    player.CurrentLife = player.MaxLife;
                                                    inventory.RemoveAt(invCount);
                                                    invCount --;
                                                    Console.WriteLine("You feel rejuvinated, and are back to your max health");
                                                    break;
                                                }
                                                else
                                                {
                                                    player.CurrentLife += invItem.AmountHealed;
                                                    inventory.RemoveAt(invCount);
                                                    Console.WriteLine($"You have healed {invItem.AmountHealed} health. Tour current health is {player.CurrentLife} of {player.MaxLife}");
                                                    invCount--;
                                                    break;
                                                }
                                                

                                            }
                                            else if (invItem.IsWeapon)
                                            {
                                                Console.WriteLine($"You have unequipped {player.EquippedWeapon.Name} and equpped {invItem.Name}");
                                                inventory.Add(player.EquippedWeapon);
                                                player.EquippedWeapon = invItem;
                                                inventory.RemoveAt(invCount);
                                                break;

                                            }
                                            else if (invItem.Location == EquipLocations.head)
                                            {
                                                if (player.EquippedHead == null)
                                                {
                                                    Console.WriteLine($"You have equipped {invItem.Name}");
                                                    player.EquippedHead = invItem;
                                                    inventory.RemoveAt(invCount);
                                                    invCount--;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"You have unequipped {player.EquippedHead.Name} and equipped {invItem.Name}");
                                                    inventory.Add(player.EquippedHead);
                                                    player.EquippedHead = invItem;
                                                    inventory.RemoveAt(invCount);
                                                    break;
                                                }

                                            }
                                            else if (invItem.Location == EquipLocations.body)
                                            {
                                                if (player.EquippedBody == null)
                                                {
                                                    Console.WriteLine($"You have equipped {invItem.Name}");
                                                    player.EquippedBody = invItem;
                                                    inventory.RemoveAt(invCount);
                                                    invCount--;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"You have unequipped {player.EquippedBody.Name} and equipped {invItem.Name}");
                                                    inventory.Add(player.EquippedBody);
                                                    player.EquippedBody = invItem;
                                                    inventory.RemoveAt(invCount);
                                                    break;

                                                }
                                            }
                                            else if (invItem.Location == EquipLocations.hands)
                                            {

                                                if (player.EquippedWeapon.HandSlots >= player.AvailableHands)
                                                {
                                                    Console.WriteLine("Not enough hands!! Maybe pick a smaller weapon!");
                                                }
                                                else if (player.EquippedHands == null)
                                                {
                                                    Console.WriteLine($"You have equipped {invItem.Name}");
                                                    player.EquippedHands = invItem;
                                                    inventory.RemoveAt(invCount);
                                                    invCount--;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"You have unequipped {player.EquippedHands.Name} and equipped {invItem.Name}");
                                                    inventory.Add(player.EquippedHands);
                                                    player.EquippedHands = invItem;
                                                    inventory.RemoveAt(invCount);
                                                    break;
                                                }
                                            }
                                            break;
                                        case ConsoleKey.R:
                                            inventory.RemoveAt(invCount);
                                            break;
                                        case ConsoleKey.E:
                                        case ConsoleKey.Escape:
                                            innerInv = false;
                                            inv = false;
                                            break;

                                    }








                                };
                            };
                            Console.Clear();
                            break;
                        case ConsoleKey.Escape://ends the game
                        case ConsoleKey.E:
                            Console.WriteLine("Thanks for playing!");
                            mainLoop=false;
                            break;

                        default:
                            Console.WriteLine("Invalid selection, try again");
                            break;
                    }

                    if (player.CurrentLife <= 0)//ends the game if player life is at 0 or below
                    {
                        Console.WriteLine("As you have your final breaths, your only regret is that you spent your last moments cleaning the house.");
                        mainLoop = false;
                    }
                } while (innerMenu && mainLoop);
            } while (mainLoop);
            Console.WriteLine($"Final Score: {score}");
        }
        private static string GetRoom(int score)//returns a room based on score, or randomly
        {
            List<string> rooms = new List<string>()
            {
                "YOUR ROOM\nYour room is probably the best in the house, but it is still filthy.",//0
                "THE UPSTAIRS HALLWAY\nThe upstairs hallway is dusty and dark, with one flickering overhead light",//1
                "UPSTAIRS BATHROOM\n For reasons that will never be explained, someone is brewing a strange liquor in the bathtub.",//2
                "UPSTAIRS BEDROOM!!\nThis room belongs to one of your roommates. There is a strange mix of computer equipment, and ancient artifacts.",//3
                "STAIRS DOWN\nBe careful of the missing steps!",//4
                "THE LIVING ROOM.\nThis room is dominated by a large projector screen, and filled with an odd assortment of patio furniture.",//5
                "DOWNSTAIRS BATHROOM\nWhere once there was a toilet, now there is only a hole.",//6
                "BEDROOM\nThis bedroom has seen better days, and is littered with cookbooks and what appears to be alchemical equipment.",//7
                "THE KTICHEN OF DOOM\nEverything in this kitchen is covered in type 00 flour and mold.",//8
                "BASEMENT STAIRS\nThese stairs are old and rickety, there is a faint scent rising from the basement.",//9
                "BASEMENT ROOM 1\nThis room is dark, and a faintly sweet rotting smell fills the air.",//10
                "THE FINAL ROOM!\nYour fears have been confirmed, and the smell from the basement seems to be coming from the floor to ceiling tubs of rotting cabbage"//11
            };

            if (score < 12)
            {
                return rooms[score];
            }
            else
            {
                Random rand = new Random();

                return rooms[rand.Next(0, 12)];
            }

        }
        private static  Monster GetMonster(int score)//returns monster. Uses score to deliver random monsters of a specific tier, or specific monsters for the first time encountering certain rooms.
        {
            Critter m1 = new();
            Construction m2 = new();
            Abberation m3 = new();
            Roommate m4 = new();
            Roommate geof = new("GEOF THE TECHNO VIKING", 60, 50, 5, 5, 10, 5, "This is your roomate Geof. His extreme height combined with his horned helmet is currently putting holes in the ceiling.", MonsterType.Roommate,true);
            Roommate nate = new("NATHAN THE PIZZA MAN",70,55,5,6,12,6,"Your roommate has somehow turned himslef into a literal pizza man. Or is it a man pizza?",MonsterType.Roommate,true);
            Roommate russ = new("RUSS THE FARMER OF DESPAIR",80,60,10,5,15,5,"This roommate appears jovial, with his big beard and overalls. You can just make out the head of cabbage he is reading to chuck at your head.",MonsterType.Roommate, true);
            Roommate keno = new("Kenny, just Kenny", 120, 70, 10, 5, 15, 5, "Kenny appears to be a normal guy, but I hear he once fought 5 guys and their girlfriend... and won.", MonsterType.Roommate, true);


            List<Monster> monReturnEarly = new List<Monster>()
            {
                m1,//0
                m2,//1
                m3,//2
                m4,//3
            };
            List<Monster> monReturnMid = new List<Monster>()
            {
                m1,
                m2,
                m3,
                m4,
                geof,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,

            };

            List<Monster> monReturnLate = new List<Monster>()
            {
                m1,
                m2,
                m3,
                m4,
                geof,
                geof,
                nate,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,

            };

            List<Monster> monReturnEndGame = new List<Monster>()
            {
                 m1,
                m2,
                m3,
                m4,
                geof,
                geof,
                nate,
                russ,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,
                m1,
                m2,
                m3,
                m4,

            };
            Random rand = new Random();
            if (score < 3)
            {


                return monReturnEarly[rand.Next(monReturnEarly.Count)];
            }
            else if (score == 3)
            {
                return geof;
            }
            else if (score < 8)
            {
                return monReturnMid[rand.Next(monReturnMid.Count)];
            }
            else if (score == 8)
            {
                return nate;
            }
            else if (score < 11)
            {
                return monReturnLate[rand.Next(monReturnLate.Count)];
            }
            else if (score == 11)
            {
                return russ;
            }
            else if (score < 100)
            {
                return monReturnEndGame[rand.Next(monReturnEndGame.Count)];
            }
            else if (score == 100)
            {
                return keno;
            }
            else
            {
                return monReturnEndGame[rand.Next(monReturnEndGame.Count)];
            }

        }

        private static Item GetItem() //returns random item
        {
            Item cleaner = new Item("Spray bottle of cleaner",false,"A spray bottle full of a bleach based cleaner that can be used as a weapon.",8,15,1,1,0,0,0,EquipLocations.hands,false);
            Item vacuum = new Item("Vacuum", false, "A portable backpack based vacuum that can be used as a weapon.", 12, 5, 2, 1, 0, 0 , 0, EquipLocations.hands,false);
            Item studyBudy = new Item("Study Budy", false,"An overly helpfull member of your study group that will fight for you.", 10,10,0,1,0,0,0,EquipLocations.hands,true);
            Item bikeHelmet = new Item("Bicycle Helmet", false, "This old helmet should give your noggin some protection.", 0, 0, 0, 0, 0, 5, 3, EquipLocations.head, false);
            Item armorHelmet = new Item("Plate Helmet",false,"This helmet was presumably stolen from the history department.",0,0,0,0,0,10,6,EquipLocations.head,false);
            Item larpArmor = new Item ("Plastic Armor",false,"This plastic breastplate is leftover from someone's LARPing days.",0,0,0,0,0,5,3,EquipLocations.body,false);
            Item cookieSheet = new Item("A Cookie Sheet", false, "A suprising amount of protection is afforded by stuffing a cookie sheet down your shirt.", 0, 0, 0, 0, 0, 10, 6, EquipLocations.body, false);
            Item trashLid = new Item("Trash can lid", false,"Nothing beats using a trash can lid as a shield.",0,0,1,0,0,10,0,EquipLocations.hands,false);
            Item pwrGlove = new Item("A Nintendo Power Glove", false, "You have wanted one of these since you first saw The Wizard.", 0, 20, 1, 0, 0, 20, 0, EquipLocations.hands, false);
            Item sportsDrink = new Item("Sports Drink",true,"Gotta love that Hatorade.",0,0,0,0,15,0,0,EquipLocations.hands,false);
            Item alcohol = new Item("Alcohol",true,"Some cheap booze usually fixes you right up.",0,0,0,0,30,0,0,EquipLocations.hands,false);

            Random rand = new Random();
            List<Item> items = new List<Item>()
            {
                sportsDrink,
                sportsDrink,
                sportsDrink,
                sportsDrink,
                sportsDrink,
                sportsDrink,
                alcohol,
                alcohol,
                alcohol,
                alcohol,
                alcohol,
                cleaner,
                vacuum,
                studyBudy,
                bikeHelmet,
                armorHelmet,
                larpArmor,
                cookieSheet,
                trashLid,
                pwrGlove
            };


            return items[rand.Next(0, items.Count-1)];
            
            

            

        }
    }
}
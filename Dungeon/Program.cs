using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        //svm > Tab > Tab creates a static void Main()
        static void Main(string[] args)
        {
            //Title & Introduction

            #region Title / Introduction

            Console.Title = "DUNGEON OF DOOM";

            Console.WriteLine("Your journey begins...\n");

            #endregion

            #region Potential Expansion - Initiative

            //Consider adding an "Initiative" property to Character
            //Then check the Initiative to determine who attacks first
            //if (player.Initiative >= monster.Initiative)
            //{
            //    DoAttack(player, monster);
            //}
            //else
            //{
            //    DoAttack(monster, player);
            //}

            #endregion



            //Variable to Track Score

            int score = 0;

            //TODO Weapon Object Creation
            Weapon sword = new Weapon(8, "Long Sword", 10, false, WeaponType.Sword, 1);
            //Create a list of weapons, and either give the player a random weapon, let them pick a weapon, 
            //or let them pick a WeaponType, and give them a weapon based off of that type.



            //TODO Player Object Creation            
            #region Possible Expansion - Player Customization - Block 5

            //Possible Expansion: 
            //Allow player to define chatacter name
            //Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            //Console.Clear();
            //Console.WriteLine("Welcome, {0}! Your journey begins...", userName);
            //Console.ReadKey();
            //Console.Clear();

            //Display a list of races and let them pick one, or assign one randomly.
            #endregion
            Player player = new Player("Leeroy Jenkins", 70, 5, 40, Race.Elf, sword);
            


            //TODO Create the main game loop

            #region Main Game Loop

            //Counter variable - used in the condition of the loop
            bool exit = false;

            do
            {
                //Generate a random room the player will enter
                //Console.WriteLine(GetRoom());
                Console.WriteLine(GetRoom());

                //Select a random monster to inhabit the room
                Monster monster = Monster.GetMonster();
                Console.WriteLine("\nIn this room... " + monster.Name);
                //Create the gameplay menu loop

                #region Gameplay Menu Loop

                bool reload = false;

                do
                {

                    //TODO Create the main gameplay menu
                    #region MENU

                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //Capture the user's menu selection
                    ConsoleKey userChoice = Console.ReadKey(true).Key; //Capture the pressed key, hide the key from 
                    //the console, and execute immediately

                    //Clear the console
                    Console.Clear();

                    //Use branching logic to act upon the user's selection
                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            //Combat
                            #region Possible Expansion - Racial/Weapon Bonus

                            //Possible Expansion: Give certain character races or characters with a certain weapon an advantage
                            //if (player.CharacterRace == Race.DarkElf)
                            //{
                            //    Combat.DoAttack(player, monster);
                            //}


                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0) 
                            {
                                //Loot!!!
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou killed {monster.Name}!");
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }

                            break;


                        case ConsoleKey.R:

                            //TODO Run Away - Attack of Opportunity

                            Console.WriteLine("Run Away!!!");
                            //Monster gets an attack of opportunity
                            Console.WriteLine(monster.Name + " attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;

                        case ConsoleKey.P:

                            //Player Stats

                            Console.WriteLine(player);

                            break;

                        case ConsoleKey.M:

                            //Monster Stats

                            Console.WriteLine(monster);

                            break;


                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            //Exit

                            Console.WriteLine("Nobody likes a quitter...");

                            exit = true;

                            break;

                        default:

                            Console.WriteLine("Thou hast chosen an improper option. Triest thou again.");

                            break;
                    }


                    #region Check Player's Life Total

                    //Check player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude... you died! \a");
                        exit = true;
                    }

                    #endregion



                    #endregion



                } while (!reload && !exit);


                #endregion


            } while (!exit); //Keep looping as long as exit is false


            #endregion


            //Output the Final Score

            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms = /*new string[5]*/
            {
                    "The room is dark and musty with the smell of lost souls.",
                    "You enter a pretty pink powder room and instantly get glitter on you.",
                    "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                    "You enter a quiet library... silence... nothing but silence....",
                    "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                    "Oh my.... what is that smell? You appear to be standing in a compost pile",
                    "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                    "Oh no.... the worst of them all... Oprah's bedroom....",
                    "The room looks just like the room you are sitting in right now... or does it?"
            };

            return rooms[new Random().Next(rooms.Length)];
        }
    }//end Class
}//end namespace



#endregion
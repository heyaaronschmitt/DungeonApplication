using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields // Funny
        //MinDamage as an int - can't be more than MaxDamage, or less than 0.
        private int _minDamage;


        //Properties // People
        //MaxDamage as an int

        public int MaxDamage { get; set; }
        //Description as a string
        public string Description { get; set; }
        //MinDamage as an int - can't be more than MaxDamage, or less than 0.
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > 0 && value <= MaxDamage ? value : 1; }
        }
        //Constructors // Collect

        //Methods // Monkeys
        public Monster()
        {
        }

        public Monster(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description) : base(name, hitChance, block, maxLife)
        {
            //Remember to set MaxDamage first!!!
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
        public override string ToString()
        {
            return $"\n********** MONSTER **********\n" +
                   $"----- {Name} -----\n" +
                   $"Life: {Life} of {MaxLife}\n" +
                   $"Damage: {MinDamage} to {MaxDamage}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}\n" +
                   $"Description: {Description}";
        }
        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);

            //return a random number between Monster min and max damage.
        }

        public static Monster GetMonster() 
        {
            Rabbit rabbit = new Rabbit("White Rabbit", 25, 50, 20, 8, 2, "That's no ordinary rabbit! Look at the bones!", true);
            Rabbit babyRabbit = new Rabbit();

            Vampire vampire = new Vampire("Dracula", 30, 70, 8, 8, 1, "The father of all undead");

            Turtle turtle = new Turtle("Mikey", 25, 50, 10, 4, 1, "He is nolonger a teenager, but he is still a mutant turtle", 3, 10);
            Turtle babyTurtle = new Turtle();

            Dragon dragon = new Dragon("Smaug", 35, 65, 20, 15, 1, "The last great dragon", true);
            Dragon babyDragon = new Dragon();

            List<Monster> monsters = new List<Monster>()
            {
                rabbit,
                babyRabbit, babyRabbit, babyRabbit,
                vampire,
                turtle,
                babyTurtle, babyTurtle, babyTurtle,
                dragon,
                babyDragon
            };

            int randomIndex = new Random().Next(monsters.Count);
            Monster monster = monsters[randomIndex];
            return monster;
        }

    }
}

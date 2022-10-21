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
                   $"Damage: {MinDamage} to {MaxDamage}" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}" +
                   $"Description: {Description}";
        }
        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);

            //return a random number between Monster min and max damage.
        }
    }
}

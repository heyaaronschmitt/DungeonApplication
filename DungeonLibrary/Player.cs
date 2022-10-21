using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Fields // Funny
        //no fields

        //Properties // People
        //Race CharacterRace
        //EquippedWeapon Weapon
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //Constructors // Collect
        public Player(string name, int hitChance, int block, int maxLife, Race characterRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            //handle unique assignment
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            //potential expansion, not required
            //switch (CharacterRace)
            //{
            //    case Race.Elf:
            //        HitChance += 5;
            //        MaxHealth -= 5;
            //        break;
            //}
        }
        public Player()
        {

        }

        //Methods // Monkeys
        public override int CalcDamage()
        {
            //return a random value between the Weapon's min and max damage
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }
        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
            //HitChance + Weapon BonusHitChance
        }
        public override string ToString()
        {
            string description = CharacterRace.ToString().Replace('_', ' ');

            //holding variable for the description
            //Switch on CharacterRace
            //case CharacterRace.Elf: 
            //  description = "Describe an Elf"
            //  break;            
            return base.ToString() + $"\nWeapon:\n{EquippedWeapon}\nBlock: {Block}\n" +
                $"Description: {description}";//+some unique description based on the player race.
            //hint, use a switch
        }
    }
}

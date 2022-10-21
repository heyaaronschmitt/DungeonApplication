using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {
        //FIELDS

        //PROPERTIES
        public bool IsFluffy { get; set; }



        //CONSTRUCTORS
        public Rabbit()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            Life = MaxLife;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny... Why would you hurt it?";
            IsFluffy = false;
        }
        //Intellisence quick action on the parent name in class declartion.
        public Rabbit(string name, int maxLife, int hitChance, int block, //Character
                        int maxDamage, int minDamage, string description, //Monster
                        bool isFluffy) //Rabbit
            : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsFluffy = isFluffy;
        }

        //METHODS

        public override string ToString()
        {
            return base.ToString() + "\n" + (IsFluffy ? "It's Fluffy" : "It's not so fluffy");
        }

        //Character CalcBlock = BLock
        //Monster CalcBlock = Block
        //Rabbit CalcBlock = not block
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            //Apply a 50% increase to the rabbit's block if it is fluffy
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }




    }
}

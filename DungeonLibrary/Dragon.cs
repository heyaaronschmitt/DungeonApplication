using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dragon : Monster
    {


        public bool IsScaly { get; set; }

        public Dragon(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, bool isScaly) 
            : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            IsScaly = isScaly;
        }

        public Dragon()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby dragon";
            Life = 6;
            HitChance = 25;
            Block = 20;
            MinDamage = 1;
            Description = "A freshly-hatched baby dragon. It still looks dangerous...";
            IsScaly = false;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + (IsScaly ? "Coated in thick scales" : "Has a soft, underdeveloped hide");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            //Apply a 50% increase to the dragon's block if it is scaly
            if (IsScaly)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}

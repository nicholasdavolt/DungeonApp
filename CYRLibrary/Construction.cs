using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Construction : Monster
    {
        public bool BuiltToHit { get; set; }
        public Construction(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType, bool builtToHit) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {
            BuiltToHit = builtToHit;
        }

        public Construction() : base("ROB the evil robot", 10, 50, 5, 2, 8, 1, "This once friendly Nintendo helper has been turned evil by one of your roommates.", MonsterType.Construction) { BuiltToHit = true; }


        public override int CalcHitChance()
        {
            if (BuiltToHit)
            {
                Random random = new Random();
                return base.CalcHitChance() + random.Next(0, 4);
            }
            else { return base.CalcHitChance(); }

        }

        public override string ToString()
        {
            return base.ToString() + $"\nSpecial Ability {(BuiltToHit ? "Someone really dialed in this things targeting system. It's more likely to hit you!" : "")}";
        }
    }
}

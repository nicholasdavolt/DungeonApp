using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Roommate : Monster
    {
        public bool Barf { get; set; }
        public Roommate(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType, bool barf) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {
            Barf = barf;
        }

        public Roommate() : base("Guy on the couch", 10, 50, 5, 1, 8, 2, "You've never met this guy, but apparently he's been living on your couch for some time.", MonsterType.Roommate) { Barf = true; }


        public override int CalcDamage()
        {
            Random rand = new Random();
            int flip = rand.Next(1, 3);
            if (flip == 2)
            {
                Barf = false;
            }

            if (Barf)
            {
                return MaxDamage;
            }
            else
            {
                return base.CalcDamage();
            }
        }


        public override string ToString()
        {
            return base.ToString() + $"\nSpecial Ability {(Barf ? "How can something be so disgusting! Just bing around this is making you take extra damage!" : "")}";
        }
    }
}

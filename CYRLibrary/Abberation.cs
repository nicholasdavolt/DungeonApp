using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Abberation : Monster
    {
        public bool GrosslyStrong { get; set; }
        public Abberation(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {

        }

        public Abberation() : base("Living Long-John", 10, 50, 5, 2, 10, 2, "This donut has somehow been granted sentience, and appears quite dangerous.", MonsterType.Abberation) { GrosslyStrong = true; }


        public override int CalcDamage()
        {
            if (GrosslyStrong)
            {
                Random random = new Random();
                return base.CalcDamage() + random.Next(0, 4);
            }
            else { return base.CalcDamage(); }

        }

        public override string ToString()
        {
            return base.ToString() + $"\nSpecial Ability {(GrosslyStrong ? "Whatever foul mixture of science and witchcraft created this thing made it extra strong!" : "")}";
        }


    }
}

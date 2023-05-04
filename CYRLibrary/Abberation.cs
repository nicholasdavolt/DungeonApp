using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Abberation : Monster
    {
        public Abberation(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {

        }

        public Abberation() : base("Living Long-John", 10, 50, 10, 2, 12, 2, "This donut has somehow been granted sentience, and appears quite dangerous", MonsterType.Abberation) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Construction : Monster
    {
        public Construction(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {

        }

        public Construction() : base("ROB the evil robot", 10, 60, 10, 2, 8, 1, "This once friendly Nintendo helper has been turned evil by one of your roommates", MonsterType.Construction) { }
    }
}

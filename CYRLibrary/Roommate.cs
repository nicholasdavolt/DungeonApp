using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Roommate : Monster
    {
        public Roommate(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {

        }

        public Roommate() : base("Guy on the couch", 10, 50, 10, 1, 8, 2, "You've never met this guy, but apparently he's been living on your couch for some time.", MonsterType.Roommate) { }
    }
}

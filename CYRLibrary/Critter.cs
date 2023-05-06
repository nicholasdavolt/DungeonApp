using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public sealed class Critter : Monster
    {
        
        public bool IsRealGross { get; set; }

        public Critter(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType, bool isRealGross) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {
            IsRealGross = isRealGross;
        }

        public Critter() : base("Swarm of Roaches", 1, 50, 0, 0, 2, 1, "This is a swarm of unusally large roaches.", MonsterType.Critter)
        {
            IsRealGross = true;
        }
        public override int CalcToughness()
        {
            if (IsRealGross)
            {
                Random random = new Random();
                return base.CalcToughness() + random.Next(0, 4);
            }
            else { return base.CalcToughness(); }

        }

        public override string ToString()
        {
            return base.ToString() + $"\nSpecial Ability {(IsRealGross ? "This creature is so gross you pull your hits out of fear of touching it!" : "")}" ;
        }



    }
}

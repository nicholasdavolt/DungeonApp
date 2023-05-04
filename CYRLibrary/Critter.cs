using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public sealed class Critter : Monster
    {
        

        public Critter(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip, MonsterType monsterType) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip, monsterType)
        {
           
        }

        public Critter() : base("Swarm of Roaches", 1, 50, 0, 0, 2, 1, "This is a swarm of unusally large roaches", MonsterType.Critter) { }
        

      
        
    }
}

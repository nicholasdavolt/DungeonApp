using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public sealed class Critter : Monster
    {
        public int GrossOutFactor { get; set; }

        public Critter(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip) : base(name, maxLife, hitChance, block, toughness, maxDamage, minDamage, monDescrip)
        {
           
        }

        public Critter()
        {
            Name = "Swarm of Roaches";

        }

      
        
    }
}

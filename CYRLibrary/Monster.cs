using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public abstract class Monster : Character
    {
        private int _minDamage;

      
        public int MaxDamage { get; set; }
        public string MonDescrip { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = (value > 0 && value < MaxDamage ? value : 1) ; }


        }

        public Monster(string name, int maxLife, int hitChance, int block, int toughness, int maxDamage, int minDamage, string monDescrip) : base(name, maxLife, hitChance, block, toughness)
        {
            MonDescrip = monDescrip;
            MaxDamage = maxDamage;
            MinDamage = minDamage;

            if (maxDamage <= minDamage || minDamage <= 0)
            {
                throw new ArgumentException("Min Damage must be between zero and Max Damage");
            }
        }
        public override string ToString()
        {
        return base.ToString() + $"Damage Range: {MinDamage} - {MaxDamage}\n" +
            $"Description:\n {MonDescrip}";
        }
        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }
    }  
}

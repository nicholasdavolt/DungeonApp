using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Weapon : Item
    {
        
        private int _maxDamage;
        private int _bonusHitChance;
        private int _handSlots;
        private int _minDamage;
        private WeaponType _wType;

        

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public int HandSlots
        {
            get { return _handSlots; }
            set { _handSlots = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value >= _maxDamage)
                {
                    _minDamage = 1;
                }
                else if (value < 1)
                {
                    _minDamage = 1;
                }
                else { _minDamage = value; }
            }

        }
        public WeaponType WType
        {
            get { return _wType; }
            set { _wType = value; }
        }

        public Weapon(string name, bool isConsumable, int maxDamage, int bonusHitChance, int handSlots, int minDamage, WeaponType wtype) : base(name, isConsumable)
        {
            MaxDamage = maxDamage;
            BonusHitChance = bonusHitChance;
            HandSlots = handSlots;
            MinDamage = minDamage;
            WType = wtype;          

        }

        public override string ToString()
        {
            return base.ToString() + $"Damage Range: {MinDamage} - {MaxDamage}\n" +
                $"Bonus Hit Chance: {BonusHitChance}\n" +
                $"Type: {WType}\n" +
                $"Hands Used: {HandSlots}\n";
        }


    }

}

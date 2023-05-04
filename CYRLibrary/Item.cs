using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Item
    {

        private int _minDamage;
        public string Name { get; set; }
        public bool IsConsumable { get; set; }
        public string Description { get; set; }

       
        public int MaxDamage { get; set; }
       

        public int BonusHitChance { get; set; }

        public int HandSlots { get; set; }

        public int AmountHealed;
        public EquipLocations Location { get; set; }
        
        public int BonusBlock { get; set; }
        public int BonusToughness { get; set; }
        
        public bool IsWeapon { get; set; }
        public int MinDamage 
        {
           get { return _minDamage; }
           set
            {
                if (IsWeapon)
                {
                    if (value > MaxDamage || value < 1 )
                    {
                        _minDamage = 1;
                    }
                    else
                    {
                        _minDamage = value;
                    }
                   
                }
                else
                {
                    _minDamage = value;
                }
            }

        }
        



        public Item(string name, bool isConsumable, string description, int maxDamage, int bonusHitChance, int handSlots, int minDamage, int amountHealed, int bonusBlock, int bonusToughness, EquipLocations location, bool isWeapon)
        {
            Name = name;
            IsConsumable = isConsumable;
            Description = description;
            MaxDamage = maxDamage;
            BonusHitChance = bonusHitChance;
            HandSlots = handSlots;
            MinDamage = minDamage;
            AmountHealed = amountHealed;
            BonusBlock = bonusBlock;
            BonusToughness = bonusToughness;
            Location = location;
            IsWeapon = isWeapon;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n";
        }
    }
}

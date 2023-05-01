using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Equipment_Hands : Item
    {
        public EquipLocations Location { get; set; }
        public int BonusHitChance { get; set; }
        public int BonusBlock { get; set; }
        public int BonusToughness { get; set; }



        public Equipment_Hands(string name, bool isConsumable, int bonusHitChance, int bonusBlock, int bonusToughness, EquipLocations location) : base(name, isConsumable)
        {
            BonusHitChance = bonusHitChance;
            BonusBlock = bonusBlock;
            BonusToughness = bonusToughness;
            Location = location;

        }

        public override string ToString()
        {
            return base.ToString() + $"Location: {Location}\n" +
                $"Bonus Hit Chance: {BonusHitChance}\n" +
                $"Bonus Block: {BonusBlock}\n" +
                $"Bonus Toughness: {BonusToughness}\n";


        }
    }
}

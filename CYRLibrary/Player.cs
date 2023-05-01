using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public sealed class Player : Character
    {
        private  int _availableHands;

        public Major PlayerMajor { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public int BonusDamage { get; set; }

        public int AvailableHands { get; set; }

        public Player(string name, int maxLife, int hitChance, int block, int toughness, Major playerMajor, Weapon equippedWeapon) : base(name, maxLife, hitChance, block, toughness)
        {
            PlayerMajor = playerMajor;
            EquippedWeapon = equippedWeapon;
            AvailableHands = 2;

            switch (PlayerMajor)
            {
                case Major.Physical_Education:
                    BonusDamage = 5;
                    break;
                case Major.Chemistry:
                    MaxLife += 10;
                    CurrentLife = MaxLife;
                    break;
                case Major.Engineering:
                    AvailableHands += 1;
                    break;
                case Major.Undeclared:
                    Block += 10;
                    break;
                default:
                    break;



            }

           

        }

        public override string ToString()
        {
            string majorDescription = "";

            switch (PlayerMajor)
            {
                case Major.Physical_Education:
                    majorDescription = "Your studies into whistle blowing and dodge ball have increased your ability to inflict harm! Take a lap!";
                    break;
                case Major.Chemistry:
                    majorDescription = "Your knowledge of the periodic table has led to the creation of several questionable substances. One of these has increased your ability to take damage. Better living though Chemistry!";
                    break;
                case Major.Engineering:
                    majorDescription = "Using the powers of elcticity and metallurgy you have constructed a robotic third arm. Give yourself a hand!";
                    break;
                case Major.Undeclared:
                    majorDescription = "Attacks, much like responsibility, don't seem to worry you much. Apathy will see you through!";
                    break;
                default:
                    break;
            }

            return base.ToString() + $"Weapon: {EquippedWeapon.Name}\n" +
                $"Bonus Hit Chance: {EquippedWeapon.BonusHitChance}\n" +
                $"Weapon Damage: {EquippedWeapon.MinDamage} - {EquippedWeapon.MaxDamage}\n" +
                $"Descriptiong:\n{majorDescription}\n";
        }

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, (EquippedWeapon.MaxDamage + BonusDamage + 1));
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }


    }
}

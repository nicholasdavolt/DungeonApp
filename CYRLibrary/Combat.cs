using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            Random rand = new Random();

            int hitRoll = rand.Next(1, 101);

            if (hitRoll == 100)
            {
                int damage = attacker.CalcDamage();
                attacker.CurrentLife -= damage - attacker.Toughness;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CRITICAL MISS! {attacker.Name} has damaged themselves for {damage} damage!");
                Console.ResetColor();
            }
            else if (hitRoll <= 10)
            {
                int damage = attacker.CalcDamage() * 2;
                defender.CurrentLife -= damage - defender.Toughness;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CRITICAL HIT!!!{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();
            
            }
            else if (hitRoll <= chance)
            {
                int damage = attacker.CalcDamage();
                defender.CurrentLife -= damage - defender.Toughness;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
                Console.WriteLine("Roll: " + hitRoll);
                Console.WriteLine("Hit Chance: " + chance);
            }

        }

        public static void DoBattle (Player player, Monster monster)
        {
            DoAttack(player, monster);

            if(monster.MaxLife > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}

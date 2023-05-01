using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CYRLibrary;

namespace Dungeon
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            Weapon w1 = new Weapon("Broom", false, 8, 5, 1, 1, WeaponType.Stick);

            Console.WriteLine(w1);

            //Equipment_Head e1 = new Equipment_Head("Trashcan Lid", false, 0, 10, 0, EquipLocations.hands,1);

            //Console.WriteLine(e1);
        }

    }
}

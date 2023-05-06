using CYRLibrary;
using Dungeon;
namespace UnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void TestMonsterCalcBlock()
        {
            Roommate geof = new("GEOF THE TECHNO VIKING", 60, 50, 5, 5, 10, 5, "This is your roomate Geof. His extreme height combined with his horned helmet is currently putting holes in the ceiling.", MonsterType.Roommate, true);

            int expected = 5;
            int actual = geof.CalcBlock();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPlayerCalcHitChance()
        {
            Item studyBudy = new Item("Study Budy", false, "An overly helpfull member of your study group that will fight for you.", 10, 10, 0, 1, 0, 0, 0, EquipLocations.hands, true);
            Player player = new("Test", 50, 50, 5, 3, Major.Physical_Education, studyBudy);

            int expected = 60;
            int actual = player.CalcHitChance();

            Assert.Equal(expected, actual);

        }
    }
}
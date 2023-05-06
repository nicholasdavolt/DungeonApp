namespace CYRLibrary
{
    public abstract class Character
    {

        public string Name { get; set; }
        public int MaxLife { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int CurrentLife { get; set; }
        public int Toughness { get; set; }

        public Character(string name, int maxLife, int hitChance, int block, int toughness)
        {
            Name = name;
            MaxLife = maxLife;
            HitChance = hitChance;
            Block = block;
            CurrentLife = maxLife;
            Toughness = toughness;
        }

        public Character() { }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Life: {CurrentLife} / {MaxLife}\n" +
                $"Toughness: {Toughness}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}\n";
        }

        public virtual int CalcBlock()
        {
            return Block;
        }

        public abstract int CalcDamage();

        //and abstract methos will have no functionality, no scopes. It makes override MANDATORY

        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcToughness()
        {
            return Toughness;
        }
    }
}
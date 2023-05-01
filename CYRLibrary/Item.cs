using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYRLibrary
{
    public abstract class Item
    {
        public string Name { get; set; }
        public bool IsConsumable { get; set; }


        public Item(string name, bool isConsumable)
        {
            Name = name;
            IsConsumable = isConsumable;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n";
        }
    }
}

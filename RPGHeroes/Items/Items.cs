using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG_Heroes.Enum.Enums;

namespace RPG_Heroes.Items
{
    public abstract class Items
    {
        /*
         * Heroes can equip various items. The two types of items are: Weapon and Armor. There should be a parent Item
         * abstract class which is inherited by the above-mentioned types. All items share the following fields:
         * • Name
         * • RequiredLevel
         * • Slot
         * If a hero is below the RequiredLevel, they cannot equip the item. Each item is equipped in a specific Slot.
         * Slot should be represented as an enumerator and have the following values:
         * • Weapon
         * • Head
         * • Body
         * • Legs
         */

        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }

        protected Items(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }
}

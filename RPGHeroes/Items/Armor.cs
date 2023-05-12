using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG_Heroes.Enum.Enums;

namespace RPG_Heroes.Items
{
    public class Armor : Items
    {
        /*
         * There are several types of armor that exist:
         * • Cloth
         * • Leather
         * • Mail
         * • Plate
         * You should encapsulate these types in a ArmorType enumerator and compose that into the armor class. In addition to
         * an armor type, armor has attributes which provide bonuses to a heroes attributes when equipped. This field is of type
         * HeroAttribute and should be called ArmorAttribute. --> added to HeroAttribute calss, but not sure that is correct
         */

        public ArmorType ArmorType { get; set; }
        public string Name { get; set; }
        public int ArmorAttribute { get; set; } //tell property for bonus attributes thr armor gives hero
        public Slot Slot { get; set; }
        public int RequiredLevel { get; set; }

        public Armor(ArmorType armorType, string name, int armorAttribute, Slot slot, int requiredLevel)
        {
            ArmorType = armorType;
            Name = name;
            ArmorAttribute = armorAttribute;
            Slot = slot;
            RequiredLevel = requiredLevel;
        }



        //set the public constructr for armor
        //the Slots for armor are Head Body Legs

    }
}

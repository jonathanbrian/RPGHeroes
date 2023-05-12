using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG_Heroes.Enum.Enums;

namespace RPG_Heroes.Items
{
    public class Weapon : Items
    {
        /*
         * There are several types of weapons which exist:
         * • Axes
         * • Bows
         * • Daggers
         * • Hammers
         * • Staffs
         * • Swords
         * • Wands
         * You should encapsulate these types in a WeaponType enumerator and compose that into the weapon class. In addition
         * to a weapon type, weapons deal damage. This is represented as a WeaponDamage field.
         * NOTE: When a weapon is created, it is automatically given the Slot of Weapon.
         */
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }
               

        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage) : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }

        //Weapon is to have the Slot of Weapon

    }
}

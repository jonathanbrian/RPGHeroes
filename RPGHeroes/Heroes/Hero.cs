using RPG_Heroes.Enum;
using RPG_Heroes.Exceptions;
using RPG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static RPG_Heroes.Enum.Enums;
using static RPG_Heroes.Items.Items;

namespace RPG_Heroes.Heroes
{
    public abstract class Hero
    {
        /*Notes:
         * Share attributes for all heroes:
         * Name
        *Level - all heroes start at level 1
        *LevelAttribtues - total from all levels
        *Equipment - holds currently equipped items
        *ValidWeaponTypes – a list of weapon types a hero can equip based on their subclass
        *ValidArmorTypes - a list of armor types a hero can equip based on their subclass
        */

        /*Public facing methods: 
         * Constructor – each hero is created by passing just a name.
         * • LevelUp – increases the level of a character by 1 and increases their LevelAttributes
         * • Equip – two variants, for equipping armor and weapons
         * • Damage – damage is calculated on the fly and not stored
         * • TotalAttributes – calculated on the fly and not stored
         * • Display – details of Hero to be displayed
        */

        /*There should be a base abstract Hero class to encapsulate 
         * all the shared functionality (fields and methods).
         * Any methods which have a default implementation can be defined 
         * in this abstract class to be overridden in the child classes.
         * If there is no default implementation for a method, 
         * make it abstract to be implemented in a child class.
         * NOTE: When testing the functionality, you need to interact with the abstract Hero class, and not the subclasses. 
         * This is tosatisfy the Liscov Substitution Principle
         */


        //public shared fields

        public string Name { get; set; }
        public int Level { get; set; }
        public string ClassName { get; set; }
        public HeroAttribute LevelAttributes { get; set; }
        public HeroAttribute HeroAttribute { get; set; }

        public Dictionary<Slot, Items.Items> Equipment { get; set; }
        public WeaponType[] ValidWeaponTypes { get; set; }
        public ArmorType[] ValidArmorTypes { get; set; }

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Slot, Items.Items>(); 
        }

        
      
        public void LevelUp()
        {
            Level++;
            HeroAttribute.Strength += HeroAttribute.LevelUpStrength;
            HeroAttribute.Dexterity += HeroAttribute.LevelUpDexterity;
            HeroAttribute.Intelligence += HeroAttribute.LevelUpIntelligence;
            //increase level by 1, and increase strenth, dexterity and intelligence
        }
        public void EquipArmor(Armor armorToEquip)
        {
            if((ValidArmorTypes.Contains(armorToEquip.ArmorType)&&(armorToEquip.RequiredLevel <=Level)))
                {
                Equipment = new Dictionary<Slot, Items.Items>(Slot.Body, armorToEquip); //hvordan sette opp at det er tre muligheter her?
            }
            if ((ValidArmorTypes.Contains(armorToEquip.ArmorType) && (armorToEquip.RequiredLevel <= Level)))
            {
                Equipment = new Dictionary<Slot, Items.Items>(Slot.Head, armorToEquip); //hvordan sette opp at det er tre muligheter her?
            }
            if ((ValidArmorTypes.Contains(armorToEquip.ArmorType) && (armorToEquip.RequiredLevel <= Level)))
            {
                Equipment = new Dictionary<Slot, Items.Items>(Slot.Legs, armorToEquip); //hvordan sette opp at det er tre muligheter her?
            }
            else
            {
                throw new InvalidArmorException();
            }
        }
        public void EquipWeapon(Weapon weaponToEquip)
        {
            if((ValidWeaponTypes.Contains(weaponToEquip.WeaponType) && (weaponToEquip.RequiredLevel <= Level))) 
            {
                Equipment = new Dictionary<Slot, Items.Items>(Slot.Weapon, weaponToEquip);
            } 
            else 
            { 
                throw new InvalidWeaponException(); 
            }
        }
        public double Damage()
        {
            double heroDamage = 0;

            if (weapon == null)
            {
                heroDamage = 1 * (1 + (double)HeroAttribute.DamagingAttribute / 100);
            }
            else
            {
                heroDamage = weapon.WeaponDamage * (1 + (double)HeroAttribute.DamagingAttribute / 100);
            }
            return heroDamage;
        }

        public abstract HeroAttribute TotalAttributes();
        public void DisplayHero()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Character name: {Name}\n");
            sb.AppendFormat($"Character class: {ClassName}\n");
            sb.AppendFormat($"Character level: {Level}\n");
            sb.AppendFormat($"Character total strength: {TotalAttributes().Strength}\n"); 
            sb.AppendFormat($"Character total dexterity: {TotalAttributes().Dexterity}\n"); 
            sb.AppendFormat($"Character total intelligence: {TotalAttributes().Intelligence}\n"); 
            sb.AppendFormat($"Character total damage: {Damage()}\n");
        }
    }
}

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
        public int LevelAttributes { get; set; } //hvorfor ikke denne?
        public HeroAttribute HeroAttribute { get; set; }

        public KeyValuePair<Slot, Items.Items> Equipment { get; set; }
        public WeaponType[] ValidWeaponTypes { get; set; }
        public ArmorType[] ValidArmorTypes { get; set; }

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            LevelAttributes = LevelAttributes; //hvorfor ikke denne? 
            Equipment = new KeyValuePair<Slot, Items.Items>(); //virker som det skal stå slikt for å ikke få error? Equipment = new KeyValuePair<Slot, Items.Items>();

            //ValidArmorTypes = ValidArmorTypes;
            //ValidWeaponTypes = ValidWeaponTypes;
        }

        //public facing methods: 

        //public void Constructor() { } (this one is the constructor created above)
        public void LevelUp()
        {
            Level++;
            HeroAttribute.Strength += HeroAttribute.LevelUpStrength;
            HeroAttribute.Dexterity += HeroAttribute.LevelUpDexterity;
            HeroAttribute.Intelligence += HeroAttribute.LevelUpIntelligence;
            //increase level by 1, and increase strenth, dexterity and intelligence
        }
        public void EquipArmor(Armor armorType)
        {
            if((ValidArmorTypes.Contains(armorType.ArmorType)&&(armorType.RequiredLevel <=Level)))
                {
                Equipment = new KeyValuePair<Slot, Items.Items>(Slot.Body, armorType); //hvordan sette opp at det er tre muligheter her?
            }
            if ((ValidArmorTypes.Contains(armorType.ArmorType) && (armorType.RequiredLevel <= Level)))
            {
                Equipment = new KeyValuePair<Slot, Items.Items>(Slot.Head, armorType); //hvordan sette opp at det er tre muligheter her?
            }
            if ((ValidArmorTypes.Contains(armorType.ArmorType) && (armorType.RequiredLevel <= Level)))
            {
                Equipment = new KeyValuePair<Slot, Items.Items>(Slot.Legs, armorType); //hvordan sette opp at det er tre muligheter her?
            }
            else
            {
                throw new InvalidArmorException();
            }
            //equip armor if valid, if not throw exception. use conditional statements
            //how to check if valid? check seperate method below
        }
        public void EquipWeapon(Weapon weaponType)
        {
            if((ValidWeaponTypes.Contains(weaponType.WeaponType) && (weaponType.RequiredLevel <= Level))) 
            { 
                Equipment = new KeyValuePair<Slot, Items.Items>(Slot.Weapon, weaponType); 
            } 
            else 
            { 
                throw new InvalidWeaponException(); 
            }
            //equip weapon if valid, if not throw exception. use conditional statements
            //how to check if valid? check seperate method below 
        }
        public void Damage(Weapon WeaponDamage) 
        { 
            int HeroDamage =  WeaponDamage * (1 + (HeroAttribute.DamagingAttribute/100)) //hvorfor sier den at Weapon ikke er en int? 
        }
        public void TotalAttributes() { }
        public void Display()
        {
            //create an object for the String Builder class
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Character name: {Name}\n");
            //sb.AppendFormat("Character class: {0}\n", typeof.Name);
            sb.AppendFormat($"Character level: {Level}\n");
            sb.AppendFormat($"Character total strength: {HeroAttribute.Strength}\n"); //- need to make total a parameter?
            sb.AppendFormat($"Character total dexterity: {HeroAttribute.Dexterity}\n"); //- need to make total a parameter?
            sb.AppendFormat($"Character total intelligence: {HeroAttribute.Intelligence}\n"); //- need to make total a parameter?
                                                                                              //sb.AppendFormat("Character total damage: {0}\n", Damage); - need to make total a parameter?

            foreach (var item in Equipment) // hva skjer her, hvorfor fungerer ikke Equipment? 
            {
                if (item.Value != null)

                {
                    Console.WriteLine($"{item.Key}:{item.Value.Name}");
                }
            }

        }
        public void CheckWeapon() { }
        //how to check if valid? 
        public void CheckArmor() { }
        //how to check if valid? 
    }
}

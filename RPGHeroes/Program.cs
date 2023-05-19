// See https://aka.ms/new-console-template for more information
using RPG_Heroes.Heroes;
using static System.Net.Mime.MediaTypeNames;
Console.WriteLine("Hello, World!");

Mage mage1 = new Mage("Alfred");
Console.WriteLine($"{mage1.Name} is created");

Weapon weapon1 = new Weapon("Excalibur knockoff", 1, WeaponType.Sword, 10);
Console.WriteLine($"{mage1.Name} tries to equip {weapon1.name}");

Weapon weapon2 = new Weapon("Magic Stick", 1, WeaponType.Wand, 10);
Console.WriteLine($"{mage1.Name} tries to equip {weapon2.name}");

Armor armor1 = new Armor(ArmorType.Cloth, "Cheap plastic suit", 1, new(1,1,1,0,0,0), Slot.Body, 1);
Console.WriteLine($"{mage1.Name} is wearing {armor1.name} on his body");

Armor helmet1 = new Armor(ArmorType.Cloth, "Cheap plastic helmet", 1, new(1,1,1,0,0,0), Slot.Head, 1);
Console.WriteLine($"{mage1.Name} is wearing {helmet1.name} on his head");

Armor boots1 = new Armor(ArmorType.Cloth, "Nike", 1, new(1,1,1,0,0,0), Slot.Legs, 1);
Console.WriteLine($"{mage1.Name} is wearing {boots1.name} on his feet");

mage1.Damage() // mage does damage with no weapon equipped
mage1.EquipWeapon(weapon1); // mage tries to equip sword - should be exception
mage1.EquipWeapon(weapon2); // mage tries to equip wand - should be correct weapon type
mage1.Damage() // mage does damage with wand equipped
mage1.EquipArmor(armor1);
mage1.EquipArmor(helmet1);
mage1.EquipArmor(boots1);
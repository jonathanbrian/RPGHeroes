using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Exceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {
             Console.WriteLine("Invalid choice of weapon. Required level is too high, or you are not allowed to equip this weapon");
        }
    }
}

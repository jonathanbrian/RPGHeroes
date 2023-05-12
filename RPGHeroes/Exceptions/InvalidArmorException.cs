using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Exceptions
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {
            Console.WriteLine("Invalid choice of armor. Required level is too high, or you are not allowed to equip this armor");
        }
    }
}

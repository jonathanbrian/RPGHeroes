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
            Console.WriteLine("This armor is not valid for this hero");
        }
    }
}

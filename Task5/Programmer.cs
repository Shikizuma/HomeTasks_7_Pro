using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    [AccessLevel(2)]
    internal class Programmer
    {
        public void AccessProtectedSection()
        {
            Console.WriteLine("Програміст має доступ до захищеної секції.");
        }
    }
}

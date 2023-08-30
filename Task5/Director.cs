using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    [AccessLevel(3)]
    internal class Director
    {
        public void AccessProtectedSection()
        {
            Console.WriteLine("Директор має доступ до захищеної секції.");
        }
    }
}

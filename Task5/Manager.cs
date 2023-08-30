using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    [AccessLevel(1)] 
    public class Manager
    {
        public void AccessProtectedSection()
        {
            Console.WriteLine("Менеджер має доступ до захищеної секції.");
        }
    }
}

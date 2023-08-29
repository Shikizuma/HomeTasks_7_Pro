using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class TestObsolete
    {
        [Obsolete("Цей метод застарілий, його не можна використовувати", true)]
        public void TestMethod()
        {
            Console.WriteLine("Застарілий метод");
        }

        [Obsolete("Цей метод устарів.")]
        public void TestMethod(string name)
        {
            Console.WriteLine($"Привіт, {name}");
        }
        public void TestMethod(string name, int age)
        {
            Console.WriteLine($"Привіт, {name}. Тобі {age} років");
        }
    }
}

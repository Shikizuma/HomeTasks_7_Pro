using System.IO;
using System.Reflection;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> employees = new List<object>
            {
                new Manager(),
                new Programmer(),
                new Director()
            };

            foreach (var employee in employees)
            {
                Type employeeType = employee.GetType();
                AccessLevelAttribute accessAttribute = employeeType.GetCustomAttribute<AccessLevelAttribute>();

                if (accessAttribute != null)
                {
                    int accessLevel = accessAttribute.AccessLevel;
                    Console.WriteLine($"Спроба доступу співробітника рівня {accessLevel}:");
                    Console.Write("Реакція системи: ");
                    if (accessLevel == 3)
                    {
                        var accessMethod = employeeType.GetMethod("AccessProtectedSection");
                        accessMethod.Invoke(employee, null);
                    }
                    else
                    {
                        Console.WriteLine("Доступ заборонено.");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
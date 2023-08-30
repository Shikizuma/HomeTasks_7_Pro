using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AccessLevelAttribute : Attribute
    {
        public int AccessLevel { get; }

        public AccessLevelAttribute(int accessLevel)
        {
            AccessLevel = accessLevel;
        }
    }
}

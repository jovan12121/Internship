using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    public abstract class Person
    {
        string name;
        string lastName;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }
        public abstract void Speak();
    }
}

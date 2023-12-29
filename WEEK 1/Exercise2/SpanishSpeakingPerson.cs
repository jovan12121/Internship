using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    public class SpanishSpeakingPerson : Person
    {
        public SpanishSpeakingPerson(string name, string lastName) : base(name, lastName)
        {
        }

        public override void Speak()
        {
            Console.WriteLine("Holla");
        }
    }
}

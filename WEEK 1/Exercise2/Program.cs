namespace Zadatak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>(); 
            persons.Add(new SpanishSpeakingPerson("Sergio","Ramos"));
            persons.Add(new EnglishSpeakingPerson("John", "Terry"));
            foreach (Person person in persons)
            {
                person.Speak();
            }
        }
    }
}

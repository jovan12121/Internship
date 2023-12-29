namespace Zadatak4
{
    internal class Program
    {
        static void SayHi(ITest test)
        {
            test.SayHi();
        }
        static void Main(string[] args)
        {
            EnglishHi englishHi = new EnglishHi();
            SpanishHi spanishHi = new SpanishHi();
            SayHi(englishHi);
            SayHi(spanishHi);
        }
    }
}

namespace Zadatak5
{
    internal class Program
    {
        static void ChangeValue(int i)
        {
            i = 55;
        }
        static void ChangeValue(TestClass test)
        {
            test.Number = 444;
        }
        static void Main(string[] args)
        {
            int i = 11;
            ChangeValue(i);
            Console.WriteLine(i);
            TestClass test = new TestClass() { Number = 5 };
            ChangeValue(test);
            Console.WriteLine(test.Number);
        }
    }
}

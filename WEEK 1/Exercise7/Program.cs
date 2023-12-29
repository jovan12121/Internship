namespace Zadatak7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Insert 1st number:");
                double firstNumber = double.Parse(Console.ReadLine());
                Console.WriteLine("Insert 2nd number:");
                double secondNumber = double.Parse(Console.ReadLine());
                if(secondNumber==0)
                    throw new DivideByZeroException();
                double result = firstNumber/secondNumber;
                Console.WriteLine(result);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("You cannot divide by zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

namespace Zadatak1
{
    internal class Program
    {
        static string ReverseString(string s)
        {
            string reversedString = string.Empty;
            for (int i = s.Length-1;i>-1;i--)
            {
                reversedString += s[i];
            }
            return reversedString;
        }
        static int CalculateNumberOfVowels(string s)
        {
            int numberOfVowels = 0;
            foreach(char c in s)
            {
                if(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    numberOfVowels++;
                }
            }
            return numberOfVowels;
        }
        static bool IsStringPalindrome(string s)
        {
            for (int i = 0,j = s.Length-1; i < j; i++,j--)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
            }
            return true;
        }
        static int CalculateNumberOfWords(string s) => s.Split(new char[] { ',', ' ', '.', ':', ';', '?', '!' }).Length;

        static void Main(string[] args)
        {
            string[] stringsArray = new string[] {"Ja sam jovan","rotor","Hello world!" };
            foreach (string s in stringsArray)
            {
                Console.WriteLine("Reversed string:" + ReverseString(s));
                Console.WriteLine("Number of vowels:" + CalculateNumberOfVowels(s));
                Console.WriteLine("String is palindrome:" + IsStringPalindrome(s));
                Console.WriteLine("Number of words: " + CalculateNumberOfWords(s));
                Console.WriteLine();
            }

        }
    }
}

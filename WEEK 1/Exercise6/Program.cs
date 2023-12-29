namespace Zadatak6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Queue<int> queue = new Queue<int>();
            Stack <int> stack = new Stack<int>();
            Dictionary<int,int> dict = new Dictionary<int,int>();

            list.Add(55);
            Console.WriteLine(list[list.IndexOf(55)]);
            list.Remove(55);

            queue.Enqueue(55);
            queue.Enqueue(15);
            int qRetVal = queue.Dequeue();
            Console.WriteLine(qRetVal);

            stack.Push(55);
            stack.Push(1111);
            Console.WriteLine(stack.Pop());

            dict.Add(5, 11);
            dict[5] = 24;
            foreach (KeyValuePair<int,int> item in dict)
            {
                Console.WriteLine(item.Value);
            }

        }
    }
}

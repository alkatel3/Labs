using MyList;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> items = new();
            //Console.WriteLine(items.Contains(1));
            //Console.WriteLine(items.IndexOf(6));
            items.Add(1);
            items.Add(2);
            items.Add(3);
            items.Add(4);
            items.Add(2);
            items.Add(2);
            items.Add(3);
            items.Add(4);
            items.Add(6);
            foreach (int item in items)
            {
                Console.WriteLine(item) ;
            }
            Console.WriteLine();
            Console.WriteLine(items.Count);
            Console.WriteLine();

            List<T>
            //for (int i = 0; i < 7; i++)
            //{
            //    Console.WriteLine(items.Contains(i));
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    Console.WriteLine(items.IndexOf(i));
            //}






            //items.Remove(2);
            //foreach (int item in items)
            //{
            //    Console.WriteLine(item);
            //}
            //items.RemoveAt(10);

            //var Array = new int[10];
            //items.CopyTo(Array, 3);
            //foreach (int item in Array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();
            //Console.WriteLine(Array.Length);
        }
    }
}
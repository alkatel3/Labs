namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new();
           // items.Add(1);
           // items.Add(2);
          //  items.Add(3);
            //items.Add(4);
            Console.WriteLine(items.IndexOf(5));
            items.Insert(0, 0);
            //items.Insert(5, 0);

            foreach(int item in items)
            {
                Console.WriteLine(item) ;
            }
        }
    }
}
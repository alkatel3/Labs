using MyList;
using System.Collections.ObjectModel;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<string> strings = new MyList<string>();
            strings.Add("sas");
            strings.Add("sdf");
            strings.Add("asf");
            strings.Add("wge");
            strings.Add(null);

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(strings.Contains(null));
            Console.WriteLine(strings.IndexOf(null));

            //List<string> strings2 = new List<string>();
            //strings2.Add("sas");
            //strings2.Add("sdf");
            //strings2.Add("asf");
            //strings2.Add("wge");
            //strings2.Add(null);

            //foreach (var item in strings2)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(strings2.Contains(null));
            //Console.WriteLine(strings2.IndexOf(null));

            //MyList<int> items = new();
            ////Console.WriteLine(items.Contains(1));
            ////Console.WriteLine(items.IndexOf(6));
            //items.Add(1);
            //items.Add(2);
            //items.Add(3);
            //items.Add(4);
            //items.Add(2);
            //items.Add(2);
            //items.Add(3);
            //items.Add(4);
            //items.Add(6);

            //foreach (int item in items)
            //{
            //    Console.WriteLine(item) ;
            //}
            //Console.WriteLine();

            //List<string> list = new()
            //{
            //    "1","2","3","4"
            //};
            //Console.WriteLine(list.Remove(null));
            ////list.Insert(list.Count,1);
            ////foreach(var item in list)
            ////{
            ////    Console.WriteLine(item);
            ////}
            ////foreach (int item in items)
            ////{
            ////    Console.WriteLine(item);
            ////}

            ////for (int i = 0; i < 7; i++)
            ////{
            ////    Console.WriteLine(items.Contains(i));
            ////}

            ////for (int i = 0; i < 7; i++)
            ////{
            ////    Console.WriteLine(items.IndexOf(i));
            ////}

            //for (int i = 0; i <= items.Count; i += 2)
            //{
            //    items.Insert(i, i + 10);
            //}
            //foreach (int item in items)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();
            //for (int i=0; i <= items.Count; i++)
            //{
            //    Console.WriteLine(items.Remove(i));
            //}
            //Console.WriteLine(items.Remove(14));
            //Console.WriteLine(items.Remove(28));
            //items.Clear();
            //Console.WriteLine();
            //Console.WriteLine(items.Remove(14));
            //foreach (int item in items)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            ////items.Remove(2);
            ////foreach (int item in items)
            ////{
            ////    Console.WriteLine(item);
            ////}
            ////items.RemoveAt(10);

            ////var Array = new int[10];
            ////items.CopyTo(Array, 3);
            ////foreach (int item in Array)
            ////{
            ////    Console.WriteLine(item);
            ////}
            ////Console.WriteLine();
            ////Console.WriteLine(Array.Length);
        }
    }
}
using MyList;
using System.Collections.ObjectModel;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons=new MyList<Person>();

            persons.AddEvent += Add;
            persons.ChangeEvent += Change;
            persons.CopyEvent += Copy;
            persons.RemoveEvent += Remove;

            persons.Clear();
            Console.WriteLine(persons.Contains(null));
            Console.WriteLine(persons.Contains(new Person("Dan",18)));

            Console.WriteLine(persons.IndexOf(null));
            Console.WriteLine(persons.IndexOf(new Person("Dan", 18)));

            Console.WriteLine(persons.Remove(null));
            Console.WriteLine(persons.Remove(new Person("Dan", 18)));


            var ArrayPersons = new Person[6];
            persons.CopyTo(ArrayPersons, 0);

            foreach(var item in persons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            persons.Add(new("Oleg", 20));
            persons.Add(new("Olya", 19));
            persons.Add(new("Mary", 22));
            persons.Add(new("Sem", 25));
            persons.Add(new("Bob", 34));
            persons.Add(null);

            persons[1] = null;
            persons[0] = new("Roman", 23);
            persons.CopyTo(ArrayPersons, 0);
            persons.AddRange(ArrayPersons);

            foreach (var item in persons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            persons.Clear();
            foreach (var item in persons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            persons.AddRange(ArrayPersons);
            persons.AddRange(ArrayPersons);
            foreach (var item in persons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine(persons.Contains(new("Roman", 23)));
            Console.WriteLine(persons.IndexOf(new("Oleg", 20)));
            Console.WriteLine(persons.IndexOf(null));
            Console.WriteLine(persons.IndexOf(new("Roman", 23)));
            Console.WriteLine(persons.Remove(null));
            Console.WriteLine(persons.Remove(null));
            Console.WriteLine(persons.IndexOf(null));
            Console.WriteLine(persons.Remove(null));
            Console.WriteLine(persons.Remove(null));
            Console.WriteLine(persons.IndexOf(null));
            Console.WriteLine(persons.Remove(null));
            Console.WriteLine(persons.IndexOf(null));
            foreach (var item in persons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            persons.RemoveAt(0);
            foreach (var item in persons)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(persons.Count);
            persons.IsReadOnly = true;
            //persons.Clear();
        }

        private static void Remove(object? sender, Person e)
        {
            if (sender is MyList<Person> list)
            {
                Console.WriteLine($"{e} removed from {list}");
            }
        }

        private static void Copy(object? sender, Person e)
        {
            if (sender is MyList<Person> list)
            {
                Console.WriteLine($"{list} copied");
            }
        }

        private static void Change(object? sender, Person e)
        {
            if (sender is MyList<Person> list)
            {
                Console.WriteLine($"Changed one element in {list} new data of this list is {e}");
            }
        }

        private static void Add(object? sender, Person e)
        {
            if(sender is MyList<Person> list)
            {
                Console.WriteLine($"Added {e} to {list}");
            }
        }
    }
}
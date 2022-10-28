namespace Lab1
{
    public class Person
    {
        private string Name;
        private int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Person person)
            {
                return person.Name.Equals(Name) && person.Age.Equals(Age);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return (Name.GetHashCode() ^ Age);
        }
    }
}

using System.Collections;

namespace MyList
{
    public class MyList<T> :  IList<T>, IEnumerable<T>
    {
        private Item<T> Head;
        private Item<T> Tail;

        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly => IsReadOnly;

        public bool IsReadOnly = false;//TODO

        public MyList()
        {
            Count = 0;
            Head = Tail = null;
        }
        public MyList(IEnumerable<T> collection)
        {
            Count = 0;
            foreach(T item in collection)
            {
                Add(item);
            }
        }

        public T this[int index] { 
            get 
            {
                if(index >= Count||index<0)
                {
                    throw new ArgumentOutOfRangeException();//TODO
                }
                var current = Head;
                var currentIndex = 0;
                while(current != null)
                {
                    if (currentIndex == index)
                    {
                        return current.Data;
                    }
                    currentIndex++;
                    current = current.Next;
                }
                return current.Data;
            }
            set 
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();//TODO
                }
                var current = Head;
                var currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        current.Data=value;
                    }
                    currentIndex++;
                    current = current.Next;
                }
            }
        }

        public void Add(T item)
        {
            if(item == null)
            {
                throw new NotSupportedException();//TODO
            }
            if(Count == 0)
            {
                Head = Tail = new Item<T>(item);
                Count++;
                return;
            }
            else
            {
                var Item = new Item<T>(item);
                Item.Previous = Tail;
                Tail.Next = Item;
                Tail = Item;
                Count++;
            }
        }
        public void Clear()
        {
            Count = 0;
            Head = Tail = null;
        }
        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new NotSupportedException();//TODO
            }
            var result = false;
            if (item == null)
            {
                return result;
            }
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    result = true;
                    break;
                }
                current = current.Next;
            }
            return result;
        }
        public int IndexOf(T item)
        {

            int result = -1;
            if (item == null)
            {
                return result;
            }
            var current = Head;
            var currentIndex = 0;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    result = currentIndex;
                    break;
                }
                currentIndex++;
                current = current.Next;
            }

            return result;
        }
        public void Insert(int index, T item)
        {
            if (item == null)
            {
                throw new NotSupportedException();//TODO
            }
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();//TODO
            }
            else if (index == Count)
            {
                Add(item);
            }
            else if (index == 0)
            {
                var Item = new Item<T>(item);
                Item.Next = Head;
                Head.Previous = Item;
                Head = Item;
            }
            else
            {
                var current = Head;
                var currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        var Item = new Item<T>(item);
                        current.Previous.Next = Item;
                        Item.Previous = current.Previous;
                        Item.Next = current;
                        current.Previous=Item;
                        Count++;
                        break;
                    }
                    current = current.Next;
                    currentIndex++;
                }
            }
        }
        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new NotSupportedException();//TODO
            }
            var result = false;
            if (Count == 0)
            {
                return result;
            }
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    result=true;
                    Count--;
                    break;
                }
                current=current.Next;
            }

            return result;
        }
        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();//TODO
            }
            if (index == 0)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else if (index == Count - 1)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                var current = Head;
                int currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        current.Next.Previous = current.Previous;
                        current.Previous.Next = current.Next;
                        Count--;
                        break;
                    }
                    current = current.Next;
                    currentIndex++;
                }
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();//TODO
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();//TODO
            }
            else if (arrayIndex>=array.Length||Count>array.Length-arrayIndex)//TODO
            {
                throw new ArithmeticException();//TODO
            }
            else
            {
                var Current = Head;
                for (int i = arrayIndex;
                    Current != null&&i < array.Length;
                    i++, Current=Current.Next)
                {
                    array[i] = Current.Data;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
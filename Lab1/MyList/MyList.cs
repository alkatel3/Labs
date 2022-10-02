using System.Collections;

namespace MyList
{
    public class MyList<T> :  IList<T>
    {
        private Item<T> Head;
        private Item<T> Tail;
        //public int Capacity { get; set; }
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

        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly => IsReadOnly;//TODO

        public bool IsReadOnly =false;//TODO

        public void Add(T item)
        {
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
            var result = false;
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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

        public int IndexOf(T item)
        {
            if(Count == 0)
            {
                return -1;
            }
            int result = -1;

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
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }
}
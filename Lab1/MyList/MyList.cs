using System.Collections;

namespace MyList
{
    public class MyList<T> :  IList<T>
    {
        private Item<T>? Head;
        private Item<T>? Tail;
        public event EventHandler<T> AddEvent;
        public event EventHandler<T> RemoveEvent;
        public event EventHandler<T> CopyEvent;
        public event EventHandler<T> ChangeEvent;


        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly => IsReadOnly;//TODO

        public bool IsReadOnly = false;//TODO

        public MyList()
        {
            Clear();
        }
        public MyList(IEnumerable<T> collection)
        {
            Count = 0;
            AddRange(collection);
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
                        OnEvent(ChangeEvent, value);//TODO
                    }
                    currentIndex++;
                    current = current.Next;
                }
            }
        }       //TODO

        public void Add(T item)
        {
            var Item = new Item<T>(item);
            if (Count == 0)
            {
                Head = Tail = Item;
            }
            else
            {
                Item.Previous = Tail;
                Tail.Next = Item;
                Tail = Item;
            }
            Count++;
            OnEvent(AddEvent, item);
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();//TODO
            }
            foreach(var item in collection)
            {
                Add(item);
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
                if (current.Data?.Equals(item) ?? item == null)
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
            var current = Head;
            var currentIndex = 0;
            while (current != null)
            {
                if (current.Data?.Equals(item) ?? item == null)
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
                Count++;
                OnEvent(AddEvent, item);
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
                        current.Previous = Item;
                        Count++;
                        OnEvent(AddEvent, item);
                        break;
                    }
                    current = current.Next;
                    currentIndex++;
                }
            }
        }
        public bool Remove(T item)
        {
            var result = false;
            if(Count == 0 || item == null)
            {
                return result;
            }
            if (Head.Data.Equals(item))
            {
                RemoveFirst();
                result = true;
                return result;
                OnEvent(RemoveEvent, item);
            }
            var current = Head.Next;
            while (current.Next != null)
            {
                if (current.Data.Equals(item))
                {
                    RemoveCurrent(current);
                    result=true;
                    OnEvent(RemoveEvent, item);
                    break;
                }
                current=current.Next;
            }
            if (Tail.Data.Equals(item))
            {
                RemoveLast();
                OnEvent(RemoveEvent, item);
                result = true;
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
                OnEvent(RemoveEvent, Head.Data);
                RemoveFirst();

            }
            else if (index == Count - 1)
            {
                OnEvent(RemoveEvent, Tail.Data);
                RemoveLast();
            }
            else
            {
                var current = Head;
                int currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        OnEvent(RemoveEvent, current.Data);
                        RemoveCurrent(current);
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
            else if (arrayIndex >= array.Length || Count > array.Length - arrayIndex)//TODO
            {
                throw new ArithmeticException();//TODO
            }
            else
            {
                var Current = Head;
                for (int i = arrayIndex;
                    Current != null && i < array.Length;
                    i++, Current = Current.Next)
                {
                    array[i] = Current.Data;
                }
            }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        protected virtual void OnEvent(EventHandler<T> SomeEvent, T e)
        {
            SomeEvent?.Invoke(this, e);
        }
        private void RemoveLast()
        {
            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
        }
        private void RemoveFirst()
        {
            Head = Head.Next;
            Head.Previous = null;
            Count--;
        }
        private void RemoveCurrent(Item<T> current)
        {
            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            Count--;
        }
    }
}


﻿using System.Collections;

namespace MyList
{
    public class MyList<T> : IList<T>
    {
        private Item<T>? Head;
        private Item<T>? Tail;
        public event EventHandler<T> AddEvent;
        public event EventHandler<T> RemoveEvent;
        public event EventHandler<T> CopyEvent;
        public event EventHandler<T> ChangeEvent;
        private delegate void ChangeByIndex(T newElement, Item<T> current);


        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly => IsReadOnly;//TODO

        public bool IsReadOnly = false;

        public MyList()
        {
            Clear();
        }
        public MyList(IEnumerable<T> collection)
        {
            Count = 0;
            AddRange(collection);
        }

        public T this[int index]
        {
            get
            {
                CheckingCorrectnessIndex(index);
                var current = Head;
                var currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        break;
                    }
                    currentIndex++;
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                CheckingIsReadOnly();
                CheckingCorrectnessIndex(index);
                FindingByIndex(index, value, (value, current)=>current.Data=value);
                OnEvent(ChangeEvent, value);
            }
        }

        public void Add(T item)
        {
            CheckingIsReadOnly();
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
            CheckingIsReadOnly();
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "The collection cannot be null");
            }
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public void Clear()
        {
            CheckingIsReadOnly();
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
            CheckingIsReadOnly();
            CheckingCorrectnessIndex(index);
            if (index == Count)
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
                OnEvent(AddEvent, item);
                FindingByIndex(index, item, InsertItem);
            }
        }
        public bool Remove(T item)
        {
            CheckingIsReadOnly();
            var result = false;
            if (Count == 0)
            {
                return result;
            }
            if (Head.Data?.Equals(item) ?? item == null)
            {
                RemoveFirst();
                result = true;
                OnEvent(RemoveEvent, item);
            }
            else if (Tail.Data?.Equals(item) ?? item == null)
            {
                RemoveLast();
                OnEvent(RemoveEvent, item);
                result = true;
            }
            else
            {
                var current = Head.Next;
                while (current.Next != null)
                {
                    if (current.Data?.Equals(item) ?? item == null)
                    {
                        RemoveCurrent(item, current);
                        result = true;
                        break;
                    }
                    current = current.Next;
                }
            }
            return result;
        }
        public void RemoveAt(int index)
        {
            CheckingIsReadOnly();
            CheckingCorrectnessIndex(index);
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
                FindingByIndex(index, default(T), RemoveCurrent);
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "The array cannot be null");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The index must be not less than zero");
            }
            else if (arrayIndex >= array.Length || Count > array.Length - arrayIndex)
            {
                throw new ArgumentException(nameof(array), $"The array cannot contain the {this} starting at {arrayIndex}");
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

                OnEvent(CopyEvent, default(T));
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
        private void CheckingCorrectnessIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The index must be less than count and not less than zero");
            }
        }        
        private void FindingByIndex(int index, T value, ChangeByIndex action)
        {
            var current = Head;
            var currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    action(value, current);
                    break;
                }
                currentIndex++;
                current = current.Next;
            }
        }
        private void InsertItem(T item, Item<T>? current)
        {
            var Item = new Item<T>(item);
            current.Previous.Next = Item;
            Item.Previous = current.Previous;
            Item.Next = current;
            current.Previous = Item;
            Count++;
            OnEvent(AddEvent, item);
        }
        private void RemoveCurrent(T item, Item<T>? current)
        {
            OnEvent(RemoveEvent, current.Data);
            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            Count--;
        }
        private void CheckingIsReadOnly()
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("It's list only for reading, if you want change this list, specify IsReadOnly=false");
            }
        }

    }

}


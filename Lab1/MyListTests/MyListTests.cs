using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Collections;

namespace MyList.Tests
{
    [TestClass()]
    public class MyListTests
    {
        MyList<int> list=new();
        MyList<string> strings= new();
        int[] testArray = new int[]
        {
            1, 2, 3, 4
        };

        [TestMethod()]
        public void MyListTest()
        {
            list.Count.Should().Be(0);
            list.Should().BeEmpty();
        }

        [TestMethod()]
        public void MyListTest1()
        {
            list.AddRange(testArray);
            var myList = new MyList<int>(list);
            myList.Count.Should().Be(4);
            myList.Should().AllBeOfType<int>();
            myList.Should().StartWith(1);
            myList.Should().Contain(list);
            myList.Should().HaveElementAt(1, 2);
            myList.Should().EndWith(4);
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add(12);
            list.Count.Should().Be(1);
            list.Add(15);
            list.Count.Should().Be(2);
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            list.AddRange(testArray);
            list.Count.Should().Be(4);
            list.Should().AllBeOfType<int>();
            list.Should().StartWith(1);
            list.Should().Contain(list);
            list.Should().HaveElementAt(1, 2);
            list.Should().EndWith(4);
        }

        [TestMethod()]
        public void ClearTest()
        {
            list.AddRange(testArray);
            list.Should().NotBeEmpty();
            list.Clear();
            list.Should().BeEmpty();
            list.Count.Should().Be(0);
            
        }

        [TestMethod()]
        public void ContainsTest()
        {
            list.AddRange(testArray);
            strings.Add(null);
            strings.Contains(null).Should().BeTrue();
            list.Contains(1).Should().BeTrue();
            list.Contains(2).Should().BeTrue();
            list.Contains(4).Should().BeTrue();
            list.Contains(5).Should().BeFalse();
            list.Contains(0).Should().BeFalse();
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            list.AddRange(testArray);
            strings.Add(null);
            strings.IndexOf(null).Should().Be(0);
            list.IndexOf(1).Should().Be(0);
            list.IndexOf(2).Should().Be(1);
            list.IndexOf(4).Should().Be(3);
            list.IndexOf(10).Should().Be(-1);
            list.IndexOf(0).Should().Be(-1);
        }

        [TestMethod()]
        public void InsertTest()
        {
            list.AddRange(testArray);
            list.Insert(0, 10);
            list.Insert(2, 20);
            list.Insert(list.Count, 30);

            list[0].Should().Be(10);
            list[2].Should().Be(20);
            list[^1].Should().Be(30);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            strings.Remove(null).Should().BeFalse();
            list.Remove(10).Should().BeFalse();

            list.AddRange(testArray);
            strings.Add(null);
            strings.Add("Hello");
            strings.Add(null);
            strings.Add("C#");
            strings.Add("!");
            strings.Add(null);

            strings.Remove(null).Should().BeTrue();
            strings.Remove(null).Should().BeTrue();
            strings.Remove(null).Should().BeTrue();
            strings.Remove("Hello");

            list.Remove(1).Should().BeTrue();
            list.Remove(3).Should().BeTrue();
            list.Remove(-1).Should().BeFalse();
            list.Contains(1).Should().BeFalse();
            list.Remove(4).Should().BeTrue();
            list.Count.Should().Be(1);
            
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            list.AddRange(testArray);
            list.RemoveAt(0);
            list.RemoveAt(1);
            list.RemoveAt(list.Count-1);

            list.Count.Should().Be(1);
        }

        [TestMethod()]
        public void CopyToTest()
        {
            list.AddRange(testArray);
            var array=new int[4];
            list.CopyTo(array, 0);
            array.Should().BeEquivalentTo(list);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            list.AddRange(testArray);
            int i = 0;
            foreach(var item in list)
            {
                item.Should().Be(testArray[i]);
                i++;
            }
        }

        [TestMethod()]
        public void ReadOnlyByCollectionTest()
        {
            ICollection<int> list2 = list;
            list2?.IsReadOnly.Should().BeFalse();
        }

        [TestMethod()]
        public void IndexerTest()
        {
            list.AddRange(testArray);
            list[0] = 10;
            list[3] = 30;
            list[2] = 20;
            list[0].Should().Be(10);
            list[3].Should().Be(30);
            list[2].Should().Be(20);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[-1]);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[5]);
        }

        [TestMethod()]
        public void AddRangeExeptionTest()
        {
            Assert.ThrowsException<ArgumentNullException>(()=>list.AddRange(null));
            list.IsReadOnly = true;
            Assert.ThrowsException<InvalidOperationException>(() => list.AddRange(testArray));
        }

        [TestMethod()]
        public void ClearExeptionTest()
        {
            list.IsReadOnly = true;
            Assert.ThrowsException<InvalidOperationException>(() => list.Clear());
        }

        [TestMethod()]
        public void AddExeptionTest()
        {
            list.IsReadOnly = true;
            Assert.ThrowsException<InvalidOperationException>(() => list.Add(5));
        }

        [TestMethod()]
        public void InsertExeptionTest()
        {
            list.AddRange(testArray);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(5, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(-1, 10));
            list.IsReadOnly = true;
            Assert.ThrowsException<InvalidOperationException>(() => list.AddRange(testArray));
        }

        [TestMethod()]
        public void CopyToExeptionTest()
        {
            list.AddRange(testArray);
            int[]? Array = null;
            Assert.ThrowsException<ArgumentNullException>(() => list.CopyTo(Array, 10));
            Array = new int[4];
            Assert.ThrowsException<ArgumentException>(() => list.CopyTo(Array, 2));
            Assert.ThrowsException<ArgumentException>(() => list.CopyTo(Array, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.CopyTo(Array, -1));
        }

        [TestMethod()]
        public void IEnumerableGetEnumeratorTest()
        {
            IEnumerable values = list;

            values.GetEnumerator().Current.Should().Be(list.GetEnumerator().Current);


        }

        [TestMethod()]
        public void EventsTest()
        {
            list.AddRange(testArray);
            using var monitor = list.Monitor();

            list.Add(10);
            monitor.Should().Raise("AddEvent").WithSender(list);

            list.Remove(10);
            monitor.Should().Raise("RemoveEvent").WithSender(list);

            var ints = new int[5];
            list.CopyTo(ints, 0);
            monitor.Should().Raise("CopyEvent").WithSender(list);

            list[0] = 10;
            monitor.Should().Raise("ChangeEvent").WithSender(list);
        }
    }
}
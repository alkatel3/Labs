using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace MyList.Tests
{
    [TestClass()]
    public class MyListTests
    {
        MyList<int>? list;
        int[]? testArray;

        [TestInitialize]
        public void TestsInit()
        {
            list =new MyList<int>();
            testArray = new int[] 
            {
                1, 2, 3, 4 
            };
        }

        [TestMethod()]
        public void MyListTest()
        {
            list?.Count.Should().Be(0);
            list.Should().BeEmpty();
        }

        [TestMethod()]
        public void MyListTest1()
        {
            list?.AddRange(testArray);
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
            list?.Add(12);
            list?.Count.Should().Be(1);
            list?.Add(15);
            list?.Count.Should().Be(2);
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            list?.AddRange(testArray);
            list?.Count.Should().Be(4);
            list.Should().AllBeOfType<int>();
            list.Should().StartWith(1);
            list.Should().Contain(list);
            list.Should().HaveElementAt(1, 2);
            list.Should().EndWith(4);
        }

        [TestMethod()]
        public void ClearTest()
        {
            list?.AddRange(testArray);
            list.Should().NotBeEmpty();
            list?.Clear();
            list.Should().BeEmpty();
            list?.Count.Should().Be(0);
            
        }

        [TestMethod()]
        public void ContainsTest()
        {
            list?.AddRange(testArray);
            list?.Contains(1).Should().BeTrue();
            list?.Contains(2).Should().BeTrue();
            list?.Contains(4).Should().BeTrue();
            list?.Contains(5).Should().BeFalse();
            list?.Contains(0).Should().BeFalse();
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            list?.AddRange(testArray);
            list?.IndexOf(1).Should().Be(0);
            list?.IndexOf(2).Should().Be(1);
            list?.IndexOf(4).Should().Be(3);
            list?.IndexOf(10).Should().Be(-1);
            list?.IndexOf(0).Should().Be(-1);
        }

        [TestMethod()]
        public void InsertTest()
        {
            list?.AddRange(testArray);
            list?.Insert(0, 10);
            list?.Insert(2, 20);
            list?.Insert(list.Count, 30);

            list?[0].Should().Be(10);
            list?[2].Should().Be(20);
            list?[list.Count-1].Should().Be(30);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            list?.AddRange(testArray);
            list?.Remove(1).Should().BeTrue();
            list?.Remove(-1).Should().BeFalse();

            list?.Contains(1).Should().BeFalse();
        }

        //[TestMethod()]
        //public void RemoveAtTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void CopyToTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetEnumeratorTest()
        //{
        //    Assert.Fail();
        //}
    }
}
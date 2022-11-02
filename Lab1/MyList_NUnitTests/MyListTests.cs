namespace MyList_NUnitTests
{
    public class Tests
    {
        MyList<int> list;
        MyList<string> strings;
        int[] testArray;

        [SetUp]
        public void Setup()
        {
            list = new();
            strings = new();
            testArray = new int[]
            {
               1, 2, 3, 4
            };
        }

        [Test]
        public void MyList_CreatList_CreatedEmptyList()
        {
            list.Count.Should().Be(0);
            list.Should().BeEmpty();
        }

        [Test]
        public void MyList_CreatListBasedIEnumerable_CreatedWithElements()
        {
            List<int> list = new List<int>(testArray);

            var myList = new MyList<int>(list);

            myList.Count.Should().Be(4);
            myList.Should().AllBeOfType<int>();
            myList.Should().StartWith(1);
            myList.Should().Contain(list);
            myList.Should().HaveElementAt(1, 2);
            myList.Should().EndWith(4);
        }

        [Test]
        public void Add_AddingElement_AddedElement()
        {
            list.Add(12);
            list.Should().HaveElementAt(0, 12);

            list.Add(15);
            list.Should().HaveElementAt(1, 15);
        }

        [Test]
        public void AddRange_AddindCollection_AddedCollection()
        {
            list.AddRange(testArray);

            list.Count.Should().Be(4);
            list.Should().Contain(testArray);
            list.Should().HaveElementAt(1, 2);
            list.Should().EndWith(4);
        }

        [Test]
        public void Clear_RemoveAllElements_EmptyList()
        {
            list.AddRange(testArray);

            list.Should().NotBeEmpty();

            list.Clear();
            list.Should().BeEmpty();
            list.Count.Should().Be(0);
        }

        [Test]
        public void Contains_FindingElement_ReturnBoolResult()
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

        [Test]
        public void IndexOf_FindingElement_ReturnElement()
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

        [Test]
        public void Insert_InsertElementByIndex_AddedElementByIndex()
        {
            list.AddRange(testArray);
            list.Insert(0, 10);
            list.Insert(2, 20);
            list.Insert(list.Count, 30);

            list[0].Should().Be(10);
            list[2].Should().Be(20);
            list[^1].Should().Be(30);
        }

        [Test]
        public void Remove_RemovingFirstEntryElement_RemovedElement()
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

        [Test]
        public void RemoveAt_RemovingElementByIndex_RemovedElement()
        {
            list.AddRange(testArray);
            list.RemoveAt(0);
            list.RemoveAt(1);
            list.RemoveAt(list.Count - 1);

            list.Count.Should().Be(1);
        }

        [Test]
        public void CopyTo_CopyingListToArrayFromIndex_ArrayContainsList()
        {
            list.AddRange(testArray);

            var array = new int[5];
            list.CopyTo(array, 1);

            array.Should().Contain(list);
        }

        [Test]
        public void GetEnumerator_GetingListEnumerator_ReturnEnumerator()
        {
            list.AddRange(testArray);
            int i = 0;
            foreach (var item in list)
            {
                item.Should().Be(testArray[i]);
                i++;
            }
        }

        [Test]
        public void ReadOnlyByCollectionTest()
        {
            ICollection<int> list2 = list;
            list2?.IsReadOnly.Should().BeFalse();
        }

        [Test]
        public void Indexer_SetElementByIndex_ReturnElementByIndex()
        {
            list.AddRange(testArray);

            list[0] = 10;
            list[3] = 30;
            list[2] = 20;

            list[0].Should().Be(10);
            list[3].Should().Be(30);
            list[2].Should().Be(20);
        }

        [Test]
        public void AddRange_NullCollectin_ThrowArgumentNullException()
        {
            Action act= () => list.AddRange(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddRange_AddRangeToReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;
            Action act = () => list.AddRange(testArray);
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Clear_ClearReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;
            Action act = () => list.Clear();
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Add_AddToReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;
            Action act = () => list.Add(5);
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Insert_InsertElementsOutOfListRange_ThrowArgumentOutOfRangeException()
        {
            list.AddRange(testArray);

            Action act1 = () => list.Insert(5, 10);
            Action act2 = () => list.Insert(-1, 10);

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void RemoveAt_RemoveElementsOutOfListRange_ThrowArgumentOutOfRangeException()
        {
            list.AddRange(testArray);

            Action act1 = () => list.RemoveAt(-1);
            Action act2 = () => list.RemoveAt(5);

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void CopyTo_CopyToNullArray_ThrowArgumentNullException()
        {
            int[]? Array = null;

            Action act = () => list.CopyTo(Array, 10);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void CopyTo_ArrayCantContainList_ThrowArgumentException()
        {
            list.AddRange(testArray);
            var Array = new int[4];

            Action act1 = () => list.CopyTo(Array, 10);
            Action act2 = () => list.CopyTo(Array, 2);

            act1.Should().Throw<ArgumentException>();
            act2.Should().Throw<ArgumentException>();
        }

        [Test]2
        public void CopyTo_InputIndexMoreArrayLenght_ThrowArgumentOutOfRangeException()
        {
            list.AddRange(testArray);
            var Array = new int[4];

            Action act = () => list.CopyTo(Array, -1);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void IEnumerableGetEnumeratorTest()
        {
            IEnumerable values = list;

            values.GetEnumerator().Current.Should().Be(list.GetEnumerator().Current);
        }

        [Test]
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
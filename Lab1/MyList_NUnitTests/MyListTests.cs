namespace MyList_NUnitTests
{
    public class Tests
    {
        MyList<int> list;
        MyList<string> strings;
        int[] testIntArrayCount4;

        [SetUp]
        public void Setup()
        {
            list = new();
            strings = new();
            testIntArrayCount4 = new int[]
            {
               1, 2, 3, 4
            };
        }

        [Test]
        public void MyList_CreatList_CreatedEmptyList()
        {
            list.Should().HaveCount(0);
            list.Should().BeEmpty();
        }

        [Test]
        public void MyList_CreatListBasedIEnumerable_CreatedWithElements()
        {
            List<int> list = new List<int>(testIntArrayCount4);

            var myList = new MyList<int>(list);

            myList.Should().HaveCount(4);
            myList.Should().StartWith(1);
            myList.Should().Contain(list);
            myList.Should().HaveElementAt(1, 2);
            myList.Should().EndWith(4);
        }

        [Test]
        public void MyList_TakeNullArgument_ThrowArgumentNullExctption()
        {
            var action =()=> new MyList<int>(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Add_AddingIntElement_AddedElement()
        {
            list.Add(12);
            list.Should().HaveElementAt(0, 12);

            list.Add(15);
            list.Should().HaveElementAt(1, 15);
        }

        [Test]
        public void Add_AddingNullElement_AddedElement()
        {
            strings.Add(null);

            strings.Should().HaveElementAt(0, null);
            strings.Should().HaveCount(1);
        }

        [Test]
        public void Add_AddToReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;

            Action act = () => list.Add(5);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void AddRange_AddindCollection_AddedCollection()
        {
            list.AddRange(testIntArrayCount4);

            list.Should().HaveCount(4);
            list.Should().Contain(testIntArrayCount4);
            list.Should().HaveElementAt(1, 2);
            list.Should().EndWith(4);
        }

        [Test]
        public void AddRange_NullCollectin_ThrowArgumentNullException()
        {
            Action act = () => list.AddRange(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddRange_AddRangeToReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;
            Action act = () => list.AddRange(testIntArrayCount4);
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void IndexerSet_SetElementByIndex_ElementLocatedByIndex()
        {
            list.AddRange(testIntArrayCount4);

            list[0] = 10;
            list[3] = 30;
            list[2] = 20;

            list.Should().HaveElementAt(0, 10);
            list.Should().HaveElementAt(3, 30);
            list.Should().HaveElementAt(2, 20);
        }

        [Test]
        public void IndexerGet_GetElementByIndex_ReturnElementByIndex()
        {
            list.AddRange(testIntArrayCount4);

            list[0].Should().Be(1);
            list[3].Should().Be(4);
            list[2].Should().Be(3);
        }

        [Test]
        public void Clear_RemoveAllElements_EmptyList()
        {
            list.AddRange(testIntArrayCount4);

            list.Clear();

            list.Should().BeEmpty();
            list.Count.Should().Be(0);
        }

        [Test]
        public void Clear_ClearReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;

            Action act = () => list.Clear();

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Contains_FindingIntElementFirstElement_ReturnTrue()
        {
            list.AddRange(testIntArrayCount4);

            bool result = list.Contains(1);

            result.Should().BeTrue();
        }

        [Test]
        public void Contains_FindingIntElementInsideElement_ReturnTrue()
        {
            list.AddRange(testIntArrayCount4);

            bool result = list.Contains(2);

            result.Should().BeTrue();
        }

        [Test]
        public void Contains_FindingIntElementLastElement_ReturnTrue()
        {
            list.AddRange(testIntArrayCount4);

            bool result = list.Contains(4);

            result.Should().BeTrue();
        }

        [Test]
        public void Contains_FindingIntElementDidntFind_ReturnFalse()
        {
            list.AddRange(testIntArrayCount4);

            bool result1 = list.Contains(5);
            bool result2 = list.Contains(0);

            result1.Should().BeFalse();
            result2.Should().BeFalse();
        }

        [Test]
        public void Contains_FindingNullElement_ReturnTrue()
        {
            strings.Add(null);

            bool result = strings.Contains(null);

            result.Should().BeTrue();
        }

        [Test]
        public void Contains_FindingNullElement_ReturnFalse()
        {
            strings.Add("Hello C#");

            bool result = strings.Contains(null);

            result.Should().BeFalse();
        }

        [Test]
        public void Contains_FindingElementEmptyList_ReturnFalse()
        {
            bool result = strings.Contains(null);

            result.Should().BeFalse();
        }

        [Test]
        public void IndexOf_FindingIndexFirstElement_ReturnZero()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.IndexOf(1);

            result.Should().Be(0);
        }

        [Test]
        public void IndexOf_FindingIndexInsideElement_ReturnIndex()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.IndexOf(2);

            result.Should().Be(1);
        }

        [Test]
        public void IndexOf_FindingIndexLastElement_ReturnIndex()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.IndexOf(4);

            result.Should().Be(3);
        }

        [Test]
        public void IndexOf_FindingIngexAbsentElement_ReturnNegativeOne()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.IndexOf(10);

            result.Should().Be(-1);
        }

        [Test]
        public void IndexOf_FindingIndexNullElement_ReturnIngex()
        {
            strings.Add(null);

            var result = strings.IndexOf(null);

            result.Should().Be(0);
        }

        [Test]
        public void IndexOf_FindingAbsentNullElement_ReturnNegativeOne()
        {
            strings.Add("Hello C#");

            var result = strings.IndexOf(null);

            result.Should().Be(-1);
        }

        [Test]
        public void IndexOf_FindingInEmptyList_ReturnNegativeOne()
        {
            var result=strings.IndexOf(null);

            result.Should().Be(-1);
        }

        [Test]
        public void Insert_InsertElementByIndex_AddedElementByIndex()
        {
            list.AddRange(testIntArrayCount4);
            list.Insert(0, 10);
            list.Insert(2, 20);
            list.Insert(list.Count, 30);

            list[0].Should().Be(10);
            list[2].Should().Be(20);
            list[^1].Should().Be(30);
        }

        [Test]
        public void Insert_InsertFirstElement_AddedNewFirstElement()
        {
            list.AddRange(testIntArrayCount4);

            list.Insert(0, 10);

            list.Should().HaveElementAt(0,10);
        }

        [Test]
        public void Insert_InsertLastElement_AddedEndElement()
        {
            list.AddRange(testIntArrayCount4);

            list.Insert(list.Count, 30);

            list.Should().HaveElementAt(4,30);
        }

        [Test]
        public void Insert_InsertInsideElement_AddedElementInsideList()
        {
            list.AddRange(testIntArrayCount4);

            list.Insert(2, 20);

            list.Should().HaveElementAt(2,20);
        }

        [Test]
        public void Insert_InsertNullElement_AddedNullElementByIndex()
        {
            strings.Insert(0, null);

            strings.Should().HaveElementAt(0, null);
        }

        [Test]
        public void Insert_InsertToReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;

            Action act = () => list.Insert(0, 10);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Insert_InsertElementsOutOfListRange_ThrowArgumentOutOfRangeException()
        {
            list.AddRange(testIntArrayCount4);

            Action act1 = () => list.Insert(5, 10);
            Action act2 = () => list.Insert(-1, 10);

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Remove_RemoveFirstElement_ReturnTrue()
        {
            list.AddRange(testIntArrayCount4);

            var result =list.Remove(1);

            result.Should().BeTrue();
        }

        [Test]
        public void Remove_RemoveLastElement_ReturnTrue()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.Remove(4);

            result.Should().BeTrue();
        }

        [Test]
        public void Remove_RemovingInsideElement_ReturnTrue()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.Remove(3);

            result.Should().BeTrue();    
        }

        [Test]
        public void Remove_RemoveAbsentElement_ReturnFalse()
        {
            list.AddRange(testIntArrayCount4);

            var result = list.Remove(-1);

            result.Should().BeFalse();
        }

        [Test]
        public void Remove_RemoveFirstNullElement_ReturnTrue()
        {
            strings.Add(null);

            var result = strings.Remove(null);

            result.Should().BeTrue();
        }

        [Test]
        public void Remove_RemoveLastNullElement_ReturnTrue()
        {
            strings.Add(null);
            strings.Add("Hello");

            var result = strings.Remove(null);

            result.Should().BeTrue();
        }

        [Test]
        public void Remove_RemoveInsideNullElement_ReturnTrue()
        {
            strings.Add("Hello");
            strings.Add(null);
            strings.Add("C#");

            var result = strings.Remove(null);

            result.Should().BeTrue();
        }

        [Test]
        public void Remove_RemovingNullFromEmptyList_ReturnFalse()
        {
            var result = strings.Remove(null);

            result.Should().BeFalse();
        }

        [Test]
        public void Remove_RemovingIntFromEmptyList_ReturnFalse()
        {
            var result = list.Remove(14);

            result.Should().BeFalse();
        }

        [Test]
        public void Remove_RemovingElementFromReadOnlyList_ThrowInvalidOperationExeption()
        {
            list.IsReadOnly = true;

            var action = () => list.Remove(123);

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void RemoveAt_RemovingFirstElement_RemovedElement()
        {
            list.AddRange(testIntArrayCount4);

            list.RemoveAt(0);

            list.Should().HaveElementAt(0, 2);
            list.Should().HaveCount(3);
        }

        [Test]
        public void RemoveAt_RemovingInsideElement_RemovedElement()
        {
            list.AddRange(testIntArrayCount4);

            list.RemoveAt(1);

            list.Should().HaveElementAt(1, 3);
            list.Should().HaveCount(3);
        }

        [Test]
        public void RemoveAt_RemovingLastElement_RemovedElement()
        {
            list.AddRange(testIntArrayCount4);

            list.RemoveAt(3);

            list.Should().HaveCount(3);
        }

        [Test]
        public void RemoveAt_RemoveElementsOutOfListRange_ThrowArgumentOutOfRangeException()
        {
            list.AddRange(testIntArrayCount4);

            Action act1 = () => list.RemoveAt(-1);
            Action act2 = () => list.RemoveAt(5);

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void RemoveAt_RemoveElementFromReadOnlyList_ThrowInvalidOperationException()
        {
            list.IsReadOnly = true;

            Action act = () => list.RemoveAt(10);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void CopyTo_CopyingListToArrayFromIndex_ArrayContainsList()
        {
            list.AddRange(testIntArrayCount4);
            var array = new int[5];

            list.CopyTo(array, 1);

            array.Should().Contain(list);
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
            list.AddRange(testIntArrayCount4);
            var Array = new int[4];

            Action act1 = () => list.CopyTo(Array, 10);
            Action act2 = () => list.CopyTo(Array, 2);

            act1.Should().Throw<ArgumentException>();
            act2.Should().Throw<ArgumentException>();
        }

        [Test]
        public void CopyTo_InputIndexMoreArrayLenght_ThrowArgumentOutOfRangeException()
        {
            list.AddRange(testIntArrayCount4);
            var Array = new int[4];

            Action act = () => list.CopyTo(Array, -1);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetEnumerator_GetingListEnumerator_ReturnEnumerator()
        {
            list.AddRange(testIntArrayCount4);
            int i = 0;
            foreach (var item in list)
            {
                item.Should().Be(testIntArrayCount4[i]);
                i++;
            }
        }

        [Test]
        public void IEnumerableGetEnumeratorTest()
        {
            IEnumerable values = list;
            var expected = list.GetEnumerator().Current;

            var actual = values.GetEnumerator().Current;

            actual.Should().Be(expected);
        }

        [Test]
        public void ReadOnlyByCollectionTest()
        {
            ICollection<int> list2 = list;

            var actual = list2.IsReadOnly;

            actual.Should().BeFalse();
        }

        [Test]
        public void AddEvent_InvokeMethodAdd_RaiseAddEvent()
        {
            using var monitor = list.Monitor();

            list.Add(10);

            monitor.Should().Raise("AddEvent").WithSender(list);
        }

        [Test]
        public void RemoveEvent_InvokeMethodRemove_RaiseRemoveEvent()
        {
            list.AddRange(testIntArrayCount4);
            using var monitor = list.Monitor();

            list.Remove(2);

            monitor.Should().Raise("RemoveEvent").WithSender(list);
        }

        [Test]
        public void CopyEvent_InvokeMethodCopyTo_RaiseCopyEvent()
        {
            list.AddRange(testIntArrayCount4);
            var ints = new int[5];
            using var monitor = list.Monitor();

            list.CopyTo(ints, 0);

            monitor.Should().Raise("CopyEvent").WithSender(list);
        }

        [Test]
        public void ChangeEvent_ChangeElementByIndex_RaiseChangeEvent()
        {
            list.AddRange(testIntArrayCount4);
            using var monitor = list.Monitor();

            list[0] = 10;

            monitor.Should().Raise("ChangeEvent").WithSender(list);
        }
    }
}
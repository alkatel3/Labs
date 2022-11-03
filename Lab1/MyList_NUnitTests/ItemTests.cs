namespace MyList.Tests
{
    public class ItemTests
    {
        [Test]
        public void Item_CreatElementWithDataTen_DataMustBeTen()
        {
            var item = new Item<int>(10);

            var actual=item.Data;

            actual.Should().Be(10);
        }

        [Test]
        public void ToString_DataIsAny_ReturnDataToString()
        {
            var expected = "Hello";
            var item = new Item<string>(expected);
            
            var actual=item.ToString();

            actual.Should().Be(expected);
        }

        [Test]
        public void ToString_DataIsNull_ReturtStringNull()
        {
            var expected = "null";
            var item = new Item<string>(null);

            var actual = item.ToString();

            actual.Should().Be(expected);
        }
    }
}
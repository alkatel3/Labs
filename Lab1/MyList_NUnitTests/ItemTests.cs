namespace MyList.Tests
{
    public class ItemTests
    {
        [Test]
        public void ItemTest()
        {
            var item = new Item<int>(10);
            item.Data.Should().Be(10);
        }

        [Test]
        public void ToStringTest()
        {
            var item = new Item<string>("Hello");
            item.ToString().Should().Be("Hello");
            item.Data = null;
            item.ToString().Should().Be("null");
        }
    }
}
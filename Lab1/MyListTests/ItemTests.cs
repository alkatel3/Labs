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
    public class ItemTests
    {
        [TestMethod()]
        public void ItemTest()
        {
            var item = new Item<int>(10);
            item.Data.Should().Be(10);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var item = new Item<string>("Hello");
            item.ToString().Should().Be("Hello");
            item.Data = null;
            item.ToString().Should().Be("null");
        }
    }
}
using System.Linq;
using Xunit;

namespace ExtremeCarpaccio.UnitTests
{
    public class BillerTests
    {
        [Fact]
        public void Empty_Order_Returns_0()
        {
            var sut = new Biller();
            var order = new Order("FR", "PayThePrice", Enumerable.Empty<Item>());

            var actual = sut.ComputeOrder(order);

            Assert.Equal(0, actual);
        }
        [Fact]
        public void PayThePrice_France_Returns_64_26()
        {
            var sut = new Biller();
            var order = new Order("FR", "PayThePrice", new[] {
                    new Item(15.3m, 3),
                    new Item(7.65m, 1)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(64.26m, actual);
        }
        [Fact]
        public void PayThePrice_UK_Returns_160_51()
        {
            var sut = new Biller();
            var order = new Order("UK", "PayThePrice", new[] {
                    new Item(45.2m, 2),
                    new Item(8.45m, 5)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(160.51m, actual);
        }
        [Fact]
        public void PayThePrice_Portugal_Returns_307_09()
        {
            var sut = new Biller();
            var order = new Order("PT", "PayThePrice", new[] {
                    new Item(30.1m, 3),
                    new Item(35.88m, 4),
                    new Item(3.17m, 5)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(307.09m, actual);
        }
        [Fact]
        public void HalfPrice_France_Returns_226_95()
        {
            var sut = new Biller();
            var order = new Order("FR", "HalfPrice", new[] {
                    new Item(20.26m, 7),
                    new Item(26.27m, 9)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(226.95m, actual);
        }
        [Fact]
        public void HalfPrice_UK_Returns_159_78()
        {
            var sut = new Biller();
            var order = new Order("UK", "HalfPrice", new[] {
                    new Item(22.06m, 8),
                    new Item(43.81m, 2)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(159.78m, actual);
        }
        [Fact]
        public void HalfPrice_Portugal_Returns_1189_31()
        {
            var sut = new Biller();
            var order = new Order("PT", "HalfPrice", new[] {
                    new Item(214.87m, 9)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(1189.31m, actual);
        }
        [Fact]
        public void Standard_NoReduction_Returns_63_05()
        {
            var sut = new Biller();
            var order = new Order("FR", "Standard", new[] {
                    new Item(26.27m, 2)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(63.05m, actual);
        }
        [Fact]
        public void Standard_3_Percent_Returns_355_61()
        {
            var sut = new Biller();
            var order = new Order("UK", "Standard", new[] {
                    new Item(100.18m, 1),
                    new Item(15.6m, 13)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(355.61m, actual);
        }
        [Fact]
        public void Standard_5_Percent_Returns_746_34()
        {
            var sut = new Biller();
            var order = new Order("PT", "Standard", new[] {
                    new Item(32.62m, 6),
                    new Item(43.45m, 4),
                    new Item(67.3m, 4)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(746.34m, actual);
        }
        [Fact]
        public void Standard_7_Percent_Returns_787_92()
        {
            var sut = new Biller();
            var order = new Order("FR", "Standard", new[] {
                    new Item(32.62m, 6),
                    new Item(43.45m, 4),
                    new Item(67.3m, 5)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(787.92m, actual);
        }
        [Fact]
        public void Standard_10_Percent_Returns_159_78()
        {
            var sut = new Biller();
            var order = new Order("UK", "Standard", new[] {
                    new Item(73.45m, 7),
                    new Item(33.99m, 5),
                    new Item(78.12m, 8)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(1425.57m, actual);
        }
        [Fact]
        public void Standard_15_Percent_Returns_5850_53()
        {
            var sut = new Biller();
            var order = new Order("PT", "Standard", new[] {
                    new Item(82.24m, 10),
                    new Item(92.55m, 5),
                    new Item(44.16m, 9),
                    new Item(30.5m, 59),
                    new Item(82.57m, 9),
                    new Item(152.3m, 9)
            });

            var actual = sut.ComputeOrder(order);

            Assert.Equal(5850.53m, actual);
        }
    }
}

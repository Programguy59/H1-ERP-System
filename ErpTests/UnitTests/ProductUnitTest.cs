using H1_ERP_System.products;

namespace ErpTests.UnitTests
{
    public class ProductUnitTest
    {
        Product testProduct = new Product(1,"testName","testDesc",25,20,"aaaa",1,Unit.Piece);

        [Fact]
        public void EarningsTest()
        {
            Assert.Equal(5, testProduct.GetEarnings());
        }

        [Fact]
        public void MarginTest()
        {
            Assert.Equal(25, testProduct.GetProfitMargin());
        }

    }
}
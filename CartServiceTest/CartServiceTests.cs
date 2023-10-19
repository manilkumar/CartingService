namespace CartServiceTest
{
    [TestClass]
    public class CartServiceTests: TestBase
    {
        [TestMethod]
        public async Task GetCartItems()
        {
            Guid cartId = Guid.NewGuid();
            var items = cartController.GetItems(cartId);
            Assert.IsNotNull(items);
        }
    }
}
using SwagProject.Driver;
using SwagProject.Pages;

namespace SwagProject.Test
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
        }
        [TearDown]
        public void ClosePage()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC01_AddTwoProductInCart_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));
        }
    }
}
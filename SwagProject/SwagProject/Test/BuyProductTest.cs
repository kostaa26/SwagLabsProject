using Docker.DotNet.Models;
using OpenQA.Selenium;
using SwagProject.Driver;
using SwagProject.Pages;
using System;

namespace SwagProject.Test
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        CardPage cardPage;
        
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new CardPage();
            
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
        [Test]
        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.SelectOption("Price (high to low)");

            Assert.That(productPage.SortByPrice.Displayed);
        }
        [Test]

        public void TC03_GoToAboutPage_ShouldRedactionToNewPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/",Is.EqualTo(WebDrivers.Instance.Url));
        }
        [Test]
        public void TC04_BUyProducts_ShouldBeFinishedShopping()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            cardPage.ShoppingCardClick.Click();
            cardPage.Checkout.Click();
            cardPage.FirstName.SendKeys("Kosta");
            cardPage.LastName.SendKeys("Blag");
            cardPage.ZipCode.SendKeys("11000");
            cardPage.ButtonContinue.Submit();
            cardPage.Finish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(cardPage.OrderFinished.Text));


        }
    }
}
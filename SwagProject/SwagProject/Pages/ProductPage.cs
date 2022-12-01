using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagProject.Pages
{
    public class ProductPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement AddBackPack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));

        public IWebElement AddT_Shirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));

        public IWebElement Cart => driver.FindElement(By.CssSelector("#shopping_cart_container .shopping_cart_badge"));

        public IWebElement SortByPrice => driver.FindElement(By.ClassName("product_sort_container"));

        public IWebElement MenuClick => driver.FindElement(By.Id("react-burger-menu-btn"));

        public IWebElement AboutClick => driver.FindElement(By.Id("about_sidebar_link"));

        
        public void SelectOption(string text)
        {
            SelectElement element = new SelectElement(SortByPrice);
            element.SelectByText(text);
        }
    }
}

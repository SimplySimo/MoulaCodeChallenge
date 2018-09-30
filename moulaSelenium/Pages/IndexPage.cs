using NUnit.Framework;
using OpenQA.Selenium;

namespace MoulaSeleniumTest.Pages
{
    internal class IndexPage : BasePage
    {
        private readonly By createNewCustomerButton = By.XPath("//a[contains(text(),'Create Customer')]");
        private readonly By successMessage = By.XPath("//div[@class='alert alert-success fade in']");
        private readonly By tableRows = By.XPath("//table[@class='table']//tbody/tr");

        public IndexPage(IWebDriver incomingDriver) : base(incomingDriver)
        {
            Assert.That(driver.Title, Is.EqualTo("Moula Code Challenge"));
        }

        internal int GetTableCount()
        {
            return driver.FindElements(tableRows).Count;
        }

        internal CustomerCreationPage NavigateToCreationPage(IWebDriver driver)
        {
            driver.FindElement(createNewCustomerButton).Click();
            return new CustomerCreationPage(driver);
        }

        internal bool IsSuccessMessageDisplayed()
        {
            return IsDisplayed(successMessage);
        }
    }
}

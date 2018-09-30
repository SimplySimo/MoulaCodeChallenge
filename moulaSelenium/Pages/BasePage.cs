using OpenQA.Selenium;

namespace MoulaSeleniumTest.Pages
{
    class BasePage
    {
        public IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SendKeys(By locator, string inputString)
        {
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(inputString);
        }

        public bool IsDisplayed(By locator)
        {
            try
            {
                IWebElement element = driver.FindElement(locator);
                return element.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public string GetText(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            return element.Text;
        }

        public void Click(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            element.Click();
        }

        public void ClearField(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            element.Clear();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MoulaSeleniumTest.Steps
{
    public class DriverUtils
    {
        public IWebDriver driver;

        [BeforeScenario]
        public void DriverSetup()
        {
            driver = new ChromeDriver
            {
                Url = "http://localhost:49841/"
            };
        }

        [AfterScenario]
        public void Teardown()
        {
            driver.Quit();
        }

    }
}

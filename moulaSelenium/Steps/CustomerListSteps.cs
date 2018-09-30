using MoulaSeleniumTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MoulaSeleniumTest.Steps
{
    [Binding]
    public sealed class CustomerListsSteps : DriverUtils
    {
        IndexPage indexPage;

        [Given(@"I am on the index page")]
        public void GivenIAmOnTheIndexPage()
        {
            indexPage = new IndexPage(driver);
        }

        [Then(@"there should only be (.*) visable records")]
        public void ThenThereShouldOnlyBeVisableRecords(int expectedCount)
        {
            int count = indexPage.GetTableCount();

            Assert.AreEqual(count, expectedCount);
        }

    }
}

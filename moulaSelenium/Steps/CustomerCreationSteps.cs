using MoulaCodeChallenge.Models;
using MoulaCodeChallenge.Steps;
using MoulaSeleniumTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MoulaSeleniumTest.Steps
{
    [Binding]
    public sealed class CustomerCreationSteps : DriverUtils
    {
        Customer newCustomer = new Customer();
        CustomerCreationPage customerCreationPage;
        IndexPage indexPage;

        [Given(@"I am on the add new Customer page")]
        public void GivenIAmOnTheAddNewCustomerPage()
        {
            indexPage = new IndexPage(driver);
            customerCreationPage = indexPage.NavigateToCreationPage(driver);
        }

        [Given(@"I have a new customer to insert")]
        public void GivenIHaveANewCustomerToInsert()
        {
            newCustomer = new Customer()
            {
                FirstName = "George",

                LastName = Utils.RandomString(5),
                DateOfBirth = new System.DateTime(2000, 04, 04),
                Email = "Run@theDeathStar.com",
                PersonId = 10
            };
        }

        [When(@"I enter the details")]
        public void WhenIEnterTheDetails()
        {
            customerCreationPage.InsertValues(newCustomer);
        }


        [When(@"I insert an (.*) value into (.*)")]
        public void WhenIInsertAnValueInto(string valueToModify, string field)
        {
            customerCreationPage.InsertValues(newCustomer);

            switch (field)
            {
                case "firstname":
                    customerCreationPage.EnterFirstnameValue(valueToModify);
                    break;
                case "lastname":
                    customerCreationPage.EnterLastnameValue(valueToModify);
                    break;
                case "dob":
                    customerCreationPage.EnterDateOfBirthValue(valueToModify);
                    break;
                case "email":
                    customerCreationPage.EnterEmailValue(valueToModify);
                    break;
            }
        }

        [When(@"I select create")]
        public void WhenISelectCreate()
        {
            indexPage = customerCreationPage.SelectCreate();
        }

        [When(@"I select create and expect no action")]
        public void WhenISelectCreateAndExpectNoAction()
        {
            customerCreationPage.SelectCreateNoAction();
        }

        [Then(@"A success message is shown")]
        public void ThenASuccessMessageIsShown()
        {
            Assert.IsTrue(indexPage.IsSuccessMessageDisplayed());
        }


        [Then(@"I expect the (.*) error message for (.*)")]
        public void ThenIExpectTheAErrorMessage(string message, string field)
        {
            string validationText = customerCreationPage.GetValidationErrorMessage(field);

            Assert.AreEqual(message, validationText, "Incorrect validation message returned");
        }
    }
}

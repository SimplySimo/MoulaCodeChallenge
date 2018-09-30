using NUnit.Framework;
using OpenQA.Selenium;

namespace MoulaSeleniumTest.Pages
{
    internal class CustomerCreationPage : BasePage
    {
        private readonly By firstnameInput = By.XPath("//input[@id='FirstName']");
        private readonly By firstnameError = By.XPath("//span[@id='FirstName-error']");
        private readonly By lastnameInput = By.XPath("//input[@id='LastName']");
        private readonly By lastnameError = By.XPath("//span[@id='LastName-error']");
        private readonly By dobInput = By.XPath("//input[@id='DateOfBirth']");
        private readonly By dobError = By.XPath("//span[@id='DateOfBirth-error']");
        private readonly By emailInput = By.XPath("//input[@id='email']");
        private readonly By emailError = By.XPath("//span[@id='email-error']");
        private readonly By createButton = By.XPath("//input[@value='Create']");

        public CustomerCreationPage(IWebDriver driver) : base(driver)
        {
            Assert.That(driver.Title, Is.EqualTo("Create a Customer"));
        }

        internal void InsertValues(MoulaCodeChallenge.Models.Customer newCustomer)
        {
            SendKeys(firstnameInput, newCustomer.FirstName);
            SendKeys(lastnameInput, newCustomer.LastName);
            SendKeys(dobInput, newCustomer.DateOfBirth.ToString("MM/dd/yyyy"));
            SendKeys(emailInput, newCustomer.Email);
        }

        internal void EnterEmailValue(string email)
        {
            ClearField(emailInput);
            SendKeys(emailInput, email);
        }

        internal void EnterFirstnameValue(string firstname)
        {
            ClearField(firstnameInput);
            SendKeys(firstnameInput, firstname);
        }

        internal void EnterLastnameValue(string lastname)
        {
            ClearField(lastnameInput);
            SendKeys(lastnameInput, lastname);
        }

        internal IndexPage SelectCreate()
        {
            Click(createButton);

            return new IndexPage(driver);
        }

        internal void SelectCreateNoAction()
        {
            Click(createButton);
        }

        internal void EnterDateOfBirthValue(string dob)
        {
            ClearField(dobInput);
            SendKeys(dobInput, dob);
        }

        internal string GetValidationErrorMessage(string field)
        {
            string text = "";
            switch (field)
            {
                case "firstname":
                    text = GetText(firstnameError);
                    break;
                case "lastname":
                    text = GetText(lastnameError);
                    break;
                case "dob":
                    text = GetText(dobError);
                    break;
                case "email":
                    text = GetText(emailError);
                    break;
            }
            return text;
        }
    }
}

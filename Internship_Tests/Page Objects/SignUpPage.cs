using System;
using System.Threading;
using OpenQA.Selenium;

namespace Internship_Tests.PageObjects
{
    public class SignUpPage : LoginModule
    {

        By firstNameInput = By.Name("firstName");
        By lastNameInput = By.Name("lastName");
        By emailInput = By.Name("email");
        By passwordInput = By.Name("password");
        By passwordConfirmInput = By.Name("confirmPassword");
        By signUpButton = By.CssSelector(".AuthButton_button__2ukbQ");
        By registrationMessageError = By.CssSelector(".ErrorMessage_submitErrorMessage__DqlrJ");

        public By RegistrationMessageError
        {
            get
            {
                return registrationMessageError;
            }

        }


        public SignUpPage(IWebDriver driver) : base(driver) { }


        public SignUpPage TypeFirstName(string firstName)
        {
            driver.FindElement(firstNameInput).Clear();
            driver.FindElement(firstNameInput).SendKeys(firstName);
            return this;
        }

        public SignUpPage TypeLastName(string lastName)
        {
            driver.FindElement(lastNameInput).Clear();
            driver.FindElement(lastNameInput).SendKeys(lastName);
            return this;
        }

        public SignUpPage TypeEmail(string email)
        {
            driver.FindElement(emailInput).Clear();
            driver.FindElement(emailInput).SendKeys(email);
            return this;
        }

        public SignUpPage TypePassword(string password)
        {
            driver.FindElement(passwordInput).Clear();
            driver.FindElement(passwordInput).SendKeys(password);
            return this;
        }

        public SignUpPage TypePasswordConfirm(string passwordConfirm)
        {
            driver.FindElement(passwordConfirmInput).Clear();
            driver.FindElement(passwordConfirmInput).SendKeys(passwordConfirm);
            return this;
        }

        public SignUpPage ClickRegisterButton()
        {
            driver.FindElement(signUpButton).Click();
            return this;
        }

        public string GetRegistrationErrorMessage()
        {
            IWebElement registrationMessageErrorText = driver.FindElement(registrationMessageError);
            return registrationMessageErrorText.Text;
        }
    }
}

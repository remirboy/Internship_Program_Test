using System;
using OpenQA.Selenium;

namespace Internship_Tests.PageObjects
{
    public class SignInPage : LoginModule
    {
        By emailInput = By.Name("email");
        By passwordInput = By.Name("password");
        By signInButton = By.CssSelector(".AuthButton_button__2ukbQ");
        By rememberMeCheckbox = By.CssSelector(".RememberMeCheckbox_checkboxText__2e7Ov");

        public SignInPage(IWebDriver driver) : base(driver) { }


        public SignInPage TypeEmail(string email)
        {
            driver.FindElement(emailInput).SendKeys(email);
            return this;
        }

        public SignInPage TypePassword(string password)
        {
            driver.FindElement(passwordInput).SendKeys(password);
            return this;
        }

        public SignInPage ClickSignInButton()
        {
            driver.FindElement(signInButton).Click();
            return this;
        }
    }
}

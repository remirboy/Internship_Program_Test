using System;
using OpenQA.Selenium;

namespace Internship_Tests.PageObjects
{
    public class LoginModule : PageObject
    {
        By signUpTab = By.LinkText("Sign Up");
        By signInTab= By.LinkText("Login");

        public LoginModule(IWebDriver driver) : base(driver) { }


        public LoginModule ClickSignUpTab()
        {
            driver.FindElement(signUpTab).Click();
            return this;
        }

        public LoginModule ClickSignInTab()
        {
            driver.FindElement(signInTab).Click();
            return this;
        }

    }
}

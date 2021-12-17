using System;
using OpenQA.Selenium;
using Internship_Tests.PageObjects;
using Internship_Tests.Models;

namespace Internship_Tests.Helpers
{
    public class LoginHelper : BaseHelper
    {
        
        

        public LoginHelper(IWebDriver driver) : base(driver) { }


        public void Registrate(User user)
        {
            SignUpPage signUpPage = new SignUpPage(driver);
            SignUpCredentialsInput(user, signUpPage).RegistrationSubmit(signUpPage);
        }

        public void RegistrateWithoutPassword(User user)
        {
            SignUpPage signUpPage = new SignUpPage(driver);
            SignUpCredentialsInputWithoutPassword(user, signUpPage).RegistrationSubmit(signUpPage);
        }

        public void Login(User user)
        {
            SignInPage signInPage = new SignInPage(driver);
            MainPage mainPage = new MainPage(driver);

            if (IsLoggedIn(mainPage))
            {
                LogOut(mainPage);
            }

            SignInCredentialsInput(user, signInPage).LoginSubmit(signInPage);

            if (IsLoggedIn(mainPage))
            {
                return;
            }
        }



        public bool IsLoggedIn(MainPage mainPage)
        {
            return mainPage.IsElementPresent(By.TagName("header"));
        }


        private LoginHelper SignUpCredentialsInput(User user, SignUpPage signUpPage)
        {
            signUpPage.TypeFirstName(user.FirstName).
                TypeLastName(user.LastName).
                TypeEmail(user.Email).
                TypePassword(user.Password).
                TypePasswordConfirm(user.Password);
            return this;
        }


        private LoginHelper SignUpCredentialsInputWithoutPassword(User user, SignUpPage signUpPage)
        {
            signUpPage.TypeFirstName(user.FirstName).
                TypeLastName(user.LastName).
                TypeEmail(user.Email);
            return this;
        }

        private LoginHelper SignInCredentialsInput(User user, SignInPage signInPage)
        {
            signInPage.TypeEmail(user.Email).
                TypePassword(user.Password);
            return this;
        }

        private LoginHelper RegistrationSubmit(SignUpPage signUpPage)
        {
            signUpPage.ClickRegisterButton();
            return this;
        }

        private LoginHelper LoginSubmit(SignInPage signInPage)
        {
            signInPage.ClickSignInButton();
            return this;
        }

        private LoginHelper LogOut(MainPage mainPage)
        {
            mainPage.ClickLogoutButton();
            return this;
        }

        public void MoveToLoginForm()
        {
            LoginModule loginModule = new LoginModule(driver);
            loginModule.ClickSignInTab();
        }

        public void MoveToRegistrationForm()
        {
            LoginModule loginModule = new LoginModule(driver);
            loginModule.ClickSignUpTab();
        }

        public bool IsUserCredentialsIsValid()
        {
            SignUpPage signUpPage = new SignUpPage(driver);
            signUpPage.WaitShowElement(signUpPage.RegistrationMessageError);
            if (signUpPage.GetRegistrationErrorMessage().Equals("Failed to sign up. Incorrect input data"))
                return false;
            else
                return true;
        }


    }
}

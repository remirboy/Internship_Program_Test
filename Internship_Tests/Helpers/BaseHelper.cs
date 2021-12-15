using System;
using OpenQA.Selenium;

namespace Internship_Tests.Helpers
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected ApplicationManager app;

        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}

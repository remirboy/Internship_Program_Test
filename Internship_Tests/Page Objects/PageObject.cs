using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Internship_Tests.PageObjects
{
    public class PageObject
    {
        protected IWebDriver driver;

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitShowElement(By iClassName)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5000));
            wait.Until(drv => drv.FindElement(iClassName));
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Internship_Tests.PageObjects
{
    public class StreamOptionsMenu : PageObject
    {


        By openStreamDetailsOption = By.LinkText("Open Stream details");


        public StreamOptionsMenu(IWebDriver driver) : base(driver) { }

        public StreamOptionsMenu ClickOpenStreamDetails()
        {
            {
                var element = driver.FindElement(openStreamDetailsOption);
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
                element.Click();
              
               
            }
            return this;
        }

    }
}

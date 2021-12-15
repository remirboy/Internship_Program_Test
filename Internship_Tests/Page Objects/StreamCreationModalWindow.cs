using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Internship_Tests.PageObjects
{
    public class StreamCreationModalWindow : PageObject
    {
        By streamNameInput = By.Name("name");
        By streamDescriptionInput = By.XPath("/html/body/div[2]/div/form/div[1]/div[2]/textarea");
        By streamStartDateInput = By.Name("startDate");
        By streamEndDateInput = By.Name("endDate");
        By streamStartDate = By.CssSelector(".react-datepicker__day--017");
        By streamEndDate = By.CssSelector(".react-datepicker__day--025");
        By streamCreationButton = By.XPath("//*[@id='modalRoot']/div/form/div[2]/button[2]");
        By streamCreationConfirmButton = By.CssSelector(".PrimaryBtn_button__1R1Yo");

        public StreamCreationModalWindow(IWebDriver driver) : base(driver) { }

        public StreamCreationModalWindow TypeName(string name)
        {
            driver.FindElement(streamNameInput).Clear();
            driver.FindElement(streamNameInput).SendKeys(name);
            return this;
        }

        public StreamCreationModalWindow TypeDescription(string description)
        {
            driver.FindElement(streamDescriptionInput).Clear();
            driver.FindElement(streamDescriptionInput).SendKeys(description);
            return this;
        }

        public StreamCreationModalWindow ChooseStartDate()
        {
            driver.FindElement(streamStartDateInput).Click();
            driver.FindElement(streamStartDate).Click();
            return this;
        }

        public StreamCreationModalWindow ChooseEndDate()
        {
            driver.FindElement(streamEndDateInput).Click();
            driver.FindElement(streamEndDate).Click();
            return this;
        }

        public StreamCreationModalWindow ClickStreamCreationButton()
        {
            driver.FindElement(streamCreationButton).Click();
            return this;
        }

        public StreamCreationModalWindow ClickStreamCreationConfirmButton()
        {
            driver.FindElement(streamCreationConfirmButton).Click();
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            return this;
        }
    }
}

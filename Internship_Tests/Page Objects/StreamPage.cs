using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Internship_Tests.PageObjects
{
    public class StreamPage : PageObject
    {
        public StreamPage(IWebDriver driver) : base(driver) { }

        By streamDescriptionTitle = By.XPath("/html/body/div[1]/div/div/div[2]/main/div[1]/section[1]/div[2]/div/textarea");
        By streamDescriptionEditButton = By.CssSelector(".DetailsSection_section__uDzh0:nth-child(1) .DetailsSectionBtn_btn__C_Lrl");
        By streamDeleteButton = By.LinkText("Delete stream");
        By streamDescriptionEditTextarea = By.CssSelector(".DetailsDescription_descriptionArea__2NrA7");



        public string GetStreamDescription()
        {
            bool isTextLoaded = false;
            while (!isTextLoaded)
                if (driver.FindElement(streamDescriptionTitle).Text != "")
                    isTextLoaded = true;
            return driver.FindElement(streamDescriptionTitle).Text;
        }

        public StreamPage ClickStreamDesciptionEditButton()
        {
            driver.FindElement(streamDescriptionEditButton).Click();
            return this;
        }

        public StreamPage TypeStreamDesciptionTextarea(string decsription)
        {
            driver.FindElement(streamDescriptionEditTextarea).Clear();
            driver.FindElement(streamDescriptionEditTextarea).SendKeys(decsription);
            return this;
        }

        public StreamPage ClickStreamDeleteButton()
        {
            driver.FindElement(streamDeleteButton).Click();
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            return this;
        }
    }
}

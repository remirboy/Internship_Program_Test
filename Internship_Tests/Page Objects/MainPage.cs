using System;
using System.Collections.Generic;
using Internship_Tests.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Internship_Tests.PageObjects
{
    public class MainPage : PageObject
    {
        By addStreamButton = By.CssSelector(".AddStreamBtn_addStreamBtn__3fGuH");
        By streamSearchInput = By.XPath("/html/body/div[1]/div/div/div[2]/main/div[1]/input");
        By streamListSizeSelect = By.CssSelector(".StreamsPerPageSelect_streamsPerPageSelect__17U-v");
        By userFirstNameAndLastNameTitle = By.XPath("/html/body/div[1]/div/header/div");
        By streamSortByInternsNumberButton = By.CssSelector(".TableHeadCell_cell__38RJ4:nth-child(4) .TableHeadCell_sortIcon__R2qVi:nth-child(2)");
        By streamNamesList = By.XPath("/html/body/div[1]/div/div/div[2]/main/div[1]/table/tbody/tr/td[1]");
        By streamInternsNumberList = By.XPath("/html/body/div[1]/div/div/div[2]/main/div[1]/table/tbody/tr/td[4]");
        public MainPage(IWebDriver driver) : base(driver) { }
     
        public By AddStreamButton
        {
            get
            {
                return addStreamButton;
            }
            set
            {
                addStreamButton = value;
            }
        }

        public By UserFirstNameAndLastNameTitle
        {
            get
            {
                return userFirstNameAndLastNameTitle;
            }
            set
            {
                userFirstNameAndLastNameTitle = value;
            }
        }

        public By StreamSearchInput
        {
            get
            {
                return streamSearchInput;
            }
            set
            {
                streamSearchInput = value;
            }
        }

        public By StreamListSizeSelect
        {
            get
            {
                return streamListSizeSelect;
            }
            set
            {
                streamListSizeSelect = value;
            }
        }

        By logOutButton = By.LinkText("Finished streams");

        public MainPage InputStreamName(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5000));
            wait.Until(drv => drv.FindElement(streamSearchInput).Displayed);
            driver.FindElement(streamSearchInput).Clear();
            driver.FindElement(streamSearchInput).SendKeys(name);
            return this;
        }

        public MainPage ClearInputStreamName()
        {
            driver.FindElement(streamSearchInput).Clear();
            return this;
        }

        public MainPage ClickLogoutButton()
        {
            driver.FindElement(logOutButton).Click();
            return this;
        }

        public MainPage ClickAddStreamButton()
        {
            driver.FindElement(addStreamButton).Click();
            return this;
        }

        public MainPage ClickStreamSortByInternsNumberButton()
        {
            driver.FindElement(streamSortByInternsNumberButton).Click();
            return this;
        }
        

        public IWebElement GetUserFirstNameAndLastNameTitle()
        {
            return driver.FindElement(userFirstNameAndLastNameTitle);
        }

        public MainPage ClickStreamOptionsMenu(string number)
        {
            {
                var element = driver.FindElement(By.CssSelector("tr:nth-child(" + number + ") .TableItem_itemActionsBtn__1M03h > img"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.CssSelector("tr:nth-child(" + number + ") .TableItem_itemActionsBtn__1M03h > img")).Click();
            return this;
        }

        public List<Stream> GetStreamsNames()
        {
           return GetStreamsAttribute(streamNamesList);
        }

        public List<Stream> GetStreamsInternsNumber()
        {
            List<Stream> streamList = new List<Stream>();
            ICollection<IWebElement> elements = driver.FindElements(streamInternsNumberList);
            foreach (IWebElement element in elements)
            {
                Stream stream = new Stream();
                stream.Interns = int.Parse(element.Text); 
                streamList.Add(stream);
            }
            return streamList;
        }


        public List<Stream> GetStreamsAttribute(By locator)
        {
            List<Stream> streamList = new List<Stream>();
            ICollection<IWebElement> elements = driver.FindElements(locator);
            foreach (IWebElement element in elements)
            {
                streamList.Add(new Stream(element.Text));
            }
            return streamList;
        }

        public MainPage ChooseStreamListSize(string count)
        {
            driver.FindElement(streamListSizeSelect).Click();
            {
                var dropdown = driver.FindElement(streamListSizeSelect);
                dropdown.FindElement(By.XPath("//option[. = '"+count+"/page']")).Click();
            }
            return this;
        }

        public ICollection<IWebElement> StreamList()
        {
            WaitShowElement(By.XPath("/html/body/div[1]/div/div/div[2]/main/div[1]/table/tbody/tr"));
            return driver.FindElements(By.XPath("/html/body/div[1]/div/div/div[2]/main/div[1]/table/tbody/tr"));
        }
    }
}
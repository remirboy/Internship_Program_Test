using OpenQA.Selenium;
using NUnit.Framework;
using Internship_Tests.Helpers;
using OpenQA.Selenium.Chrome;

namespace Internship_Tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;

        protected string baseUrl = "http://akvelon-proj.herokuapp.com"; 

        protected LoginHelper loginHelper;

        public LoginHelper LoginHelper
        {
            get
            {
                return loginHelper;
            }
            set
            {
                loginHelper = value;
            }
        }

        protected StreamHelper streamHelper;

        public StreamHelper StreamHelper
        {
            get
            {
                return streamHelper;
            }
            set
            {
                streamHelper = value;
            }
        }

        protected BaseHelper baseHelper;

        public BaseHelper BaseHelper
        {
            get
            {
                return baseHelper;
            }
            set
            {
                baseHelper = value;
            }
        }

        public ApplicationManager()
        {
            driver = new ChromeDriver("/Users/remir/Downloads");
            loginHelper = new LoginHelper(driver);
            streamHelper = new StreamHelper(driver);
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
    }
}

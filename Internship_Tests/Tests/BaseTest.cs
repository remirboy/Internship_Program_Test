using NUnit.Framework;

namespace Internship_Tests.Tests
{
    public class BaseTest
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupAppliationManager()
        {
            app = new ApplicationManager();
        }

   
    }
}

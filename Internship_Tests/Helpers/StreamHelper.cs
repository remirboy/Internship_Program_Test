using System;
using Internship_Tests.Models;
using Internship_Tests.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Internship_Tests.Helpers
{
    public class StreamHelper : BaseHelper
    {
        public StreamHelper(IWebDriver driver) : base(driver) { }

        
        public void CreateNewStream(User user,Stream stream)
        {
            MainPage mainPage = new MainPage(driver);
            StreamCreationModalWindow streamModalWindow = new StreamCreationModalWindow(driver);

            Assert.AreEqual(IsSuperUser(mainPage), true);
            mainPage.ClickAddStreamButton();
            //It's need to add method of stream creation button click when it will be done
            InputNewStreamDetailsInfo(streamModalWindow, stream);
            ConfirmNewStreamCreation(streamModalWindow);
            mainPage.WaitShowElement(mainPage.StreamSearchInput);
        }

        private void InputNewStreamDetailsInfo(StreamCreationModalWindow streamModalWindow,Stream stream)
        {
            streamModalWindow.TypeName(stream.Name).
                TypeDescription(stream.Description).
                ChooseStartDate().ChooseEndDate().
                ClickStreamCreationButton();
        }

        private void ConfirmNewStreamCreation(StreamCreationModalWindow streamModalWindow)
        {
            streamModalWindow.ClickStreamCreationConfirmButton();
        }

        public void UpdateStreamDescription(Stream stream)
        {
            StreamPage streamPage = new StreamPage(driver);
            streamPage.ClickStreamDesciptionEditButton().
                TypeStreamDesciptionTextarea(stream.Description).
                ClickStreamDesciptionEditButton();
            Assert.AreEqual(streamPage.GetStreamDescription(), stream.Description);
        }

        public void DeleteStream()
        {
            StreamPage streamPage = new StreamPage(driver);
            streamPage.ClickStreamDeleteButton();
        }

        public void SearchStreamByName(Stream stream)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.InputStreamName(stream.Name);
        }

        
        public void ClearSearchStreamByName()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClearInputStreamName();
        }

        public void ChangeStreamListSize(string count)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.WaitShowElement(mainPage.StreamListSizeSelect);
            mainPage.ChooseStreamListSize(count);
        }

        public StreamHelper OpenStreamOptionsMenu(string count)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickStreamOptionsMenu(count);
            return this;
        }


        public StreamHelper OpenStreamDetails(Stream stream)
        {
            StreamOptionsMenu streamOptions = new StreamOptionsMenu(driver);
            streamOptions.ClickOpenStreamDetails();
            StreamPage streamPage = new StreamPage(driver);
            Assert.AreEqual(streamPage.GetStreamDescription(),stream.Description);
            return this;
        }

        private List<Stream> streamList = null;
        private List<int> streamsInternsNumberList = null;

        public List<Stream> GetStreamList()
        {
            MainPage mainPage = new MainPage(driver);
            streamList = new List<Stream>();
            ICollection<IWebElement> elements = mainPage.StreamList();
            foreach (IWebElement element in elements)
                streamList.Add(new Stream(element.Text));
            return new List<Stream>(streamList);
        }

        public string GetUserName()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.WaitShowElement(mainPage.UserFirstNameAndLastNameTitle);
            return mainPage.GetUserFirstNameAndLastNameTitle().Text;
        }

        public bool IsStreamFound(Stream stream)
        {
            MainPage mainPage = new MainPage(driver);
            return mainPage.GetStreamsNames().Exists(x => x.Name.Contains(stream.Name));
        }

        public List<int> ConvertInternsNumberToInt()
        {
            streamsInternsNumberList = null;
            streamsInternsNumberList = new List<int>();
            ICollection<Stream> streams = GetStreamsInternsNumbersList();
            foreach (Stream stream in streams)
                streamsInternsNumberList.Add(stream.Interns);
            return streamsInternsNumberList;
        }

        public List<Stream> GetStreamsInternsNumbersList()
        {
            MainPage mainPage = new MainPage(driver);
            Console.WriteLine(mainPage.GetStreamsInternsNumber().GetType());
            return mainPage.GetStreamsInternsNumber();
        }

        public StreamHelper SortStreamByInternsNumber()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickStreamSortByInternsNumberButton();
            return this;
        }

        private bool IsSuperUser(MainPage mainPage)
        {
            mainPage.WaitShowElement(mainPage.AddStreamButton);
            return mainPage.IsElementPresent(mainPage.AddStreamButton);
        }
        

    }
}
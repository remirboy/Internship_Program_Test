using System.Collections.Generic;
using System;
using NUnit.Framework;
using Internship_Tests.Models;
using System.Threading;

namespace Internship_Tests.Tests

{
    [TestFixture]
    public class StreamTest : BaseTest
    {
        [Test]
        public void SuperUserCreatesNewStream()
        {

            User user = new User("timur.sultanov@akvelon.com", "Pro100Timur"); 
            Stream stream = new Stream("QA", "description");
            app.LoginHelper.MoveToLoginForm();

            app.LoginHelper.Login(user);

            Assert.AreEqual(true, app.StreamHelper.IsSuperUser());

            app.StreamHelper.CreateNewStream(user, stream);

            app.StreamHelper.SearchStreamByName(stream);
            app.StreamHelper.OpenStreamOptionsMenu("1").OpenStreamDetails(stream);

            stream.Description = "QA description";
            app.StreamHelper.UpdateStreamDescription(stream);
            app.StreamHelper.DeleteStream();

            app.StreamHelper.SearchStreamByName(stream);

            Assert.AreEqual(false, app.StreamHelper.IsStreamFound(stream));

        }

        [Test]
        public void UserOpenStreamPage()
        {

            User user = new User("rem@yandex.ru", "ZRR05012000");
            Stream stream = new Stream("hi","hi");
            app.LoginHelper.MoveToLoginForm();

            app.LoginHelper.Login(user);

            //Assert.AreEqual(false, app.StreamHelper.IsSuperUser());

            app.StreamHelper.ChangeStreamListSize("5");

            List<Stream> streams = app.StreamHelper.GetStreamList();

            Assert.AreEqual(5, streams.Count);

            app.StreamHelper.ChangeStreamListSize("10");

            streams = app.StreamHelper.GetStreamList();

            Assert.AreEqual(9, streams.Count);

            app.StreamHelper.SearchStreamByName(stream);

            Assert.AreEqual(true, app.StreamHelper.IsStreamFound(stream));

            app.StreamHelper.OpenStreamOptionsMenu("1").OpenStreamDetails(stream);

        }
    }
}
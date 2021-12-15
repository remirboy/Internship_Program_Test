﻿using System.Collections.Generic;
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

            app.StreamHelper.ChangeStreamListSize("5");

            List<Stream> streams = app.StreamHelper.GetStreamList();

            Assert.AreEqual(5, streams.Count);

            app.StreamHelper.ChangeStreamListSize("10");

            streams = app.StreamHelper.GetStreamList();

            Assert.AreEqual(9, streams.Count);

            //List<int> oldStreamsInternsNumber = app.StreamHelper.ConvertInternsNumberToInt();

            //oldStreamsInternsNumber.Sort();

            //Console.WriteLine(oldStreamsInternsNumber.Count);


            //app.StreamHelper.SortStreamByInternsNumber();

            //List<int> newStreamsInternsNumber = app.StreamHelper.ConvertInternsNumberToInt();

            //Console.WriteLine(newStreamsInternsNumber.Count);

            //Assert.AreEqual(oldStreamsInternsNumber, newStreamsInternsNumber);


            app.StreamHelper.SearchStreamByName(stream);

            Assert.AreEqual(true, app.StreamHelper.IsStreamFound(stream));

            app.StreamHelper.OpenStreamOptionsMenu("1").OpenStreamDetails(stream);

            // when it will done need to check that stream name in open page is "hi" like created stream

            //      app.StreamHelper.ClearSearchStreamByName();
        }
    }
}
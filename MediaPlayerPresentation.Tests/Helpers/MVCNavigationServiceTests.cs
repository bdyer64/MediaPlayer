using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Moq;
using MediaPlayerPresentation.Helpers;

namespace MediaPlayerPresentation.Tests.Helpers
{
    /// <summary>
    /// Summary description for MVCNavigationServiceTests
    /// </summary>
    [TestClass]
    public class MVCNavigationServiceTests
    {
        public MVCNavigationServiceTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void NavigationServicesCallHanderWithNoParamter()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            
            var sut = fixture.Create<MVCNavigationService>();

            NavigateEventArgs eventArgs = null;
            object calledObject = null;
            bool called = false;

            sut.NavigateTo += (o, e) => { eventArgs = e as NavigateEventArgs; 
                                          calledObject = o; 
                                          called = true; };

            sut.Navigate("some page");

            Assert.IsTrue(called);
            Assert.AreEqual(sut, calledObject);
            Assert.AreEqual(eventArgs.view, "some page");
            Assert.AreEqual(eventArgs.parameter, null);
        }

        [TestMethod]
        public void NavigationServiceCallsHanderWithParamter()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<MVCNavigationService>();

            NavigateEventArgs eventArgs = null;
            object calledObject = null;
            bool called = false;

            sut.NavigateTo += (o, e) =>
            {
                eventArgs = e as NavigateEventArgs;
                calledObject = o;
                called = true;
            };

            int param = 99;

            sut.Navigate("some page",param);

            Assert.IsTrue(called);
            Assert.AreEqual(sut, calledObject);
            Assert.AreEqual(eventArgs.view, "some page");
            Assert.IsInstanceOfType(eventArgs.parameter,typeof(int));
            int actualParam = (int)eventArgs.parameter;
            Assert.AreEqual(99, actualParam);
        }

        [TestMethod]
        public void NavigationServiceCallsHanderWithBack()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<MVCNavigationService>();

            NavigateEventArgs eventArgs = null;
            object calledObject = null;
            bool called = false;

            sut.NavigateTo += (o, e) =>
            {
                eventArgs = e as NavigateEventArgs;
                calledObject = o;
                called = true;
            };

            sut.GoBack();

            Assert.IsTrue(called);
            Assert.AreEqual(sut, calledObject);
            Assert.AreEqual(eventArgs.view, "Back");
            Assert.AreEqual(eventArgs.parameter, null);
        }
    }
}

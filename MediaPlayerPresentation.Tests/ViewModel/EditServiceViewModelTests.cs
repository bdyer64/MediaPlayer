using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Moq;
using MediaPlayerPresentation.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediaPlayerModel;
using System.Threading.Tasks;
using System.Threading;

namespace MediaPlayerPresentation.Tests.ViewModel
{
    [TestClass]
    public class EditServiceViewModelTests
    {
        [TestMethod]
        public void ChangingServerNameRaisesPropChanged()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<EditServiceViewModel>();
            string propName = "";
            object changedObject = null;

            sut.PropertyChanged += (o, e) => { changedObject = o; propName = e.PropertyName; };

            var teststring = fixture.Create<string>();
            sut.ServerName = teststring;

            Assert.AreEqual(sut, changedObject);
            Assert.AreEqual("ServerName", propName);
            Assert.AreEqual(teststring, sut.ServerName);
        }

        [TestMethod]
        public void ChangingServerAddressRaisesPropChanged()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<EditServiceViewModel>();
            string propName = "";
            object changedObject = null;

            sut.PropertyChanged += (o, e) => { changedObject = o; propName = e.PropertyName; };

            var teststring = fixture.Create<string>();
            sut.ServerAddress = teststring;

            Assert.AreEqual(sut, changedObject);
            Assert.AreEqual("ServerAddress", propName);
            Assert.AreEqual(teststring, sut.ServerAddress);
        }

        [TestMethod]
        public void ChangingUserNameRaisesPropChanged()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<EditServiceViewModel>();
            string propName = "";
            object changedObject = null;

            sut.PropertyChanged += (o, e) => { changedObject = o; propName = e.PropertyName; };

            var teststring = fixture.Create<string>();
            sut.UserName = teststring;

            Assert.AreEqual(sut, changedObject);
            Assert.AreEqual("UserName", propName);
            Assert.AreEqual(teststring, sut.UserName);
        }

        [TestMethod]
        public void ChangingPasswordRaisesPropChanged()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<EditServiceViewModel>();
            string propName = "";
            object changedObject = null;

            sut.PropertyChanged += (o, e) => { changedObject = o; propName = e.PropertyName; };

            var teststring = fixture.Create<string>();
            sut.Password = teststring;

            Assert.AreEqual(sut, changedObject);
            Assert.AreEqual("Password", propName);
            Assert.AreEqual(teststring, sut.Password);
        }

        [TestMethod]
        public void ChangingButtonTextRaisesPropChanged()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var sut = fixture.Create<EditServiceViewModel>();
            string propName = "";
            object changedObject = null;

            sut.PropertyChanged += (o, e) => { changedObject = o; propName = e.PropertyName; };

            var teststring = fixture.Create<string>();
            sut.ButtonText = teststring;

            Assert.AreEqual(sut, changedObject);
            Assert.AreEqual("ButtonText", propName);
            Assert.AreEqual(teststring, sut.ButtonText);
        }

        [TestMethod]
        public void NavigatingFromViewSavesServerInfo()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var testSN = fixture.Create<string>();
            var testPW = fixture.Create<string>();
            var testSU = fixture.Create<string>();
            var testUN = fixture.Create<string>();


            var mock = new Mock<Service>();

            var sut = fixture.Build<EditServiceViewModel>()
                    .FromFactory(() => new EditServiceViewModel(mock.Object))
                    .OmitAutoProperties().Create<EditServiceViewModel>();

            sut.ServerName = testSN;
            sut.Password = testPW;
            sut.ServerAddress = testSU;
            sut.UserName = testUN;
            sut.Deactivate(new object());

            mock.Verify(m => m.Save(),Times.Exactly(1));
            Assert.AreEqual(mock.Object.Password, testPW);
            Assert.AreEqual(mock.Object.ServerURL, testSU);
            Assert.AreEqual(mock.Object.UserName, testUN);
            Assert.AreEqual(mock.Object.ServiceName, testSN);
        }

        [TestMethod]
        public void TestConnectionCommandSwitchesButtonText()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            object lock1 = new object();

            var mock = new Mock<Service>();
            mock.Setup(m => m.TestConnection()).Returns(() => Task<bool>.Factory.StartNew(() =>
                { lock (lock1) { Monitor.Wait(lock1); return true; } }));

            var sut = fixture.Build<EditServiceViewModel>()
                    .FromFactory(() => new EditServiceViewModel(mock.Object))
                    .OmitAutoProperties().Create<EditServiceViewModel>();

            bool buttonTextChanged = false;
            object changedObject = null;

            sut.PropertyChanged += (o, e) => 
                { changedObject = o; if("ButtonText" == e.PropertyName) buttonTextChanged = true; };

            sut.TestConnection.Execute(new object());

            Assert.AreEqual(true,buttonTextChanged);
            buttonTextChanged = false;
            Assert.AreEqual("Cancel Test", sut.ButtonText);
            lock (lock1)
            {
                sut.PropertyChanged += (o, e) => { lock (fixture) { Monitor.Pulse(fixture); } };
                Monitor.Pulse(lock1);
            }
            lock (fixture)
            {   
                Monitor.Wait(fixture);
            }

            Assert.AreEqual(true, buttonTextChanged);
            Assert.AreEqual("Test Connection", sut.ButtonText);
        }

        [TestMethod]
        public void TestConnectionCommandSwitchesStatusVisible()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            object lock1 = new object();
            object lock2 = new object();

            var mock = new Mock<Service>();
            mock.Setup(m => m.TestConnection()).Returns(() => Task<bool>.Factory.StartNew(() =>
            { lock (lock1) { Monitor.Wait(lock1); return true; } }));

            var sut = fixture.Build<EditServiceViewModel>()
                    .FromFactory(() => new EditServiceViewModel(mock.Object))
                    .OmitAutoProperties().Create<EditServiceViewModel>();

            object changedObject = null;
            bool showStatusChanged = false;

            sut.PropertyChanged += (o, e) =>
            { changedObject = o; if ("ShowStatus" == e.PropertyName) showStatusChanged = true; };

            sut.TestConnection.Execute(new object());

            Assert.AreEqual(true,showStatusChanged);
            Assert.AreEqual(true, sut.ShowStatus);

            lock (lock1)
            {
                sut.PropertyChanged += (o, e) => { if (e.PropertyName == "ShowStatus") 
                {lock (lock2) { Monitor.Pulse(lock2); }} };
                Monitor.Pulse(lock1);
            }
            lock (lock2)
            {
                Monitor.Wait(lock2);
            }

            Assert.AreEqual(true, showStatusChanged);
            Assert.AreEqual(false, sut.ShowStatus);
        }
    }
}

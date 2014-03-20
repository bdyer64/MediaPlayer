using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Moq;
using System.Net;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace SubsonicMediaProvider.Tests
{
    [TestClass]
    public class SubsonicAPITests
    {
        [TestCategory("LiveTests"),TestMethod]
        public void CanRequestFromLiveTestServer()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<SubsonicAPI>();
            Stream stream=null;

            string reqURL = "http://demo.subsonic.org/rest/ping.view?u=guest4&p=guest&v=1.10.2.0&c=bfdmp";
            var testUri = new Uri(reqURL);

            sut.MakeHTTPRequest(reqURL, s => stream = s);

            while (stream == null)
            {
                Thread.Sleep(1000);
            }

            var reader = new StreamReader(stream);
            string actual  = reader.ReadToEnd();
            Assert.IsTrue(actual.Contains("status=\"ok\""));
        }

        [TestMethod]
        public void CallMakeHTTPRequestWithNullUrlThrows()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<SubsonicAPI>();

            try
            {
                sut.MakeHTTPRequest(null, s => { });    
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void CallMakeHTTPRequestWithNullCallbackThrows()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<SubsonicAPI>();

            try
            {
                sut.MakeHTTPRequest("test://google.com",null);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void MakesHTTPCallWithCorrectUri()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            Stream stream;
            
            string reqURL = "test1://demo.subsonic.org/rest/ping.view?u=guest4&p=guest&v=1.10.2.0&c=bfdmp";
            var testUri = new Uri(reqURL);
            var mockAsyncRes = new Mock<IAsyncResult>();

            // Create a mock for the request - this mock automatically calls the callback
            var mockWebRequest = new Mock<HttpWebRequest>();
            
            var mockWebRequestCreate = new Mock<IWebRequestCreate>();
            mockWebRequestCreate.Setup(r => r.Create(It.IsAny<Uri>())).Returns(mockWebRequest.Object);
            WebRequest.RegisterPrefix("test1", mockWebRequestCreate.Object);

            var sut = fixture.Create<SubsonicAPI>();
            sut.MakeHTTPRequest(reqURL,s => stream = s);

            mockWebRequestCreate.Verify(r => r.Create(It.Is<Uri>(u => u.Equals(testUri))), Times.Once());
        }

        [TestMethod]
        public void HTTPRequestCallsCallbackWithCorrectResponse()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            Stream stream = null;

            string responseString = "<subsonic-response xmlns=\"http://subsonic.org/restapi\" status=\"failed\" version=\"1.10.2\">\n<error code=\"40\" message=\"Wrong username or password.\"/>\n</subsonic-response>";
            var stringStream = new MemoryStream(Encoding.UTF8.GetBytes(responseString));
            var mockAsyncRes = new Mock<IAsyncResult>();

            // Create a mock for the repsonse
            var mockWebResponse = new Mock<HttpWebResponse>();
            mockWebResponse.Setup(r => r.GetResponseStream()).Returns(stringStream);

            // Create a mock for the request - this mock automatically calls the callback
            var mockWebRequest = new Mock<HttpWebRequest>();
            mockWebRequest.Setup(r => r.BeginGetResponse(It.IsAny<AsyncCallback>(), It.IsAny<Object>())).
                Returns((AsyncCallback call, Object obj) => { call.Invoke(mockAsyncRes.Object); return mockAsyncRes.Object; });

            //Set up AsyncResponse to return web response
            mockAsyncRes.Setup(r => r.AsyncState).Returns(mockWebRequest.Object);

            // configure request mock to return the response mock
            mockWebRequest.Setup(r => r.EndGetResponse(It.IsAny<IAsyncResult>())).Returns(mockWebResponse.Object);

            var mockWebRequestCreate = new Mock<IWebRequestCreate>();
            mockWebRequestCreate.Setup(r => r.Create(It.IsAny<Uri>())).Returns(mockWebRequest.Object);
            WebRequest.RegisterPrefix("test2", mockWebRequestCreate.Object);

            string reqURL = "test2://demo.subsonic.org/rest/ping.view?u=guest4&p=guest&v=1.10.2.0&c=bfdmp";

            var sut = fixture.Create<SubsonicAPI>();
            sut.MakeHTTPRequest(reqURL, s => stream = s);

            MemoryStream ms = stream as MemoryStream;
            string expected = Encoding.ASCII.GetString(ms.ToArray());
     
            Assert.AreEqual(responseString, expected);
        }

        //[TestMethod]
        public void TestConnectionReturnsSuccess()
        {
            Assert.Fail();
        }
    }
}

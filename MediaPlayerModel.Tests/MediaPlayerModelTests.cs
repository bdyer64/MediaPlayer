using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.SemanticComparison;
using MediaPlayerModel;
using Moq;

namespace MediaPlayerModel.Tests
{
    [TestClass]
    public class MediaPlayerModelTests
    {
        [TestMethod]
        public void InitializeWithZeroMediaProvidersThrows()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var emptyProviderList = new List<IMediaProvider>();

            try
            {
                fixture.Build<MediaPlayerService>()
                    .FromFactory(() => new MediaPlayerService(emptyProviderList))
                    .OmitAutoProperties().Create<MediaPlayerService>();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }

        }

        [TestMethod]
        public void ReturnsProperAvailableServiceList()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            fixture.Register(() =>
            {
                var mediaProvider =
                    new Mock<IMediaProvider>();
                mediaProvider.Setup(mp =>
                    mp.GetServiceInfo())
                    .Returns(fixture.Create<ServiceInfo>());
                return mediaProvider.Object;
            });

            var services = fixture.CreateMany<IMediaProvider>().ToList();
            var expectedSI = (from si in services select si.GetServiceInfo()).ToList();

            var sut = fixture.Build<MediaPlayerService>()
                    .FromFactory(() => new MediaPlayerService(services))
                    .OmitAutoProperties().Create<MediaPlayerService>();

            var actualSI = sut.GetMediaServices();

            Assert.IsTrue(expectedSI.SequenceEqual(actualSI));
        }
    }
}

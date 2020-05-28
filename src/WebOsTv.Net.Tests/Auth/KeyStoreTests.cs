using Moq;
using Newtonsoft.Json.Linq;
using WebOsTv.Net.Auth;
using WebOsTv.Net.FileSystem;
using Xunit;

namespace WebOsTv.Net.Tests.Auth
{
    public class KeyStoreTests
    {
        [Fact]
        public async void StoredSuccessfully()
        {
            var calledBack = false;

            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);
            fileServiceMock.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                .Callback((string path, string json) =>
                {
                    var obj = JObject.Parse(json);
                    Assert.Equal("abc123", obj["thehost"].Value<string>());
                    calledBack = true;
                });

            var fileService = fileServiceMock.Object;

            var keyStore = new KeyStore(fileService);
            await keyStore.StoreKeyAsync("thehost", "abc123");

            Assert.True(calledBack);
        }

        [Fact]
        public async void ReadSuccessfully()
        {
            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
            fileServiceMock.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns("{ \"thehost\" : \"abc123\" }");

            var fileService = fileServiceMock.Object;

            var keyStore = new KeyStore(fileService);
            
            Assert.Equal("abc123", await keyStore.GetKeyAsync("thehost"));
        }
    }
}

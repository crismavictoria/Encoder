using Backend.Services;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Tests.Services
{
    [TestFixture]
    public class EncodingServiceTests
    {
        private EncodingService _encodingService;

        [SetUp]
        public void SetUp()
        {
            _encodingService = new EncodingService();
        }

        [Test]
        public async Task Encode_ShouldReturnEncodedText()
        {
            // Arrange
            string text = "Hello, World!";
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            string result = await _encodingService.Encode(text, cancellationToken);

            // Assert
            Assert.AreEqual("SGVsbG8sIFdvcmxkIQ==", result);
        }

        [Test]
        public async Task Encode_WithCancellation_ShouldReturnCancellationMessage()
        {
            // Arrange
            string text = "Hello, World!";
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task<string> encodingTask = _encodingService.Encode(text, cancellationToken);

            // Act
            cancellationTokenSource.Cancel();
            string result = await encodingTask;

            // Assert
            Assert.AreEqual("Encoding process cancelled.", result);
        }

        [Test]
        public void Cancel_ShouldCancelEncodingProcess()
        {
            // Arrange
            _encodingService.Encode("Hello, World!", CancellationToken.None);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            // Act
            _encodingService.Cancel();

            // Assert
            Assert.IsTrue(cancellationTokenSource.IsCancellationRequested);
        }
    }
}

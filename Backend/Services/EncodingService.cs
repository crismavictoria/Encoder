using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IEncodingService
    {
        Task<string> Encode(string text, CancellationToken cancellationToken);
        
        void Cancel();

        bool CanEncode();
    }

    public class EncodingService : IEncodingService
    {
        private CancellationTokenSource _cancellationTokenSource;

        public async Task<string> Encode(string text, CancellationToken cancellationToken)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            var random = new Random();

            foreach (var character in encodedText)
            {
                await Task.Delay(random.Next(1000, 5000), cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    return "Encoding process cancelled.";
                }

                // Do something with the character if needed

                await Task.Yield();
            }

            return "Encoding process completed.";
        }

        public void Cancel()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }

        public bool CanEncode()
        {
            return _cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested;
        }
    }
}

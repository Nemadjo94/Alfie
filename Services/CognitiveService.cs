using Microsoft.CognitiveServices.Speech;

namespace Alfie.Services
{
    public class CognitiveService
    {
        private SpeechConfig SpeechConfig { get; set; }

        private SpeechSynthesizer SpeechSynthesizer { get; set; }

        public CognitiveService(string subscriptionKey, string subscriptionRegion)
        {
            SpeechConfig = SpeechConfig.FromSubscription(subscriptionKey, subscriptionRegion);
            SpeechConfig.SpeechSynthesisVoiceName = "en-US-NancyNeural";
            SpeechSynthesizer = new SpeechSynthesizer(SpeechConfig);
        }

        public async Task<string> ConvertSpeechToTextAsync()
        {
            // Speech to text
            using var recognizer = new SpeechRecognizer(SpeechConfig);

            // Start speech recognition
            var speechToTextResult = await recognizer.RecognizeOnceAsync();

            return speechToTextResult.Text;
        }

        public async Task ConvertTextToSpeechAsync(string text)
        {
            // use the default speaker as audio output.
            using var result = await SpeechSynthesizer.SpeakTextAsync(text);
            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                Console.WriteLine($"Speech synthesized for text [{text}]");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                    Console.WriteLine($"CANCELED: Did you update the subscription info?");
                }
            }
        }

        public async Task CancelSpeechAsync()
        {
            await SpeechSynthesizer.StopSpeakingAsync();
        }
    }
}
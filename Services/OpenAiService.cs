using Newtonsoft.Json.Linq;
using RestSharp;

namespace Alfie.Services
{
    public class OpenAiService
    {
        private readonly string _subscriptionKey;

        public OpenAiService(string subscriptionKey)
        {
            _subscriptionKey = subscriptionKey;
        }

        public async Task<string> SendMessageToChatModelAsync(string message)
        {
            var client = new RestClient("https://api.openai.com/v1/");
            client.AddDefaultHeader("Authorization", $"Bearer {_subscriptionKey}");

            // Set up the request parameters
            var request = new RestRequest("chat/completions", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\"messages\": [{{\"role\": \"user\", \"content\": \"{message}\"}}],\"max_tokens\":150,\"temperature\":0.7,\"model\":\"gpt-3.5-turbo\"}}", ParameterType.RequestBody);

            // Send the request to the OpenAI API
            var response = await client.ExecuteAsync(request);
            // Get the generated text from the response
            var jsonResponse = JObject.Parse(response.Content);
            var generatedText = jsonResponse["choices"][0]["message"]["content"].ToString();

            // Print the generated text
            Console.WriteLine($"Generated Text: {generatedText}");

            return generatedText;
        }
    }
}

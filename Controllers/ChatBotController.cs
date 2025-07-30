using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace JobPortal1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ChatBotController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest request)
        {
            var apiKey = "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".Trim();

            var prompt = request.Message;

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            httpRequest.Headers.Add("Authorization", $"Bearer {apiKey}");
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.SendAsync(httpRequest);  // Burada response alıyoruz
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("OpenAI Response: " + responseBody);

                dynamic json = JsonConvert.DeserializeObject(responseBody);
                string reply = json.choices[0].message.content;

                return Ok(new { reply });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { reply = "Bot şu anda yanıt veremiyor. Hata: " + ex.Message });
            }
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}

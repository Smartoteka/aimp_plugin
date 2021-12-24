namespace Smartoteka.API.Clients
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using DTOs;
    using Newtonsoft.Json;

    public class SmartotekaAPIClient
    {
        private string _baseUrl;
        private JsonSerializer _jsonSerializer = new JsonSerializer();

        public SmartotekaAPIClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<ResponseDto> GetMessagesAsync(Guid uuid, string extId, int productType)
        {
            ResponseDto result = null;
            using (var client = Client())
            {
                var requestUri = $"Main?uuid={uuid}&extId={extId}&productType={productType}";

                var response = await client.GetAsync(requestUri);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = await ToResponseDto(response, _jsonSerializer);
                }
            }

            return result;
        }

        private HttpClient Client()
        {
            return new HttpClient {BaseAddress = new Uri(_baseUrl)};
        }

        public async Task<ResponseDto> RegisterAsync(RegisterRequest request)
        {
            ResponseDto result = null;
            using (var client = Client())
            {
                var response = await client.PostAsync("Main", ArgsToStringContent(request));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = await ToResponseDto(response, _jsonSerializer);
                }
            }

            return result;
        }

        private static async Task<ResponseDto> ToResponseDto(HttpResponseMessage response,
            JsonSerializer jsonSerializer)
        {
            ResponseDto result;
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var jsonTextReader = new JsonTextReader(new StreamReader(stream));

                result = jsonSerializer.Deserialize<ResponseDto>(jsonTextReader);
            }

            return result;
        }

        public async Task<ResponseDto> LoginAsync(LoginRequest request)
        {
            ResponseDto result = null;
            using (var client = Client())
            {
                var response = await client.PutAsync("Main", ArgsToStringContent(request));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = await ToResponseDto(response, _jsonSerializer);
                }
            }

            return result;
        }

        private StringContent ArgsToStringContent(object registerRequest)
        {
            string request = null;
            using (var stringStream = new StringWriter())
            {
                _jsonSerializer.Serialize(stringStream, registerRequest);

                request = stringStream.ToString();
            }

            var content = new StringContent(request, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
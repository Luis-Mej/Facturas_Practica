using System.Text;
using System.Text.Json;
using Sesion;

namespace HttpClientProxy
{
    public class HttpClientProxy : IDisposable
    {
        const string API_URL = "https://localhost:7037/api/";

        public static async Task PostAsync(string endpoint, object data)
        {
            var url = API_URL + endpoint;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SesionActual.Token);
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la llamada a la API: {response.StatusCode}");
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

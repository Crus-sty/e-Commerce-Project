using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;

namespace Game_Grid
{
    public static class ApiClient
    {
        private static readonly string BaseUrl =
            ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "http://localhost:8080";

        private static HttpClient CreateClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };

            // Read the token from the current ASP.NET session
            var token = HttpContext.Current?.Session?["Token"] as string;

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Trim());
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static T Get<T>(string path)
        {
            using (var client = CreateClient())
            {
                var response = client.GetAsync(path).GetAwaiter().GetResult();
                return HandleResponse<T>(response);
            }
        }

        public static T Delete<T>(string path)
        {
            using (var client = CreateClient())
            {
                var response = client.DeleteAsync(path).GetAwaiter().GetResult();
                return HandleResponse<T>(response);
            }
        }

        public static T Post<T>(string path, object body)
        {
            using (var client = CreateClient())
            {
                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = client.PostAsync(path, content).GetAwaiter().GetResult();
                return HandleResponse<T>(response);
            }
        }

        public static T Put<T>(string path, object body)
        {
            using (var client = CreateClient())
            {
                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = client.PutAsync(path, content).GetAwaiter().GetResult();
                return HandleResponse<T>(response);
            }
        }

        private static T HandleResponse<T>(HttpResponseMessage response)
        {
            string body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpContext.Current?.Session?.Clear();
                HttpContext.Current?.Response?.Redirect("/login");
                return default(T);
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API {response.StatusCode}: {body}");

            if (typeof(T) == typeof(string))
                return (T)(object)body;

            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
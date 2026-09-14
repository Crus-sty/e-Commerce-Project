using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Game_Grid
{
    public static class ApiClient
    {
        // Spring Boot backend
        private const string BASE_URL =
            "http://localhost:8080";

       
        // GET

        public static T Get<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                // Get JWT token from Session
                string token =
                    HttpContext.Current.Session["AuthToken"] as string;

                // Add JWT token
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token);
                }

                // Call Spring Boot
                HttpResponseMessage response =
                    client.GetAsync(
                        BASE_URL + endpoint).Result;

                // Read response
                string json =
                    response.Content.ReadAsStringAsync().Result;

                // Check for error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "API Error: "
                        + response.StatusCode
                        + " - "
                        + json);
                }

                // Convert JSON to C# object
                return JsonConvert.DeserializeObject<T>(json);
            }
        }


        // POST

        public static T Post<T>(
            string endpoint,
            object data)
        {
            using (HttpClient client = new HttpClient())
            {
                // Get JWT token
                string token =
                    HttpContext.Current.Session["AuthToken"] as string;

                // Add JWT token
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token);
                }

                // Convert object to JSON
                string json =
                    JsonConvert.SerializeObject(data);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                // Send POST request
                HttpResponseMessage response =
                    client.PostAsync(
                        BASE_URL + endpoint,
                        content).Result;

                // Read response
                string result =
                    response.Content.ReadAsStringAsync().Result;

                // Check for error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "API Error: "
                        + response.StatusCode
                        + " - "
                        + result);
                }

                // If there is no response body
                if (string.IsNullOrWhiteSpace(result))
                {
                    return default(T);
                }

                // Convert JSON response
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        // PUT
     
        public static T Put<T>(
            string endpoint,
            object data)
        {
            using (HttpClient client = new HttpClient())
            {
                // Get JWT token
                string token =
                    HttpContext.Current.Session["AuthToken"] as string;

                // Add JWT token
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token);
                }

                // Convert data to JSON
                string json =
                    JsonConvert.SerializeObject(data);

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                // Send PUT request
                HttpResponseMessage response =
                    client.PutAsync(
                        BASE_URL + endpoint,
                        content).Result;

                // Read response
                string result =
                    response.Content.ReadAsStringAsync().Result;

                // Check for error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "API Error: "
                        + response.StatusCode
                        + " - "
                        + result);
                }

                // Convert response
                if (string.IsNullOrWhiteSpace(result))
                {
                    return default(T);
                }

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        // DELETE
        public static T Delete<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                // Get JWT token
                string token =
                    HttpContext.Current.Session["Token"] as string;

                // Add JWT token
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token);
                }

                // Send DELETE request
                HttpResponseMessage response = client.DeleteAsync(BASE_URL + endpoint).Result;
                   


                // Read response
                string result = response.Content.ReadAsStringAsync().Result;
                   

                // Check for error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "API Error: "
                        + response.StatusCode
                        + " - "
                        + result);
                }

                // If there is no response
                if (string.IsNullOrWhiteSpace(result))
                {
                    return default(T);
                }

                // Convert response
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
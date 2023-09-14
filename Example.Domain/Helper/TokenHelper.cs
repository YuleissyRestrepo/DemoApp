using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Example.Domain.Resources.Environment;
using Newtonsoft.Json;
using Example.Domain.Entities.Infraestructure;
using Example.Domain.Entities.Persistence;

namespace Example.Domain.Helper
{
    public static class TokenHelper
    {

        private static string? _token;

        private static DateTime _dateExpired;


        public static async Task<string> GetToken()
        {
            if (_token is null || TokenIsExpired())
            {
                _token = await InternalGetToken();
            }

            return _token;
        }

        private static bool TokenIsExpired()
        {
            if (_dateExpired == null || DateTime.Now > _dateExpired)
            {
                return true;
            }

            return false;
        }

        private static async Task<string> InternalGetToken()
        {
            HttpResponseMessage? response = null;
            string result = String.Empty;

            try
            {
                string path = ServiceSettings.BASE_ADDRESS + ServiceSettings.SERVICE_GET_TOKEN;

                HttpClientHandler clientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };

                var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(path),
                    Timeout = new TimeSpan(1, 0, 0)
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add(AppSettings.HEADER_CODENAME_GATEWAYID , AppSettings.GATEWAY_ID);


                var body = new { Origin = "MOBILE", device = "PDA", document = "42EB4F98ECDE7578", UserPassword = AppSettings.USER_PASSWORD };
                var strBody = JsonConvert.SerializeObject(body);

                StringContent content = new StringContent(strBody, Encoding.UTF8, "application/json");
                response = client.PostAsync(path, content).Result;

                //if (response.IsSuccessStatusCode)
                //{
                //    string responseJson = await response.Content.ReadAsStringAsync();
                //    if (!string.IsNullOrEmpty(responseJson))
                //    {
                //        var httpResponseToken = JsonConvert.DeserializeObject<HttpResponse<UserApp>>(responseJson);
                //        if (httpResponseToken.StatusCode == (int)HttpStatusCode.OK)
                //        {
                //            result = httpResponseToken.Response.Token.Encoded;
                //            _dateExpired = httpResponseToken.Response.Token.ExpirationDate;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                result = string.Empty;
            }

            return result;
        }
    }
}

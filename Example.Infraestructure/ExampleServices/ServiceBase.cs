using Android.Icu.Util;
using Example.Domain.Entities.Infraestructure;
using Example.Domain.Helper;
using Example.Domain.Resources.Environment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Example.Infraestructure.ExampleServices
{
    public class ServiceBase
    {

        // Variable Protegida 
        protected string _baseAddress { get; set; }

        // Contructor de la clase 
        public ServiceBase()
        {
            _baseAddress = ServiceSettings.BASE_ADDRESS;
        }

        //Funcion asincrona para hacer prticiones get
        // El metodo Es protegido y se solo se puede utilizat si la clase es Heredada 
        // La funcion resive la entrada de un objeto generico 
        protected async Task<HttpResponse<XOutput>> GetAsync<XOutput>
            (
            // Parametos de seguridad 
            string path,
            string SaltKeyName,
            string SaltKey) where XOutput : new()
        {
            var resultCallAPI = new HttpResponse<XOutput>();

            // Se establece el comportamiento del cliente HTTP
            // para aceptar todos los certificados de servidor sin realizar una validación personalizada
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //Se establece la direcion de la consulta y se envian los heder necesarios 
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(_baseAddress + path);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add(SaltKeyName, SaltKey);
            request.Headers.Add("Authorization", "Bearer " + await TokenHelper.GetToken());

            // Se crea una intancia de HttpClient se utiliza para enviar la solicitud HTTP y recibir la respuesta. 
            var client = new HttpClient(clientHandler);
            HttpResponseMessage response = client.SendAsync(request).Result;

            // Si la repuesta es exitoxa entra
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //Se lee el contenido de la respusta como una cadena 
                string content = response.Content.ReadAsStringAsync().Result;
                // Se deserializa en un http
                resultCallAPI = JsonConvert.DeserializeObject<HttpResponse<XOutput>>(content);
            }
            await Task.CompletedTask;
            return resultCallAPI;
        }


    }
}

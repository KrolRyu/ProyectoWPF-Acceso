using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoWPF_Acceso.servicios
{
    static class ServicioMatricula
    {

        public static string SacarMatricula(string imagen, string tipo)
        {
            var response = PostMatricula(imagen);
            string urlGET = response.Headers[0].ToString().Split('=')[1];
            Thread.Sleep(2000);
            return GetMatricula(urlGET, tipo);

        }

        public static IRestResponse PostMatricula(string imagen)
        {
            //Cambiar variables a variables de configuracion
            var client = new RestClient("https://reconocimientomatriculasproyectoparking.cognitiveservices.azure.com/vision/v3.2/read/analyze");
            var request = new RestRequest(Method.POST);
            string data = "{ 'url':'" + imagen + "'}";
            request.AddHeader("Ocp-Apim-Subscription-Key", "5b398d14a7424edca5be3158a45093ce");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(data);
            var response = client.Execute(request);
            return response;
        }

        public static string GetMatricula(string url, string tipo)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", "5b398d14a7424edca5be3158a45093ce");
            var response = client.Execute(request);
            if (tipo == "coche")
            {
                JToken jt = JToken.Parse(response.Content).SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.SelectToken("text");
                return jt.ToString();
            }
            else
            {
                JToken jt = JToken.Parse(response.Content).SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.SelectToken("text");
                JToken jt2 = JToken.Parse(response.Content).SelectToken("analyzeResult").SelectToken("readResults")[1].SelectToken("lines").First.SelectToken("text");
                return jt.ToString() + jt2.ToString();
            }

        }
    }
}

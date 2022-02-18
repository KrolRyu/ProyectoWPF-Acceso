using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWPF_Acceso.servicios
{
    static class ServicioDetectarVehiculo
    {
        public static string ComprobarVehiculo(string ruta)
        {
            var respuesta = PostVehiculo(ruta);
            Root root = JsonConvert.DeserializeObject<Root>(respuesta.Content);
            try
            {
                if (root.predictions[0].probability > root.predictions[1].probability)
                {
                    return root.predictions[0].tagName;
                }
                else
                {
                    return root.predictions[1].tagName;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static IRestResponse PostVehiculo(string imagen)
        {
            var client = new RestClient(Properties.Settings.Default.EndpointIACustomVision);
            var request = new RestRequest(Properties.Settings.Default.MethodIACustomVision, Method.POST);
            string data = "{ 'url':'" + imagen + "'}";
            request.AddHeader("Prediction-Key", Properties.Settings.Default.PredictionKeyIACustomVision);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(data);
            var response = client.Execute(request);
            return response;
        }
    }
    public class Prediction
    {
        public double probability { get; set; }
        public string tagId { get; set; }
        public string tagName { get; set; }
    }

    public class Root
    {
        public string id { get; set; }
        public string project { get; set; }
        public string iteration { get; set; }
        public DateTime created { get; set; }
        public List<Prediction> predictions { get; set; }
    }
}

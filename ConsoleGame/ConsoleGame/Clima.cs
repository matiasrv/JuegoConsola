using System;
using System.IO;
using System.Net;

using Newtonsoft.Json.Linq;



namespace ConsoleGame
{
    class Clima
    {
        public static string GetClima()
        {
            string weather = "buenos aires";
            Console.Write("Obteniendo clima. . .");
            try
            {
                WebRequest req = WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + weather + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");

                WebResponse respuesta = req.GetResponse();

                Stream stream = respuesta.GetResponseStream();

                StreamReader sr = new StreamReader(stream);

                JObject data = JObject.Parse(sr.ReadToEnd());

                string clima = (string)data["query"]["results"]["channel"]["item"]["condition"]["text"];

                return clima;
            }
            catch
            {
                return "error";
            }
        }
    }
}

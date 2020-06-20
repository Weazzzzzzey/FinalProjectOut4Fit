using Newtonsoft.Json.Linq;
using Out4FitBeta.Classes;
using Out4FitBeta.DataBase;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Out4FitBeta.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values/id
        public JToken Get(string city)
        {
            WeatherDataSeparation weather = new WeatherDataSeparation();

            var client = new RestClient($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey=%20%09KfG1nMJ5g3M99pi4CGAEsaYApQCupum1%20&q={city}&language=en-us&details=true");

            var request = new RestRequest(Method.GET);
            request.AddHeader("host", "dataservice.accuweather.com");
            request.AddHeader("apikey", "KfG1nMJ5g3M99pi4CGAEsaYApQCupum1");
            IRestResponse response = client.Execute(request);
            string newjsonline = Convert.ToString(response.Content);

            return weather.CityKeyGeneration(newjsonline);
        }

    }
}

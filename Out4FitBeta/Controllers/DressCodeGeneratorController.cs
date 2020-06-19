using Newtonsoft.Json.Linq;
using Out4FitBeta.Business_Logic;
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
    public class DressCodeGeneratorController : ApiController
    {

        DataBaseController data = new DataBaseController();
        ValuesController values = new ValuesController();
        HandM hand = new HandM();

        // GET: api/dresscodegenerator/result
        public string Get(int id, string city)
        {
            string gender = data.Get(id);
            
            if (gender == "")
            {
                return "For subscribers only";
            }

            string key = values.Get(city);

            var client = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{key}?apikey=KfG1nMJ5g3M99pi4CGAEsaYApQCupum1&language=en-us&details=true&metric=true");

            var request = new RestRequest(Method.GET);
            request.AddHeader("host", "dataservice.accuweather.com");
            request.AddHeader("apikey", "KfG1nMJ5g3M99pi4CGAEsaYApQCupum1");
            IRestResponse response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            string newjsonline = Convert.ToString(json);

            ////pakaitinis
            //string path = @"C:\Users\deivi\Documents\WriteLines.txt";
            //string newjsonline = File.ReadAllText(path);
            ////

            DressCodePreparation DCP = new DressCodePreparation();
            string theResult = DCP.Preparation(newjsonline,gender);

            string finalResult = hand.ClothesGeneration(theResult,city,id);

            return finalResult;

        }

        // POST api/dresscodegenerator/addUser
        public string Post(string userName, string userGender ,string password)
        {
            data.Post(userName, userGender, password);
            return "User was added.";
        }


        // DELETE: api/dresscodegenerator/5
        public string Delete(int id)
        {
            data.Delete(id);
            return "User was deleted.";
        }

        // PUT: api/dresscodegenerator/5
        public string Put(int id, string value)
        {
            data.Put(id, value);
            return "Password was changed";
        }

    }
}

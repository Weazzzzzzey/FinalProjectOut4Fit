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

        // GET: api/dresscodegenerator/result
        public string Get(int id, string city)
        {
            string gender = data.Get(id);
            
            if (gender == "")
            {
                return "For subscribers only";
            }

            //string key = values.Get(city);

            //var client = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{key}?apikey=KfG1nMJ5g3M99pi4CGAEsaYApQCupum1&language=en-us&details=true&metric=true");

            //var request = new RestRequest(Method.GET);
            //request.AddHeader("host", "dataservice.accuweather.com");
            //request.AddHeader("apikey", "KfG1nMJ5g3M99pi4CGAEsaYApQCupum1");
            //IRestResponse response = client.Execute(request);
            //JObject json = JObject.Parse(response.Content);
            //string newjsonline = Convert.ToString(json);

            //pakaitinis
            string path = @"C:\Users\deivi\Documents\WriteLines.txt";
            string newjsonline = File.ReadAllText(path);
            //

            DressCodePreparation DCP = new DressCodePreparation();
            string theResult = DCP.Preparation(newjsonline,gender);

            List<string> categoriesInList = new List<string>();
            string[] categories = theResult.Split(',');

            for (int i = 0; i < categories.Length; i++)
            {
                categoriesInList.Add(categories[i]);
            }

            string finalResult = "";

            for (int i = 0; i < categoriesInList.Count-1; i++)
            {
                var client = new RestClient("https://apidojo-hm-hennes-mauritz-v1.p.rapidapi.com/products/list?categories=" + categoriesInList[i] + "&country=us&lang=en&currentpage=0&pagesize=1");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "apidojo-hm-hennes-mauritz-v1.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "9a5793a005mshb2a37a462d5ba89p10baacjsn1596887f9ad7");
                IRestResponse response = client.Execute(request);
                JObject json = JObject.Parse(response.Content);
                string firstsplit = Convert.ToString(json);
                string[] firstsplit1 = firstsplit.Split(new string[] { "\"name\":" }, StringSplitOptions.None);
                string[] secondsplit = firstsplit1[1].Split(new string[] { "\"stock\":" }, StringSplitOptions.None);
                finalResult = finalResult + secondsplit[0];
            }

            //
            // Create a string array with the lines of text
            string[] lines = { $"{finalResult + "," + categoriesInList.Last()}" };

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "final.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }


            //

            return finalResult + "," + categoriesInList.Last();

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

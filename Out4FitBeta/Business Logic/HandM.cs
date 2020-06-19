using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Out4FitBeta.Business_Logic
{
    public class HandM
    {
    
        public string ClothesGeneration(string theResult)
        {
            List<string> categoriesInList = new List<string>();
            string[] categories = theResult.Split(',');

            for (int i = 0; i < categories.Length; i++)
            {
                categoriesInList.Add(categories[i]);
            }

            string finalResult = "";

            for (int i = 0; i < categoriesInList.Count - 1; i++)
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

            return finalResult + "," + categoriesInList.Last();
        }
    
    }
}
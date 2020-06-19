using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Out4FitBeta.Classes
{
    public class WeatherDataSeparation
    {
        public string CityKeyGeneration(string bigTextOfCity)
        {
            string key = "";
            string[] partsOfText = bigTextOfCity.Split(new string[] { "Key\":\"" }, StringSplitOptions.None);
            string[] frontOfKey = partsOfText[1].Split('"');
            key = frontOfKey[0];
            return key;
        }


        public string Separation(string weatherFullDataLine)
        {
            //RealTemp ,HoursOfSun, windSpeed, rain
            List<string> temperature = new List<string>();
            List<string> hoursOfSun = new List<string>();
            List<string> windSpeed = new List<string>();
            List<string> rain = new List<string>();

            string returnas = "";

            string readText = weatherFullDataLine;

            string[] isskaidytasIdienas = readText.Split(new string[] { "\"Date\"" }, StringSplitOptions.None);
            List<string> dienos = new List<string>();
            dienos.Add(isskaidytasIdienas[1]);
            dienos.Add(isskaidytasIdienas[2]);
            dienos.Add(isskaidytasIdienas[3]);
            dienos.Add(isskaidytasIdienas[4]);
            dienos.Add(isskaidytasIdienas[5]);

            for (int i = 0; i < dienos.Count; i++)
            {
                string[] temeraturos = dienos[i].Split(new string[] { "RealFeelTemperature" }, StringSplitOptions.None);
                string[] temperatura = temeraturos[1].Split(new string[] { "\"Value\": " }, StringSplitOptions.None);
                string[] low = temperatura[1].Split(','); // low high
                string[] high = temperatura[2].Split(','); // low high
                double bendra = (Convert.ToDouble(high[0].Replace('.', ',')) + Convert.ToDouble(low[0].Replace('.', ','))) / 2; // + Convert.ToDouble(high[0]);
                //Console.WriteLine(high[0]);
                temperature.Add(bendra.ToString());
            }

            for (int i = 0; i < dienos.Count; i++)
            {
                string[] dienosValandos = dienos[i].Split(new string[] { "HoursOfSun" }, StringSplitOptions.None);
                string[] skaicius = dienosValandos[1].Split(new string[] { "\": " }, StringSplitOptions.None);
                string[] valandos = skaicius[1].Split(','); // low high
                hoursOfSun.Add(valandos[0]);

            }

            for (int i = 0; i < dienos.Count; i++)
            {
                string[] wind = dienos[i].Split(new string[] { "Wind" }, StringSplitOptions.None);
                string[] windspeed = wind[1].Split(new string[] { "\"Value\": " }, StringSplitOptions.None);
                string[] windspeednumber = windspeed[1].Split(','); // wind

                //Console.WriteLine(high[0]);
                windSpeed.Add(windspeednumber[0]);
            }

            for (int i = 0; i < dienos.Count; i++)
            {
                string[] rainDay = dienos[i].Split(new string[] { "\"Rain\": " }, StringSplitOptions.None);
                string[] rainSpeed = rainDay[1].Split(new string[] { "\"Value\": " }, StringSplitOptions.None);
                string[] rainSpeednumber = rainSpeed[1].Split(','); // wind

                //Console.WriteLine(high[0]);
                rain.Add(rainSpeednumber[0]);
            }


            foreach (var item in temperature)
            {
                returnas = returnas + item.Replace(',', '.') + ",";
            }

            foreach (var item in hoursOfSun)
            {
                returnas = returnas + item.Replace(',', '.') + ",";
            }

            foreach (var item in windSpeed)
            {
                returnas = returnas + item.Replace(',', '.') + ",";
            }

            foreach (var item in rain)
            {
                returnas = returnas + item.Replace(',', '.') + ",";
            }

            returnas = returnas.Remove(returnas.Length - 1, 1) + "";

            return returnas;
        }

    }
}
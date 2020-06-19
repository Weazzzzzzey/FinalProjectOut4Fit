using Out4FitBeta.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Out4FitBeta.Business_Logic
{
    public class DressCodePreparation
    {
        List<string> temperature = new List<string>();
        List<string> hoursOfSun = new List<string>();
        List<string> windSpeed = new List<string>();
        List<string> rain = new List<string>();

        WeatherDataSeparation weather = new WeatherDataSeparation();

        public string Preparation(string weatherFullDataLine, string gender)
        {
            string finalyResult = "";

            WeatherInfo(weatherFullDataLine);

            for (int i = 0; i < 1; i++)
            {
                finalyResult = finalyResult + Gender(gender, Convert.ToDouble(temperature[i].Replace('.', ',')), Convert.ToDouble(hoursOfSun[i].Replace('.', ',')), Convert.ToDouble(windSpeed[i].Replace('.', ',')), Convert.ToDouble(rain[i].Replace('.', ','))) + "," + temperature[i];
            }

            return finalyResult;


        }

        private void WeatherInfo(string weatherFullDataLine)
        {
            string data = weather.Separation(weatherFullDataLine);
            string[] everyData = data.Split(',');

            //Console.WriteLine(data);

            for (int i = 0; i < 1; i++)
            {
                temperature.Add(everyData[i]);
                hoursOfSun.Add(everyData[i + 5]);
                windSpeed.Add(everyData[i + 10]);
                rain.Add(everyData[i + 15]);
            }
        }

        private string Gender(string gender, double RealTemp, double HoursOfSun, double windSpeed, double rain)
        {

            if (gender.Equals("Male") || gender.Equals("male"))
            {
                return clothesMen(RealTemp, HoursOfSun, windSpeed, rain);
            }
            else
            {
                return clothesWomen(RealTemp, HoursOfSun, windSpeed, rain);
            }
        }

        private string clothesMen(double RealTemp, double HoursOfSun, double windSpeed, double rain)
        {

            string recommendation = "";


            //Hat
            if (RealTemp < -5)
            {
                recommendation = recommendation + "men_accessories_hatscaps_beanie,";
            }
            else if (RealTemp > -4 && RealTemp < 10 && windSpeed > 30)
            {
                recommendation = recommendation + "men_accessories_hatscaps_beanie,";
            }
            else if (RealTemp > -4 && RealTemp < 10 && windSpeed < 30)
            {
                recommendation = recommendation + "";
            }
            else if (RealTemp > 10 && RealTemp < 18 && HoursOfSun > 11)
            {
                recommendation = recommendation + "men_accessories_hatscaps_hats,";
            }
            else if (RealTemp > 10 && RealTemp < 18 && HoursOfSun < 11)
            {
                recommendation = recommendation + "";
            }
            else if (RealTemp > 18 && HoursOfSun > 11)
            {
                recommendation = recommendation + "men_accessories_hatscaps_hats,";
            }
            else if (RealTemp > 18 && HoursOfSun < 11)
            {
                recommendation = recommendation + "";
            }



            //Jackets
            if (RealTemp < -5)
            {
                recommendation = recommendation + "men_shirts_casual,men_hoodiessweatshirts_hoodies,men_jacketscoats_jackets,";
            }
            else if (RealTemp > -4 && RealTemp < 10)
            {
                recommendation = recommendation + "men_shirts_casual,men_hoodiessweatshirts_hoodies,men_jacketscoats_jackets,";
            }
            else if (RealTemp > 11 && RealTemp < 18 && windSpeed > 49)
            {
                recommendation = recommendation + "men_shirts_casual,men_hoodiessweatshirts_hoodies,men_jacketscoats_jackets,";
            }
            else if (RealTemp > 11 && RealTemp < 18 && windSpeed < 49)
            {
                recommendation = recommendation + "men_shirts_casual,men_hoodiessweatshirts_hoodies,";
            }
            else if (RealTemp >= 18 && windSpeed > 49)
            {
                recommendation = recommendation + "men_shirts_casual,men_hoodiessweatshirts_hoodies,";
            }
            else if (RealTemp >= 18 && windSpeed < 49)
            {
                recommendation = recommendation + "men_shirts_casual,";
            }

            //Jeans
            if (RealTemp < -5)
            {
                recommendation = recommendation + "men_jeans_straight,";
            }
            else if (RealTemp > -4 && RealTemp < 10)
            {
                recommendation = recommendation + "men_jeans_straight,";
            }
            else if (RealTemp > 10 && RealTemp < 20 && windSpeed > 49)
            {
                recommendation = recommendation + "men_jeans_straight,";
            }
            else if (RealTemp > 10 && RealTemp < 20 && windSpeed < 49)
            {
                recommendation = recommendation + "men_shorts_cargo,";
            }
            else if (RealTemp > 20)
            {
                recommendation = recommendation + "men_shorts_cargo,";
            }
            else if (RealTemp > 20 && windSpeed < 49)
            {
                recommendation = recommendation + "men_shorts_cargo,";
            }

            //Shoes
            if (RealTemp < -5)
            {
                recommendation = recommendation + "men_shoes_sneakers";
            }
            else if (RealTemp > -4 && RealTemp < 10)
            {
                recommendation = recommendation + "men_shoes_sneakers";
            }
            else if (RealTemp > 10 && RealTemp < 20)
            {
                recommendation = recommendation + "men_shoes_sneakers";
            }
            else if (RealTemp > 20)
            {
                recommendation = recommendation + "men_shoes_sneakers";
            }

            return recommendation;
        }

        private string clothesWomen(double RealTemp, double HoursOfSun, double windSpeed, double rain)
        {

            string recommendation = "";

            //Hat
            if (RealTemp < -5)
            {
                recommendation = recommendation + "";
            }
            else if (RealTemp > -4 && RealTemp < 10 && windSpeed > 30)
            {
                recommendation = recommendation + "";
            }
            else if (RealTemp > -4 && RealTemp < 10 && windSpeed < 30)
            {
                recommendation = recommendation + "";
            }
            else if (RealTemp > 10 && RealTemp < 18 && HoursOfSun > 11)
            {
                recommendation = recommendation + "ladies_accessories_hats_caps,";
            }
            else if (RealTemp > 10 && RealTemp < 18 && HoursOfSun < 11)
            {
                recommendation = recommendation + "";
            }
            else if (RealTemp > 18 && HoursOfSun > 11)
            {
                recommendation = recommendation + "ladies_accessories_hats_caps,";
            }
            else if (RealTemp > 18 && HoursOfSun < 11)
            {
                recommendation = recommendation + "";
            }



            //Jackets
            if (RealTemp < -5)
            {
                recommendation = recommendation + "ladies_shirtsblouses_shirts,ladies_cardigansjumpers_jumpers,ladies_jacketscoats_coats,";
            }
            else if (RealTemp > -4 && RealTemp < 10)
            {
                recommendation = recommendation + "ladies_shirtsblouses_shirts,ladies_cardigansjumpers_jumpers,ladies_jacketscoats_coats,";
            }
            else if (RealTemp > 11 && RealTemp < 18 && windSpeed > 49)
            {
                recommendation = recommendation + "ladies_shirtsblouses_shirts,ladies_cardigansjumpers_jumpers,ladies_jacketscoats_coats,";
            }
            else if (RealTemp > 11 && RealTemp < 18 && windSpeed < 49)
            {
                recommendation = recommendation + "ladies_shirtsblouses_shirts,ladies_cardigansjumpers_jumpers,";
            }
            else if (RealTemp >= 18 && windSpeed > 49)
            {
                recommendation = recommendation + "ladies_shirtsblouses_shirts,ladies_cardigansjumpers_jumpers,";
            }
            else if (RealTemp >= 18 && windSpeed < 49)
            {
                recommendation = recommendation + "ladies_shirtsblouses_shirts,";
            }

            //Jeans
            if (RealTemp < -5)
            {
                recommendation = recommendation + "ladies_jeans_skinny,";
            }
            else if (RealTemp > -4 && RealTemp < 10)
            {
                recommendation = recommendation + "ladies_jeans_skinny,";
            }
            else if (RealTemp > 10 && RealTemp < 20 && windSpeed > 49)
            {
                recommendation = recommendation + "ladies_jeans_skinny,";
            }
            else if (RealTemp > 10 && RealTemp < 20 && windSpeed < 49)
            {
                recommendation = recommendation + "ladies_dresses_denim,";
            }
            else if (RealTemp > 20)
            {
                recommendation = recommendation + "ladies_dresses_denim,";
            }
            else if (RealTemp > 20 && windSpeed < 49)
            {
                recommendation = recommendation + "ladies_dresses_denim,";
            }

            //Shoes
            if (RealTemp < -5)
            {
                recommendation = recommendation + "ladies_shoes_sneakers";
            }
            else if (RealTemp > -4 && RealTemp < 10)
            {
                recommendation = recommendation + "ladies_shoes_sneakers";
            }
            else if (RealTemp > 10 && RealTemp < 20)
            {
                recommendation = recommendation + "ladies_shoes_sneakers";
            }
            else if (RealTemp > 20)
            {
                recommendation = recommendation + "ladies_shoes_sneakers";
            }

            return recommendation;
        }

    }
}
![image](https://venturebeat.com/wp-content/uploads/2019/11/visual-studio-logo.jpeg?fit=578%2C289&strip=all)

# Out4Fit

Out4Fit is an API that lets users get outfit recommendations based on their gender and weather.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What you need to run our project:

* Visual Studio
* Ethernet
* XAMPP

### Installing

* Download and open project in Visual Studio.
* Run the application.
* Run XAMPP and open mySQL database.
* Add /swagger to the URL of the opened browser.
	- Click Users tab and select the Post method to create a new user (insert your name, gender and password).
	- Click Put method to change your password using your user ID and new password.
	- Click Delete to delete an user using user's ID.
	- Click DressCodeGenerator tab and select a get method, then enter your user ID and name of your city. The method will return an outfit recommendation based on the weather in your city and also the local temperature.
	- Click users tab and the Get method and enter user's ID to save the last DressCodeGenerator results.
	- Click Get Users method to return all users.
	- Click Get Vlues to generaty a city code.
* Run Postman
	- Select Get method and insert a link to return the data. Link example : https:// [your local host] /api/Values?city=vilnius

## Built With

* [Visual Studio](https://visualstudio.microsoft.com/en/downloads/) - Microsoft platform .NET
* [RapidAPI HM](https://rapidapi.com/apidojo/api/hm-hennes-mauritz/) - API that returns clothes
* [AccuWeather](https://developer.accuweather.com/) - API that returns weather info
* [XAMPP](https://www.apachefriends.org/index.html) - Program used to access mySQL database
  
## Authors

* Deividas Tilindis - Developer
* Aurimas Gervelis - Analyst
* Mykolas Skukauskas - Quality assurance specialist

## License
All source code and main ideas belongs to Out4Fit. All rights reserved. 2020




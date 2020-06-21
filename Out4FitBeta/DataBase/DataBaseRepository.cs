using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Ajax.Utilities;
using System.Web.Script.Serialization;
using Out4FitBeta.Business_Logic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Out4FitBeta.DataBase
{
    public class DataBaseRepository : DataBaseConnection
    {
        public string Select(int id)
        {
            connection.Open();
            string userGender = "";
            try
            {
                sqlEil = $"SELECT * FROM `user` WHERE `userID` = {id}";

                //cmd = new MySqlCommand(sqlEil, connection);

                adap = new MySqlDataAdapter(sqlEil, connection);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                DataTable dataGridView1 = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    userGender = ds.Tables[0].Rows[0]["gender"].ToString();

                }
                return userGender;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public string Insert(string userName, string gender, string password)
        {
            connection.Open();
            try
            {
                sqlEil = $"INSERT INTO `user` (`userID`, `userName`, `gender`, `password`) VALUES (NULL, '{userName}', '{gender}', '{password}');";
                cmd = new MySqlCommand(sqlEil, connection);
                cmd.ExecuteNonQuery();
                return "User was added";
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public string Delete(int id)
        {

            connection.Open();

            try
            {

                sqlEil = $"DELETE FROM `user` WHERE `userID` = {id}";

                cmd = new MySqlCommand(sqlEil, connection);
                cmd.ExecuteNonQuery();
                return "User Was deleted.";

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }


        }

        public string Update(int id, string newpassword, string gender)
        {
            connection.Open();

            try
            {
                sqlEil = $"UPDATE `user` SET `gender` = '{gender}', `password` = '{newpassword}' WHERE `user`.`userID` = {id};";
                cmd = new MySqlCommand(sqlEil, connection);
                cmd.ExecuteNonQuery();
                return "User was updated";
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void Insert(int userId, string city, string body, string temperature)
        {
            
            connection.Open();
            try
            {
                sqlEil = $"INSERT INTO `allrequestsever` (`ID`, `userID`, `city`, `temperature`, `responsebody`) VALUES (NULL, '{userId}', '{city}', '{temperature}', '{body}');";
                cmd = new MySqlCommand(sqlEil, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public string selectAllUsers()
        {
            List<Users> Useriai = new List<Users>();
            
            connection.Open();
            
            try
            {
                sqlEil = $"SELECT * FROM `user`";

                adap = new MySqlDataAdapter(sqlEil, connection);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                DataTable dataGridView1 = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string userID = ds.Tables[0].Rows[i]["userID"].ToString();
                        string username = ds.Tables[0].Rows[i]["userName"].ToString();
                        string userGenderr = ds.Tables[0].Rows[i]["gender"].ToString();
                        string userPass = ds.Tables[0].Rows[i]["password"].ToString();

                        Useriai.Add(new Users(Convert.ToInt32(userID),username,userGenderr,userPass));
                    }

                }

                StringBuilder allUsers = new StringBuilder();
                char kabutes = '"';
                allUsers.Append("{");
                allUsers.Append(kabutes + "Users" + kabutes + ": [");
                allUsers.Append("{");
                foreach (var item in Useriai)
                {
                    allUsers.Append(kabutes + "UserID" + kabutes+ ":" + item.getID());
                    allUsers.Append(kabutes + "UserName" + kabutes+ ":" + item.getUserName());
                    allUsers.Append(kabutes + "UserGender" + kabutes + ":" +  item.getGender());
                }

                allUsers.Append("}");
                allUsers.Append("]");
                allUsers.Append("}");
                return allUsers.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public string selectSavedRequests(int id)
        {
            connection.Open();
            StringBuilder savedData = new StringBuilder();
            try
            {
                sqlEil = $"SELECT * FROM `userssaved` WHERE `userID` = {id}";

                adap = new MySqlDataAdapter(sqlEil, connection);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                DataTable dataGridView1 = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    char kabutes = '"';
                    savedData.Append("{");
                    savedData.Append(kabutes + "SavedData" + kabutes + ": [");
                    

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string userID = ds.Tables[0].Rows[i]["userID"].ToString();
                        string city = ds.Tables[0].Rows[i]["city"].ToString();
                        string temperature = ds.Tables[0].Rows[i]["temperature"].ToString();
                        string response = ds.Tables[0].Rows[i]["responseBody"].ToString();

                        savedData.Append("{");
                        savedData.Append(kabutes + "UserID" + kabutes + ":" + userID);
                            savedData.Append(kabutes + "City" + kabutes + ":" + city);
                            savedData.Append(kabutes + "temperature" + kabutes + ":" + temperature);
                            savedData.Append(kabutes + "response" + kabutes + ":" + response);
                        savedData.Append("}");
                    }
                    savedData.Append("]");
                    savedData.Append("}");
                }


                return savedData.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public string SelectAndInsert(int userId)
        {

            connection.Open();
            string userID = "";
            string userCity = "";
            string userTemp = "";
            string userResponse = "";
            try
            {
                sqlEil = $"SELECT * FROM `allrequestsever` WHERE `userID` = {userId}";
                int count = 0;


                //cmd = new MySqlCommand(sqlEil, connection);

                adap = new MySqlDataAdapter(sqlEil, connection);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                DataTable dataGridView1 = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
                    userID = ds.Tables[0].Rows[count - 1]["userID"].ToString();
                    userCity = ds.Tables[0].Rows[count - 1]["city"].ToString();
                    userTemp = ds.Tables[0].Rows[count - 1]["temperature"].ToString();
                    userResponse = ds.Tables[0].Rows[count - 1]["responsebody"].ToString();

                }
                else return null;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            connection.Open();
            try
            {
                sqlEil = $"INSERT INTO `userssaved` (`requestID`, `userID`, `city`, `temperature`, `responseBody`) VALUES (NULL, '{userID}', '{userCity}', '{userTemp}', '{userResponse}');";
                cmd = new MySqlCommand(sqlEil, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return $"Last record was added.";

        }

    }
}
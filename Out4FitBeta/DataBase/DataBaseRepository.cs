using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

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
                    userGender = ds.Tables[0].Rows[0]["gender"].ToString(); //paleist i male arba female

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

        public void Insert(string userName, string gender, string password)
        {
            connection.Open();
            try
            {
                sqlEil = $"INSERT INTO `user` (`userID`, `userName`, `gender`, `password`) VALUES (NULL, '{userName}', '{gender}', '{password}');";
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

        public void Delete(int id)
        {

            connection.Open();

            try
            {

                sqlEil = $"DELETE FROM `user` WHERE `userID` = {id}";

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

        public void Update(int id, string newpassword)
        {
            connection.Open();

            try
            {
                sqlEil = $"UPDATE `user` SET `password` = '{newpassword}' WHERE `user`.`userID` = {id}";
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

    }
}
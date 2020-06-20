using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Out4FitBeta.Business_Logic
{
    public class Users
    {
        private int userID { get; set; }
        private string userName { get; set; }
        private string gender { get; set; }
        private string password { get; set; }

        public Users(int userID, string userName, string gender, string password)
        {
            this.userID = userID;
            this.userName = userName;
            this.gender = gender;
            this.password = password;
        }

        public string getUserName()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }

        public int getID()
        {
            return userID;
        }

        public string getGender()
        {
            return gender;
        }
    }
}
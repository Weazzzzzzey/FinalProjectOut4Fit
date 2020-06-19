using Out4FitBeta.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Out4FitBeta.Controllers
{

    public class DataBaseController : ApiController
    {
        
        DataBaseRepository dataBase = new DataBaseRepository();

        // GET: api/DataBase/5
        public string Get(int id)
        {
            return dataBase.Select(id);
        }

        // POST: api/DataBase
        [ActionName("route")]
        public string Post(string userName, string usergender ,string password)
        {
            dataBase.Insert(userName,usergender,password);
            return "User was added.";
        }

        // PUT: api/DataBase/5
        public string Put(int id, string value)
        {
            dataBase.Update(id,value);
            return "Password was changed";
        }

        // DELETE: api/DataBase/5
        public string Delete(int id)
        {
            dataBase.Delete(id);
            return "User was deleted.";
        }
    }
}

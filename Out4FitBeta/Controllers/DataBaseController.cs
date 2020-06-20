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
            return dataBase.SelectAndInsert(id);
        }

        // POST: api/DataBase
        [ActionName("route")]
        public string Post(string userName, string usergender ,string password)
        {
            return dataBase.Insert(userName,usergender,password);            
        }

        // PUT: api/DataBase/5
        public string Put(int id, string password)
        {
            return dataBase.Update(id,password);
        }

        // DELETE: api/DataBase/5
        public string Delete(int id)
        {
            return dataBase.Delete(id);            
        }
    }
}

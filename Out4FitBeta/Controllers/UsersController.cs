using Newtonsoft.Json.Linq;
using Out4FitBeta.Business_Logic;
using Out4FitBeta.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Out4FitBeta.Controllers
{

    public class UsersController : ApiController
    {
        DataBaseRepository dataBase = new DataBaseRepository();

        // GET: api/DataBase/5
        public JToken Get(int id)
        {
            return dataBase.SelectAndInsert(id);
        }

        // GET: api/DataBase/5
        public JToken Get()
        {
            return dataBase.selectAllUsers();
        }

        // POST: api/DataBase
        public JToken Post([FromBody] Users data)
        {
            return dataBase.Insert(data.getUserName(),data.getGender(),data.getPassword());            
        }

        // PUT: api/DataBase/5
        public JToken Put(int id, [FromBody] Users data) //
        {
            Users toChange = data;
            if (toChange.getID() == id)
            {
                return dataBase.Update(id, toChange.getPassword(),toChange.getGender());
            }
            else return "Error";
        }

        // DELETE: api/DataBase/5
        public JToken Delete(int id)
        {
            return dataBase.Delete(id);            
        }
    }
}

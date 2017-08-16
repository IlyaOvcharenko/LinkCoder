using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Services;
using Data;
using DataAccess;
using DataAccess.Repositories;

namespace Web.Controllers
{
    public class UsersController : ApiController
    {
        

        // POST api/users
        public User Post([FromBody]string value)
        {
            var u = new User();
            using (var dc = new DataContext())
            {
                
                dc.Users.Add(u);
                dc.SaveChanges();
            }
            return u;
        }

        
    }
}

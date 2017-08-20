using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Data;
using DataAccess;
using DataAccess.Repositories;
using Web.Common;

namespace Web.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("api/users")]
        // POST api/users
        public IHttpActionResult Post()
        {
            var user = _userService.CreateUser();
            return Ok(new { user = user, token = TokenGenerator.GenerateToken(user.Id.ToString()) });
        }

        
    }
}

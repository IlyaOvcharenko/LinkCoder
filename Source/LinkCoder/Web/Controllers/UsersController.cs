using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Data;
using DataAccess;
using DataAccess.Repositories;

namespace Web.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/users
        public User Post()
        {
            var user = _userService.CreateUser();
            return user;
        }

        
    }
}

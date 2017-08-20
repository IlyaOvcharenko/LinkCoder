using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services.Interfaces;
using Data;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly ICommonRepository<User> _userRepository;  
        public UserService(ICommonRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser()
        {
            return Logger.ErrorListener(() =>
            {
                var user = new User();
                _userRepository.Create(user);
                return user;
            });
        }
    }
}

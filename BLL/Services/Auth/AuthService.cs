using BLL.Services.Auth.Descriptors;
using DAL.Models;
using DAL.Repositories.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.Exceptions;

namespace BLL.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public Task<string> LoginAsync(LoginDescriptor descriptor)
        {
            throw new BusinessException(HttpStatusCode.Conflict, "User already exists!");
        }

        public Task RegisterAsync(RegisterDescriptor descriptor)
        {
            var existsUser = _userRepository.GetUserByEmail(descriptor.Email);
            if (existsUser != null)
            {
                throw new BusinessException(HttpStatusCode.Conflict, "User already exists!");
            }

            var registerUser = new User()
            {
                FirstName = descriptor.FirstName,
                LastName = descriptor.LastName,
                Email = descriptor.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            // Save the new user
            _userRepository.CreateUser(registerUser);
            _userRepository.Save();

            return Result.Success;
        }
    }
}

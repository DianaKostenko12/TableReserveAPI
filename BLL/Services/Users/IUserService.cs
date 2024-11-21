﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Users
{
    public interface IUserService
    {
        public Task<User> GetUserById(string id);
    }
}

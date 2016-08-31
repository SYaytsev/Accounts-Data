using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Services
{
    interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
}

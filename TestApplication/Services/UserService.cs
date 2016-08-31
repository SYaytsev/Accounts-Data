using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TestApplication.Models;

namespace TestApplication.Services
{
    public class UserService : IUserService
    {
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            string path = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "App_Data\\accounts.json");

            try
            {
                using (var reader = new StreamReader(path))
                {
                    string line = "[" + await reader.ReadToEndAsync() + "]";
                    users = JsonConvert.DeserializeObject<List<User>>(line);
                }
            }
            catch (Exception) { throw; }

            return await Task.Factory.StartNew(() => users);
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            string path = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "App_Data\\data.json");

            try
            {
                using (var reader = new StreamReader(path))
                {
                    string line = await reader.ReadToEndAsync();
                    employees = JsonConvert.DeserializeObject<List<Employee>>(line);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.Factory.StartNew(() => employees);
        }
    }
}
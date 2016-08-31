using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Services
{
    interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
    }
}

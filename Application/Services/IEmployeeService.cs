using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeeService
    {
        Task<int> SaveEmployeeDetails(Models.EmployeeDetails employeeDetails);
    }
}

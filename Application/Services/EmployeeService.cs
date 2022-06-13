using Models;
using System;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFormRepository _employeeRepo;

        public EmployeeService(IFormRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task SaveEmployeeDetails(EmployeeDetails employeeDetails)
        {
            var form = new Form(employeeDetails);
           await _employeeRepo.SaveFormDetails(form);
        }
    }
}

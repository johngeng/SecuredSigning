using Models;
using System;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFormRepository _formRepo;

        public EmployeeService(IFormRepository formRepo)
        {
            _formRepo = formRepo;
        }
        public async Task<int> SaveEmployeeDetails(EmployeeDetails employeeDetails)
        {
            if (!employeeDetails.IsValid())
            {
                throw new Exception("There are some errors in employee details validation.");
            }

            var fields = await _formRepo.GetFields();
            var form = new Form(FormType.PDF, fields, null, employeeDetails);
            return await _formRepo.SaveFormDetails(form);
        }
    }
}

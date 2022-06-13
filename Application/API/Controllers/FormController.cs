using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public FormController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost()]
        public async Task<ActionResult> SaveEmploymentDetails([FromBody] EmployeeDetails details)
        {
            try
            {
                await _employeeService.SaveEmployeeDetails(details);
                return Ok();
            }
            catch
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
            }
        }

        //[HttpPost()]
        //[Route("api/form/employmentdetail")]
        //public async Task<ActionResult> SaveEmploymentDetails([FromBody] EmployeeDetails details)
        //{
        //    try
        //    {
        //        await _employeeService.SaveEmployeeDetails(details);
        //        return Ok();
        //    }
        //    catch 
        //    {
        //        return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
        //    }
        //}
    }
}

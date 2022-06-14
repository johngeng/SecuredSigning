using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {    
        private readonly ILogger<FormController> _logger;
        private IEmployeeService _employeeService;
        public FormController(IEmployeeService employeeService, ILogger<FormController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        
        [HttpGet()]
        public ActionResult Index()
        {
            return Ok("");
        }
        [HttpPost()]
        public async Task<ActionResult> Save([FromBody] EmployeeDetails details)
        {
            try
            {
                var formId = await _employeeService.SaveEmployeeDetails(details);
                return Ok(formId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Stack: {ex.StackTrace}");
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

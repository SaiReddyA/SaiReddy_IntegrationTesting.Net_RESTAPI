namespace SaiReddy_IntegrationRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("LoadEmployeeDetails")]
        public List<Employee>? LoadEmployee()
        {
            try
            {
                var employee = new Employee
                {
                    Id = 1,
                    Name = "Sai Reddy",
                    Age = 28,
                    Department = "Software Development",
                    Position = "Full-Stack Developer"
                };
                List<Employee> employeeList = new();
                     employeeList?.Add(employee);
                return employeeList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching employee details.");
                throw;
            }
        }
    }

}

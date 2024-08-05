using Microsoft.AspNetCore.Mvc;
using Sozinho01.Aplication.ViewModel;
using Sozinho01.Domain.Model;

namespace Sozinho01.Controllers.v1
{
    [ApiController]
    [Route("api/v1/routes")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        private readonly Employee _employee;


        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.name, employeeView.age, null);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) 
        {
            var employee = _employeeRepository.Get(id);
            return Ok(employee);
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var employee = _employeeRepository.GetAll();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) 
        {
            _employeeRepository.delete(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromForm]EmployeeViewModel employeeView)
        {
            var existing = _employeeRepository.Get(id);

            existing.Up(employeeView.name, employeeView.age, employeeView.photo);
            _employeeRepository.update(existing);
            return Ok(existing);
        }
    }
}

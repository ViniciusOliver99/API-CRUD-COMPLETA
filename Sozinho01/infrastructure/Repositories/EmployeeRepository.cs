using Sozinho01.Domain.Model;

namespace Sozinho01.infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public Employee? Get(int id)
        {
            return _context.Employee.Find(id);
        }

        public void delete(int id)
        {
            var employee = _context.Employee.Find(id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
        }

        public void update(Employee employee)
        {
            var UpEmployee = _context.Employee.Find(employee.id);

            UpEmployee.Up(employee.name, employee.age, employee.photo);
            _context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return _context.Employee.ToList();      
        }
    }
}

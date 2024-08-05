namespace Sozinho01.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add (Employee employee);
        Employee? Get(int id);
        void delete(int id);
        void update (Employee employee);
        List<Employee>GetAll();

    }
}

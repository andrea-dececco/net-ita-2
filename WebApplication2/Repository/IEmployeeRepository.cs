using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee? GetById(Guid id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}

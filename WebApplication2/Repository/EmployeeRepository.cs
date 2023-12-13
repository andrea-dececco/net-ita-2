using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public static List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public Employee? GetById(Guid id)
        {
            return employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }


    }
}

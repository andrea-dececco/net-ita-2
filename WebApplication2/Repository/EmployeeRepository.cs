using WebApplication2.Repository.Context;
using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IDbContext _db;

        public EmployeeRepository(IDbContext db)
        {
            _db = db;
        }

        public void AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return _db.Employees;
        }

        public Employee? GetById(Guid id)
        {
            return _db.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }


    }
}

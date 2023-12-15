using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository.Context
{
    public interface IDbContext
    {
        public List<Employee> Employees { get; set; }
        public List<Role> Roles {  get; set; }
    }
}

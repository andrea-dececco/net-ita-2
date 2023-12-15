using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository.Context
{
    public class DbContext : IDbContext
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Role> Roles { get; set; } = new();
    }
}

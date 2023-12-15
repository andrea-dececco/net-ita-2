using WebApplication2.Repository.Context;
using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _db;

        public RoleRepository(IDbContext db) 
        {
            _db = db;
        }

        public void Add(string name)
        {
            _db.Roles.Add(new Role { RoleName = name});
        }

        public List<Role> GetRoles()
        {
            return _db.Roles;
        }
    }
}

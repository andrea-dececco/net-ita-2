using WebApplication2.Repository.Entities;

namespace WebApplication2.Repository
{
    public interface IRoleRepository
    {
        public void Add(string name);
        public List<Role> GetRoles();
    }
}

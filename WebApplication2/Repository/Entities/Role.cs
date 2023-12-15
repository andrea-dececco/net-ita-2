namespace WebApplication2.Repository.Entities
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? RoleName {  get; set; }
    }
}

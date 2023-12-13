namespace WebApplication2.Repository.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public decimal? Ral { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BirthPlace { get; set; }  
       
    }
}

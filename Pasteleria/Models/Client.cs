namespace Pasteleria.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<UserRole> Role { get; set; }

        public string PassWord { get; set; }
    }
}

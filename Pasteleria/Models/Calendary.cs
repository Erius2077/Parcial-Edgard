namespace Pasteleria.Models
{
    public class Calendary
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<CalendaryTime> Time { get; set; }
    }
}

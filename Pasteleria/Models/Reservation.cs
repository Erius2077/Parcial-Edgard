namespace Pasteleria.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<ReservationStatus> Status { get; set; }
        public ICollection<Cake> Name { get; set; }
        public ICollection<Cake> Price { get; set; }
    }
}

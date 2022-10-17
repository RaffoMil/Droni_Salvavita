namespace Droni_Salvavita.Models
{
    public class Volo
    {
        public int FlightId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public Drone? Drone { get; set; }

    }
}

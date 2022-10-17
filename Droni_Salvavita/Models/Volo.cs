namespace Droni_Salvavita.Models
{
    public class Volo
    {
        public int Id { get; set; }

        public DateTime DataPartenza { get; set; }

        public DateTime DateFine { get; set; }

        public Drone Drone { get; set; }

    }
}

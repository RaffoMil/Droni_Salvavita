namespace Droni_Salvavita.Models
{
    public class Drone
    {
        public enum PropulsionType
        {
            Reaction = 1,
            FixedWing = 2,
            Helix = 3
        }

        public enum PilotType
        {
            Pilot = 1,
            AI = 2
        }

        public int DroneId { get; set; }
        public TimeSpan FlightTime { get; set; }
        public PropulsionType TypePropulsore { get; set; }
        public PilotType TypeGuida { get; set; }


    }
}

using Droni_Salvavita.Models;

namespace Droni_Salvavita.Services
{
    public class DroneService
    {
        private  Drone drone = new Drone();
        private  Volo volo = new Volo();

        
        

        private TimeSpan GetTimeSpan (DateTime DepartureDate, DateTime ArrivalDate)
        {
            drone.FlightTime = ArrivalDate - DepartureDate;
            return drone.FlightTime;
        }


    }
}

using Droni_Salvavita.Models;

namespace Droni_Salvavita.Services
{
    public class DroneService
    {
        private TimeSpan GetTimeSpan(DateTime DepartureDate, DateTime ArrivalDate) {
            TimeSpan FlightTime = ArrivalDate - DepartureDate;
            return FlightTime;
        }


    }
}

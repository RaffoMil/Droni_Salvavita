using Droni_Salvavita.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Droni_Salvavita.Controllers
{
    public class VoliController : ControllerBase
    {
        private static string FolderPath = AppDomain.CurrentDomain.BaseDirectory
                               + "..\\FileDB";




        [HttpGet()]

        public IActionResult GetVoli()
        {

            using (StreamReader sr = new StreamReader(FolderPath))
            {
                while (!sr.EndOfStream)
                {
                    string myJson = " ";
                    for (int i = 0; i < 18; i++)//da controllare la dimensione
                    {
                        myJson += sr.ReadLine();

                    }
                    SimpleVolo voli = JsonSerializer.Deserialize<SympleVolo>(myJson);

                    if (voli != null)
                    {
                        return Ok(voli);
                    }
                   


                }
                return BadRequest("flight dosen't exist");
            }


        }


        //        //Permettere di vedere il dettaglio di un volo 

        //        Voli/{IdVolo
        //    }

        //    GET

        //    Body
        //    {

        //        FlightId, 
        //			DepartureDate, 
        //		              ArrivalDate
        //            Drone
        //        {

        //            DroneId, 
        //    	FlightTime, 
        //	     PropulsionType(enum: Reaction, FixedWing, Helix), 
        //               PilotType(enum: Pilot, AI) 
        //} 

        [HttpGet(" Voli/{FlightId}")]
        public IActionResult GetVoliByid(int flightId)
        {

            using (StreamReader sr = new StreamReader(FolderPath))
            {
                while (!sr.EndOfStream)
                {
                    string myJson1 = " ";

                    for (int i = 0; i < 18; i++)
                    {
                        myJson1 += sr.ReadLine();
                    }
                     Volo volo = JsonSerializer.Deserialize<Volo>(myJson1);

                    if (volo.FlightId==flightId)
                    {
                        return Ok(volo);
                    }
                   
                        
                }
                return BadRequest("flight is not disponible");
            }

        }

    }




}




    


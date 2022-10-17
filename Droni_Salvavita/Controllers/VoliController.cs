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
              var lettura=  sr.ReadToEnd();
                List<Volo> listaVoli= JsonSerializer.Deserialize<List<Volo>>(lettura);
                List<SimpleVolo> listaSimple = new List<SimpleVolo>();

                foreach( var item in listaVoli)
                {
                    SimpleVolo volo = new SimpleVolo();
                    volo.ArrivalDate = item.ArrivalDate;
                    volo.DepartureDate = item.DepartureDate;
                    volo.FlightId = item.FlightId;

                    listaSimple.Add(volo);
                }

             

                while (!sr.EndOfStream)
                {
                    string myJson = " ";
                    for (int i = 0; i < listaSimple.Count; i++)//da controllare la dimensione
                    {
                        myJson += sr.ReadLine();

                    }
                    SimpleVolo voli = JsonSerializer.Deserialize<SimpleVolo>(myJson);

                    if (voli != null)
                    {
                        return Ok(listaSimple);
                    }
                   


                }
                return BadRequest("flight dosen't exist");
            }


        }


      

        [HttpGet(" Voli/{FlightId}")]
        public IActionResult GetVoliByid(int flightId)
        {

            using (StreamReader sr = new StreamReader(FolderPath))
            {
                var lettura = sr.ReadToEnd();
                List<Volo> listaVoli = JsonSerializer.Deserialize<List<Volo>>(lettura);

                foreach(var item in listaVoli)
                { 
                    Volo volo = new Volo();
                    volo.FlightId=item.FlightId;
                    volo.DepartureDate=item.DepartureDate;
                    volo.ArrivalDate=item.ArrivalDate;
                    volo.Drone= item.Drone;
                    listaVoli.Add(volo);
                    if (volo.FlightId == flightId)
                    {
                        return Ok(volo);
                    }
                }
                
                while (!sr.EndOfStream)
                {
                    string myJson1 = " ";

                    for (int i = 0; i < listaVoli.Count; i++)
                    {
                        myJson1 += sr.ReadLine();
                    }
                    
                }
                return BadRequest("flight is not disponible");
            }

        }

    }




}




    


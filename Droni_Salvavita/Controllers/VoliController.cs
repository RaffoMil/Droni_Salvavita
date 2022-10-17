using Droni_Salvavita.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace Droni_Salvavita.Controllers
{
    public class VoliController : ControllerBase
    {
        private static string _folderPath = AppDomain.CurrentDomain.BaseDirectory
                               + "..\\FileDB";

        [HttpPost("/voli")]
        public ActionResult<Volo> PostVoli([FromBody] Volo volo ) {
            string s = "";
            Volo voloSenzaDrone = volo;
            voloSenzaDrone.DepartureDate = DateTime.Now;
            voloSenzaDrone.ArrivalDate = DateTime.Now;
            // voloSenzaDrone.FlightId = default;
            voloSenzaDrone.Drone = null;
            if ( voloSenzaDrone is not null) {
                using (StreamReader st = new StreamReader(_folderPath)) {
                    while (!st.EndOfStream) {
                        string myJson = "";

                        for (int i = 0; i < 6; i++) {
                            myJson = st.ReadLine();
                        }

                        Volo voloJson = JsonSerializer.Deserialize<Volo>(myJson);
                        if (voloJson.FlightId == voloSenzaDrone.FlightId) {
                            return Conflict();
                        }
                    }

                    using (StreamReader reader = new StreamReader(_folderPath)) { 
                        s = reader.ReadToEnd();
                    }
                    using (StreamWriter sw = new StreamWriter(_folderPath)) {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        sw.WriteLine(s + JsonSerializer.Serialize(voloSenzaDrone, options));
                    }
                    return Ok();
                }
            }
            return BadRequest();
        }

    }
}

using Droni_Salvavita.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace Droni_Salvavita.Controllers
{
    public class VoliController : ControllerBase
    {
        private static string _folderPathVoli = AppDomain.CurrentDomain.BaseDirectory
                               + "..\\..\\..\\FileDB\\FileVoli.txt";
        

        [HttpPost("/voli")]
        public IActionResult PostVoli([FromBody] SimpleVolo volo ) {
            if (volo is not null) {
                System.IO.File.WriteAllText( _folderPathVoli, JsonConvert.SerializeObject(volo, Formatting.Indented));
                return Ok();
            } else {
                return BadRequest();
            } 
        }

    }
}

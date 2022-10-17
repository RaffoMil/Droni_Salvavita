using Microsoft.AspNetCore.Mvc;

namespace Droni_Salvavita.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {
        
        private static string FolderPath = AppDomain.CurrentDomain.BaseDirectory
                                       + "..\\FileDB";




    }
}

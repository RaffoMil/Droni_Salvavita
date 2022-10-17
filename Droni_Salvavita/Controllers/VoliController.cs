using Microsoft.AspNetCore.Mvc;

namespace Droni_Salvavita.Controllers
{
    public class VoliController : ControllerBase
    {
        private static string FolderPath = AppDomain.CurrentDomain.BaseDirectory
                               + "..\\FileDB";
    }
}

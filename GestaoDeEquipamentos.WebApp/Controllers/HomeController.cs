using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentoss.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

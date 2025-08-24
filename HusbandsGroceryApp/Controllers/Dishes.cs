using Microsoft.AspNetCore.Mvc;

namespace HusbandsGroceryApp.Controllers
{
    public class Dishes : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}

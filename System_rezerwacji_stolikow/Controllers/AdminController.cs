using Microsoft.AspNetCore.Mvc;

namespace System_rezerwacji_stolikow.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Admin") != "true")
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
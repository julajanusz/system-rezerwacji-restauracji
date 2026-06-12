using Microsoft.AspNetCore.Mvc;

namespace System_rezerwacji_stolikow.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            if (login == "admin" && password == "1234")
            {
                HttpContext.Session.SetString("Admin", "true");

                return RedirectToAction("Reservations", "Home");
            }

            ViewBag.Error = "Zły login lub hasło";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Index", "Login");
        }
    }
}
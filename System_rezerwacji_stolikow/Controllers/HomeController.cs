using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System_rezerwacji_stolikow.Models;
using System_rezerwacji_stolikow.Data;

namespace System_rezerwacji_stolikow.Controllers;

public class HomeController : Controller
{

    private readonly AppDbContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult About()
    {
        return View();
    }

    public IActionResult Reservation()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Reservations()
    {
        var reservations = _context.Reservations.ToList();
        return View(reservations);
    }

    public IActionResult Edit(int id)
    {
        var reservation = _context.Reservations.Find(id);

        if (reservation == null)
            return NotFound();

        return View(reservation);
    }

    [HttpPost]
    public IActionResult Edit(Reservation reservation)
    {
        if (!ModelState.IsValid)
            return View(reservation);

        _context.Reservations.Update(reservation);
        _context.SaveChanges();

        return RedirectToAction("Reservations");
    }

    public IActionResult Delete (int id)
    {
        var reservation = _context.Reservations.Find(id);

        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        return RedirectToAction("Reservations");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult Reservation(Reservation model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _context.Reservations.Add(model);
        _context.SaveChanges();

        return View("ReservationResult", model);
    }
}

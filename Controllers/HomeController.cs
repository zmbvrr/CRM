using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_CRM;

namespace TP_CRM.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
        CrmContext context = new CrmContext();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

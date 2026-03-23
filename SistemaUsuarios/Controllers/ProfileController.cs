using Microsoft.AspNetCore.Mvc;

namespace SistemaUsuarios.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

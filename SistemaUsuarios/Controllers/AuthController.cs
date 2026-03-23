using Microsoft.AspNetCore.Mvc;
using SistemaUsuarios.Models.ViewModels;
using SistemaUsuarios.Services;

namespace SistemaUsuarios.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;

    [HttpGet]
    public IActionResult Login(bool expired = false)
    {
        ViewData["IsSessionExpired"] = expired; 
        return View(); 
    }

    [HttpGet]
    public IActionResult Welcome()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var resultado = await _authService.ValidarLoginAsync(model.Usuario, model.Password);
        
        switch (resultado)
        {
            case LoginResult.Success:
                return RedirectToAction("Index", "Profile"); 

            case LoginResult.AccountLocked:
                return View("AccountLocked");

            case LoginResult.InvalidCredentials:
                ModelState.AddModelError("Usuario", "Usuario incorrecto");
                ModelState.AddModelError("Password", "Contraseña incorrecta");
                return View(model);

            default:
                return View(model);
        }
    }
}
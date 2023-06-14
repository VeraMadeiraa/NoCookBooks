using Microsoft.AspNetCore.Mvc;
using NoCookBooks.Domain.Entities;
using NoCookBooks.Models;
using NoCookBooks.Services.Implementations;
using NoCookBooks.Services.Interfaces;

namespace NoCookBooks.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.Authenticate(model.Email, model.Password);
                if (user != null)
                {
                    // Autenticado com sucesso
                    if (user.IsAdmin)
                    {
                        // Redirecionar para a página de administrador
                        return RedirectToAction("Admin", "Home");
                    }
                    else
                    {
                        // Redirecionar para a página do usuário comum
                        return RedirectToAction("User", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Credenciais inválidas. Por favor, tente novamente.");
                }
            }
            return View(model);

        }
    }
}

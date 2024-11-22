using test.Data;
using CMCS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class AccountController : Controller
{
   
    private readonly ApplicationDbContext _context; // Add this line

    public AccountController( ApplicationDbContext context) // Modify constructor
    {
     
        _context = context; // Initialize the context
    }

    // GET: /Account/Login
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        return RedirectToAction("Welcome", "Home"); // Redirect to Welcome

        return View(model);
    }
      
    }

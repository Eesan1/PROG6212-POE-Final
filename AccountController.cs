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
   
    private readonly ApplicationDbContext _context;

    public AccountController( ApplicationDbContext context)
    {
     
        _context = context; 
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        return RedirectToAction("Welcome", "Home"); 

        return View(model);
    }
      
    }

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;


public class ClaimsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClaimsController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public async Task<IActionResult> Index(string status = "Pending")
    {
        var claims = await _context.Claims
            .Where(c => c.Status == status)
            .ToListAsync();

        return View(claims);
    }

}

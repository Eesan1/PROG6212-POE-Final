using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using test.Models;
using test.Data;
using test.ViewModels; // Update to your actual namespace

public class HRController : Controller
{
    private readonly ApplicationDbContext _context;

    public HRController(ApplicationDbContext context)
    {
        _context = context;
    }

    // HR Dashboard - Display approved claims
    public IActionResult Index()
    {
        var users = _context.Users.ToList();


        // Fetch approved claims
        var approvedClaims = _context.Claims
            .Where(c => c.Status == "Approved")
            .ToList();

        // Calculate the total amount of approved claims
        var totalAmount = approvedClaims.Sum(c => c.TotalClaim);

        // Pass the data to the view
        ViewBag.TotalAmount = totalAmount;
        // return View(approvedClaims);


        var viewModel = new HRDashboardViewModel
        {
            ApprovedClaims = approvedClaims,
            Users = users
        };

        // Pass the ViewModel to the view
        return View(viewModel);


















    }

    // delete user

    [HttpPost]
    public IActionResult DeleteUser(int id)
    {
        // Fetch the user from the database
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        // Remove the user from the database
        _context.Users.Remove(user);
        _context.SaveChanges();

        // Redirect to the HR Dashboard after deletion
        return RedirectToAction("HRDashboard","Home");
    }



    // edit user
    [HttpGet]
    public IActionResult EditUser(int id)
    {
        // Fetch the user from the database
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        // Pass the user to the edit view
        return View("~/Views/Home/EditUser.cshtml", user);

    }

    // POST: Save the edited user data
    [HttpPost]
    public IActionResult EditUser(User updatedUser)
    {
        // Fetch the existing user from the database
        var user = _context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

        if (user == null)
        {
            return NotFound();
        }

        // Update the user details
        user.Name = updatedUser.Name;
        user.Role = updatedUser.Role;
        user.Number = updatedUser.Number;
        user.Username = updatedUser.Username;
        user.Password = updatedUser.Password; // Consider hashing passwords

        // Save the changes to the database
        _context.SaveChanges();

        // Redirect to the HR Dashboard after editing
        return RedirectToAction("HRDashboard","Home");
    }











    // Generate PDF Invoice
    [HttpGet]
    public IActionResult GenerateInvoice(int claimId)
    {
        var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);
        if (claim == null)
        {
            return NotFound();
        }

        // Create a PDF document
        MemoryStream memoryStream = new MemoryStream();
        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

        document.Open();

        // Add Invoice header
        document.Add(new Paragraph("Invoice"));
        document.Add(new Paragraph($"Invoice for Claim ID: {claim.ClaimId}"));
        document.Add(new Paragraph(" "));

        // Add claim details
        document.Add(new Paragraph($"Lecturer Name: {claim.LecturerName}"));
        document.Add(new Paragraph($"Hours Worked: {claim.HoursWorked}"));
        document.Add(new Paragraph($"Hourly Rate: R {claim.HourlyRate}"));
        document.Add(new Paragraph($"Total Claim: R {claim.TotalClaim}"));
        document.Add(new Paragraph($"Notes: {claim.Notes}"));
        document.Add(new Paragraph($"Status: {claim.Status}"));

        document.Close();
        byte[] bytes = memoryStream.ToArray();
        memoryStream.Close();

        return File(bytes, "application/pdf", $"Invoice_Claim_{claim.ClaimId}.pdf");
        // return View();
    }

	public IActionResult Users()
	{
		var users = _context.Users.ToList(); // Ensure you have a DbSet<User> in your ApplicationDbContext
		return View(users);
	}




}

using test.Models;

namespace test.ViewModels
{
    public class HRDashboardViewModel
    {
        public List<Claim> ApprovedClaims { get; set; }
        public List<User> Users { get; set; }
    }
}
namespace CMCS.Models
{
    public class RoleSelectionViewModel
    {
        public string SelectedRole { get; set; }
        public List<string> Roles { get; set; } = new List<string>
        {
            "Lecturer",
            "Academic Manager",
            "Programme Coordinator"
        };
    }
}
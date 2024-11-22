namespace test.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
		public string Number { get; set; }
		public string Username { get; set; }
		public string Password { get; set; } // Consider hashing passwords for security
	}
}
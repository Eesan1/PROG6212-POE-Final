using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Claim
    {
      

        [Key]
        [Column("claim_id")]
        public int ClaimId { get; set; }

        [Column("lecturer_name")]
        public string LecturerName { get; set; }

        [Column("hours_worked")]
        public double HoursWorked { get; set; }

        [Column("hourly_rate")]
        public double HourlyRate { get; set; }

        [Column("total_claim")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double TotalClaim { get; private set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("supporting_document")]
        public string? SupportingDocument { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
//using System.ComponentModel.DataAnnotations;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;



//namespace test.Models
//{
//    public class Claim
//    {
//        [Key]
//        public int ClaimId { get; set; }

//        [Required(ErrorMessage = "Lecturer Name is required")]
//        public string LecturerName { get; set; }

//        [Required(ErrorMessage = "Hours Worked is required")]
//        [Range(1, int.MaxValue, ErrorMessage = "Hours worked must be a positive number")]
//        public int HoursWorked { get; set; }

//        [Required(ErrorMessage = "Hourly Rate is required")]
//        [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be greater than zero")]
//        public decimal HourlyRate { get; set; }

//        public decimal TotalClaim { get; set; } // No validation required

//        public string Notes { get; set; } // Optional

//        public string SupportingDocument { get; set; } // Optional, no [Required]

//        public string Status { get; set; } // Optional, no [Required]

//        //public DateTime CreatedAt { get; set; } // Set automatically
//        [Column("created_at")]
//        public DateTime CreatedAt { get; set; }


//    }


//}
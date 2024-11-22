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

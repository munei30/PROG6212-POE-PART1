using System;

namespace MonthlyClaimSystemPrototype.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string LecturerName { get; set; } = string.Empty;  // prevent null warning
        public double HoursWorked { get; set; }                   // added
        public double HourlyRate { get; set; }                    // added
        public string Notes { get; set; } = string.Empty;         // added
        public string Description { get; set; } = string.Empty;   // keep for compatibility
        public decimal Amount { get; set; }
        public DateTime SubmissionDate { get; set; }
        public ClaimStatus Status { get; set; }
        public string DocumentPath { get; set; } = string.Empty;  // prevent null warning
    }
}

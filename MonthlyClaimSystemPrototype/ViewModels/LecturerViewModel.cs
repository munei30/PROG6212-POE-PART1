using System;
using System.Collections.ObjectModel;
using MonthlyClaimSystemPrototype.Models;
using MonthlyClaimSystemPrototype.Services;

namespace MonthlyClaimSystemPrototype.ViewModels

{
    public class LecturerViewModel
    {
        private readonly ClaimService _claimService;

        public ObservableCollection<Claim> Claims { get; set; }

        public LecturerViewModel()
        {
            _claimService = new ClaimService();
            Claims = new ObservableCollection<Claim>(_claimService.GetAll());
        }

        public void SubmitClaim(string lecturerName, double hoursWorked, double hourlyRate, string notes, string documentPath)
        {
            decimal totalAmount = (decimal)(hoursWorked * hourlyRate);

            var claim = new Claim
            {
                LecturerName = lecturerName,
                HoursWorked = hoursWorked,
                HourlyRate = hourlyRate,
                Notes = notes,
                Description = notes,
                Amount = totalAmount,
                SubmissionDate = DateTime.Now,
                DocumentPath = documentPath,
                Status = ClaimStatus.Pending
            };

            _claimService.AddClaim(claim);
            Claims.Add(claim);
        }
    }
}

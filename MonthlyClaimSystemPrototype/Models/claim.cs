using System;
using System.ComponentModel;

namespace MonthlyClaimSystemPrototype
{
    public class Claim : INotifyPropertyChanged
    {
        private int _claimID;
        public int ClaimID
        {
            get => _claimID;
            set { if (_claimID != value) { _claimID = value; OnPropertyChanged(nameof(ClaimID)); } }
        }

        private string? _month;
        public string? Month
        {
            get => _month;
            set { if (_month != value) { _month = value; OnPropertyChanged(nameof(Month)); } }
        }

        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set { if (_amount != value) { _amount = value; OnPropertyChanged(nameof(Amount)); } }
        }

        private string _status = "Submitted";
        public string Status
        {
            get => _status;
            set { if (_status != value) { _status = value; OnPropertyChanged(nameof(Status)); } }
        }

        private DateTime _submissionDate = DateTime.Now;
        public DateTime SubmissionDate
        {
            get => _submissionDate;
            set { if (_submissionDate != value) { _submissionDate = value; OnPropertyChanged(nameof(SubmissionDate)); } }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MonthlyClaimSystemPrototype
{
    public class LecturerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Claim> Claims { get; set; } = new();
        public Claim NewClaim { get; set; } = new();

        public ICommand SubmitCommand { get; set; }

        public LecturerViewModel()
        {
            SubmitCommand = new RelayCommand(_ => SubmitClaim());
        }

        private void SubmitClaim()
        {
            Claims.Add(new Claim
            {
                ClaimID = Claims.Count + 1,
                Month = NewClaim.Month,
                Amount = NewClaim.Amount,
                Status = "Submitted"
            });

            NewClaim = new Claim();
            OnPropertyChanged(nameof(NewClaim));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}


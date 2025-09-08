
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MonthlyClaimSystemPrototype.Models;

namespace MonthlyClaimSystemPrototype
{
    public partial class CoordinatorWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Claim> Claims { get; }

        private Claim? _selectedClaim;
        public Claim? SelectedClaim
        {
            get => _selectedClaim;
            set
            {
                _selectedClaim = value;
                OnPropertyChanged(nameof(SelectedClaim));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand ApproveCommand { get; }
        public ICommand RejectCommand { get; }

        public CoordinatorWindow(ObservableCollection<Claim> claims)
        {
            InitializeComponent();

            Claims = claims;

            ApproveCommand = new RelayCommand(param =>
            {
                var claim = param as Claim ?? SelectedClaim;
                if (claim != null) claim.Status = "Approved";
            }, param => (param as Claim) != null || SelectedClaim != null);

            RejectCommand = new RelayCommand(param =>
            {
                var claim = param as Claim ?? SelectedClaim;
                if (claim != null) claim.Status = "Rejected";
            }, param => (param as Claim) != null || SelectedClaim != null);

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

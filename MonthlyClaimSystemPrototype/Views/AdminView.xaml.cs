using System.Collections.ObjectModel;
using System.Windows;
using MonthlyClaimSystemPrototype.Models;
using MonthlyClaimSystemPrototype.Services;

namespace MonthlyClaimSystemPrototype
{
    public partial class AdminView : Window
    {
        private readonly ObservableCollection<Claim> _claims;
        private readonly ClaimService _claimService;

        public AdminView(ObservableCollection<Claim> claims)
        {
            InitializeComponent();
            _claims = claims;
            _claimService = new ClaimService();

            dgClaims.ItemsSource = _claims;
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (dgClaims.SelectedItem is Claim claim)
            {
                claim.Status = ClaimStatus.Approved;
                dgClaims.Items.Refresh();
                MessageBox.Show("✅ Claim approved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a claim first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            if (dgClaims.SelectedItem is Claim claim)
            {
                claim.Status = ClaimStatus.Rejected;
                dgClaims.Items.Refresh();
                MessageBox.Show("🚫 Claim rejected.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a claim first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

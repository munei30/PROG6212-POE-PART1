using System.Collections.ObjectModel;
using System.Windows;
using MonthlyClaimSystemPrototype.Models; // ✅ Add this line

namespace MonthlyClaimSystemPrototype
{
    public partial class CoordinatorWindow : Window
    {
        private ObservableCollection<Claim> claims;

        public CoordinatorWindow(ObservableCollection<Claim> sharedClaims)
        {
            InitializeComponent();
            claims = sharedClaims;
            dgClaims.ItemsSource = claims;
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (dgClaims.SelectedItem is Claim selectedClaim)
                selectedClaim.Status = ClaimStatus.Approved; // ✅ Use enum instead of string
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            if (dgClaims.SelectedItem is Claim selectedClaim)
                selectedClaim.Status = ClaimStatus.Rejected; // ✅ Use enum instead of string
        }

        private void dgClaims_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}

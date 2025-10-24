using System.Text;
using System.Windows;
using MonthlyClaimSystemPrototype.ViewModels;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonthlyClaimSystemPrototype
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LecturerViewModel();
        }

        // This is the click handler for the "Coordinator Dashboard" button
        private void OpenCoordinator_Click(object sender, RoutedEventArgs e)
        {
            // Make sure the DataContext is a LecturerViewModel
            if (DataContext is LecturerViewModel vm)
            {
                // Create a CoordinatorWindow and pass the shared Claims collection
                var coordinatorWindow = new CoordinatorWindow(vm.Claims)
                {
                    Owner = this // Optional: sets MainWindow as the owner
                };

                coordinatorWindow.Show(); // Show the coordinator window
            }
        }
    }
}

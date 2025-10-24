using System;
using System.Windows;
using Microsoft.Win32;
using MonthlyClaimSystemPrototype.Models;
using MonthlyClaimSystemPrototype.Services;
using MonthlyClaimSystemPrototype.ViewModels;

namespace MonthlyClaimSystemPrototype
{
    public partial class LecturerView : Window
    {
        private readonly LecturerViewModel _viewModel;
        private readonly ClaimService _claimService;
        private string _filePath = string.Empty;

        public LecturerView()
        {
            InitializeComponent();
            _viewModel = new LecturerViewModel();
            _claimService = new ClaimService();
            DataContext = _viewModel;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Documents (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                lblFileName.Content = System.IO.Path.GetFileName(_filePath); // ✅ use Content instead of Text
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Collect input values
                string lecturer = txtLecturer.Text;
                double hours = double.Parse(txtHours.Text);
                double rate = double.Parse(txtRate.Text);
                string notes = txtNotes.Text;

                // Create new claim
                Claim newClaim = new Claim
                {
                    ClaimID = _claimService.GetAll().Count + 1,
                    LecturerName = lecturer,
                    HoursWorked = hours,
                    HourlyRate = rate,
                    Notes = notes,
                    DocumentPath = _filePath,
                    Status = ClaimStatus.Pending, // ✅ use enum
                    SubmissionDate = DateTime.Now
                };

                _claimService.AddClaim(newClaim);
                _viewModel.Claims.Add(newClaim);

                lblStatus.Content = "✅ Claim submitted successfully!";
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error submitting claim: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm()
        {
            txtLecturer.Text = "";
            txtHours.Text = "";
            txtRate.Text = "";
            txtNotes.Text = "";
            lblFileName.Content = "No file selected";
            lblStatus.Content = "";
            _filePath = string.Empty;
        }
    }
}

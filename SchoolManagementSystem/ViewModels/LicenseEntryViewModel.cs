using SchoolManagementSystem.Services;
using SchoolManagementSystem.Views;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    public class LicenseEntryViewModel : BaseViewModel
    {
        private readonly LicenseService _licenseService;
        private string _licenseKey;

        public string LicenseKey
        {
            get => _licenseKey;
            set
            {
                _licenseKey = value;
                OnPropertyChanged();
            }
        }

        public ICommand ActivateLicenseCommand { get; }

        public LicenseEntryViewModel(LicenseService licenseService)
        {
            _licenseService = licenseService;
            ActivateLicenseCommand = new Command(async () => await OnActivateLicense());
        }

        private async Task OnActivateLicense()
        {
            if (string.IsNullOrWhiteSpace(LicenseKey))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please enter a license key.", "OK");
                return;
            }

            bool isValid = await _licenseService.ValidateLicenseAsync(LicenseKey);

            if (isValid)
            {
                await App.Current.MainPage.DisplayAlert("Success", "License activated successfully.", "OK");
                // Navigate to the login page
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid license key. Please try again.", "OK");
            }
        }
    }
}

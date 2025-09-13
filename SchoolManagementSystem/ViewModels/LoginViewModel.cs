using SchoolManagementSystem.Services;
using SchoolManagementSystem.Views;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthenticationService _authService;
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AuthenticationService authService)
        {
            _authService = authService;
            LoginCommand = new Command(async () => await OnLogin());
        }

        private async Task OnLogin()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please enter username and password.", "OK");
                return;
            }

            var result = await _authService.LoginAsync(Username, Password);

            if (result != null)
            {
                // Navigate to the main app interface (the TabBar)
                await Shell.Current.GoToAsync("//");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }
    }
}

using SchoolManagementSystem.Services;
using SchoolManagementSystem.ViewModels;
using SchoolManagementSystem.Views;
using System.Windows.Input;

namespace SchoolManagementSystem;

public partial class AppShell : Shell
{
	private readonly LicenseService _licenseService;
    public ChatPanelViewModel ChatViewModel { get; }

	public AppShell(LicenseService licenseService, ChatPanelViewModel chatViewModel)
	{
		InitializeComponent();
		_licenseService = licenseService;
        ChatViewModel = chatViewModel;

		// Register routes
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(ManagementSetupPage), typeof(ManagementSetupPage));
		Routing.RegisterRoute(nameof(LicenseEntryPage), typeof(LicenseEntryPage));
		Routing.RegisterRoute(nameof(StudentListPage), typeof(StudentListPage));
		Routing.RegisterRoute(nameof(AdminDashboardPage), typeof(AdminDashboardPage));
		Routing.RegisterRoute(nameof(FinanceDashboardPage), typeof(FinanceDashboardPage));

		BindingContext = this;
		CheckLicense();
	}

	private async void CheckLicense()
	{
		bool isValid = await _licenseService.IsLicenseValidAsync();
		if (!isValid)
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				await Current.GoToAsync($"//{nameof(LicenseEntryPage)}");
			});
		}
        else
        {
            MainThread.BeginInvokeOnMainThread(async () =>
			{
				await Current.GoToAsync($"//{nameof(LoginPage)}");
			});
        }
	}
}

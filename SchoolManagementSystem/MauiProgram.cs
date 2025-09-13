using SchoolManagementSystem.Services;
using SchoolManagementSystem.ViewModels;
using SchoolManagementSystem.Views;

namespace SchoolManagementSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Core Services
		builder.Services.AddSingleton<DatabaseService>();
		builder.Services.AddSingleton<LicenseService>();
		builder.Services.AddSingleton<AuthenticationService>();
		builder.Services.AddSingleton<StudentService>();
		builder.Services.AddSingleton<FinanceService>();
		builder.Services.AddSingleton<AIService>();

		// App Shell
		builder.Services.AddSingleton<AppShell>();

		// Views and ViewModels
		builder.Services.AddTransient<ManagementSetupViewModel>();
		builder.Services.AddTransient<ManagementSetupPage>();

		builder.Services.AddTransient<LicenseEntryViewModel>();
		builder.Services.AddTransient<LicenseEntryPage>();

		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<LoginPage>();

		builder.Services.AddTransient<StudentListViewModel>();
		builder.Services.AddTransient<StudentListPage>();

		builder.Services.AddTransient<AdminDashboardViewModel>();
		builder.Services.AddTransient<AdminDashboardPage>();

		builder.Services.AddTransient<ChatPanelViewModel>();
		builder.Services.AddTransient<ChatPanelView>();

		builder.Services.AddTransient<FinanceDashboardViewModel>();
		builder.Services.AddTransient<FinanceDashboardPage>();

		return builder.Build();
	}
}

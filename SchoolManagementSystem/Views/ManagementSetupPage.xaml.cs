using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Views;

public partial class ManagementSetupPage : ContentPage
{
	public ManagementSetupPage(ManagementSetupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

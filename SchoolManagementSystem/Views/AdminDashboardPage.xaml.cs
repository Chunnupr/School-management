using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Views
{
    public partial class AdminDashboardPage : ContentPage
    {
        public AdminDashboardPage(AdminDashboardViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

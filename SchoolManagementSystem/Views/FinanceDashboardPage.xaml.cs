using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Views
{
    public partial class FinanceDashboardPage : ContentPage
    {
        public FinanceDashboardPage(FinanceDashboardViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

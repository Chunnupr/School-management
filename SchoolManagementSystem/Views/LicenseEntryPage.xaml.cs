using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Views
{
    public partial class LicenseEntryPage : ContentPage
    {
        public LicenseEntryPage(LicenseEntryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    public class AdminDashboardViewModel : BaseViewModel
    {
        public ICommand ExportDataCommand { get; }
        public ICommand ImportDataCommand { get; }
        public ICommand ViewFinancialReportCommand { get; }

        public AdminDashboardViewModel()
        {
            ExportDataCommand = new Command(async () => await OnExportData());
            ImportDataCommand = new Command(async () => await OnImportData());
            ViewFinancialReportCommand = new Command(async () => await OnViewFinancialReport());
        }

        private async Task OnExportData()
        {
            await App.Current.MainPage.DisplayAlert("Not Implemented", "Export functionality is not yet implemented.", "OK");
        }

        private async Task OnImportData()
        {
            await App.Current.MainPage.DisplayAlert("Not Implemented", "Import functionality is not yet implemented.", "OK");
        }

        private async Task OnViewFinancialReport()
        {
            await App.Current.MainPage.DisplayAlert("Not Implemented", "Financial report functionality is not yet implemented.", "OK");
        }
    }
}

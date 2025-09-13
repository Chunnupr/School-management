using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Views
{
    public partial class StudentListPage : ContentPage
    {
        public StudentListPage(StudentListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as StudentListViewModel)?.LoadStudentsCommand.Execute(null);
        }
    }
}

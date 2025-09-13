using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using SchoolManagementSystem.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentListViewModel : BaseViewModel
    {
        private readonly StudentService _studentService;
        public ObservableCollection<Student> Students { get; } = new();

        public ICommand LoadStudentsCommand { get; }
        public ICommand AddStudentCommand { get; }

        public StudentListViewModel(StudentService studentService)
        {
            _studentService = studentService;
            LoadStudentsCommand = new Command(async () => await ExecuteLoadStudentsCommand());
            AddStudentCommand = new Command(async () => await OnAddStudent());
        }

        private async Task ExecuteLoadStudentsCommand()
        {
            Students.Clear();
            var students = await _studentService.GetStudentsAsync();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }

        private async Task OnAddStudent()
        {
            // This page doesn't exist yet, but we'll navigate to it.
            // await Shell.Current.GoToAsync(nameof(AddStudentPage));
            await App.Current.MainPage.DisplayAlert("Not Implemented", "The 'Add Student' page has not been implemented yet.", "OK");
        }
    }
}

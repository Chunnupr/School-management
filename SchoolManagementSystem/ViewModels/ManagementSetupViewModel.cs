using SchoolManagementSystem.Services;
using SchoolManagementSystem.Views;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    public class ManagementSetupViewModel : BaseViewModel
    {
        private readonly DatabaseService _dbService;
        private string _schoolName;
        private ImageSource _logoImageSource;
        private byte[] _logoData;

        public string SchoolName
        {
            get => _schoolName;
            set
            {
                _schoolName = value;
                OnPropertyChanged();
            }
        }

        public ImageSource LogoImageSource
        {
            get => _logoImageSource;
            set
            {
                _logoImageSource = value;
                OnPropertyChanged();
            }
        }

        public ICommand UploadLogoCommand { get; }
        public ICommand SaveSetupCommand { get; }
        public ICommand NavigateToStudentListCommand { get; }

        public ManagementSetupViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
            UploadLogoCommand = new Command(async () => await OnUploadLogo());
            SaveSetupCommand = new Command(async () => await OnSaveSetup());
            NavigateToStudentListCommand = new Command(async () => await OnNavigateToStudentList());
        }

        private async Task OnUploadLogo()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select a logo",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    _logoData = memoryStream.ToArray();
                }

                LogoImageSource = ImageSource.FromStream(() => new System.IO.MemoryStream(_logoData));
            }
        }

        private async Task OnSaveSetup()
        {
            if (string.IsNullOrWhiteSpace(SchoolName) || _logoData == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please provide a school name and a logo.", "OK");
                return;
            }

            var schoolInfo = new Models.SchoolInfo
            {
                Name = SchoolName,
                Logo = _logoData
            };

            var conn = _dbService.GetConnection();
            await conn.InsertAsync(schoolInfo);

            await App.Current.MainPage.DisplayAlert("Success", "School information saved.", "OK");
        }

        private async Task OnNavigateToStudentList()
        {
            await Shell.Current.GoToAsync(nameof(StudentListPage));
        }
    }
}

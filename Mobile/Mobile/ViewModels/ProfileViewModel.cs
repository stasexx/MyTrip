using Mobile.MobileServices;
using Mobile.Models;
using Mobile.Views;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {

        private User user;

        public ICommand NavToMainCommand { get; private set; }
        public ICommand ChangePasswordCommand { get; private set; }
        public ICommand ChangePhoneCommand { get; private set; }
        public ICommand ChangeUsernameCommand { get; private set; }
        public ICommand ChangeEmailCommand { get; private set; }
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private double levelProgress;

        public double LevelProgress
        {
            get { return levelProgress; }
            set
            {
                if (levelProgress != value)
                {
                    levelProgress = value;
                    OnPropertyChanged(nameof(LevelProgress));
                }
            }
        }

        private UserService userService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfileViewModel()
        {
            userService = new UserService();
            NavToMainCommand = new Command(NavToMain);
            ChangePasswordCommand = new Command(ChangePassword);
            ChangePhoneCommand = new Command(ChangePhone);
            ChangeUsernameCommand = new Command(ChangeUsername);
            ChangeEmailCommand = new Command(ChangeEmail);

            
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void NavToMain()
        {
            App.Current.MainPage = new MainFlyout();
        }

        private async void ChangePassword()
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Password Change", "Write new password");
            if (result == null)
            {
                return;
            }
            if (result == "")
            {
                Application.Current.MainPage.DisplayAlert("Error", "Password cannot be empty", "OK");
            }
            else
            {
                ChangePassApi(result);
                await GetUser();
                Application.Current.MainPage.DisplayAlert("Success", "Password changed successfully", "OK");
            }
        }
        private async void ChangePhone()
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Phone Change", "Write new phone number");
            if (result == null)
            {
                return;
            }
            if (result == "")
            {
                Application.Current.MainPage.DisplayAlert("Error", "Phone number cannot be empty", "OK");
            }
            else
            {
                if (ValidatePhoneNumber(result))
                {
                    ChangePhone(result);
                    await GetUser();
                    Application.Current.MainPage.DisplayAlert("Success", "Password changed successfully", "OK");

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error", "Check your phone number", "OK");
                }
            }
        }
        private async void ChangeUsername()
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Username Change", "Write new username");
            if(result == null)
            {
                return;
            }
            if (result == "")
            {
                Application.Current.MainPage.DisplayAlert("Error", "Username cannot be empty", "OK");
            }
            else
            {
                ChangeUsername(result);
                await GetUser();
                Application.Current.MainPage.DisplayAlert("Success", "Username changed successfully", "OK");

            }
        }

        private async void ChangeEmail()
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Email Change", "Write new email");
            if (result == null)
            {
                return;
            }
            if (result == "")
            {
                Application.Current.MainPage.DisplayAlert("Error", "Email cannot be empty", "OK");
            }
            else
            {
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

                if (Regex.IsMatch(result, pattern))
                {
                    ChangeEmail(result);
                    await GetUser();
                    Application.Current.MainPage.DisplayAlert("Success", "Email changed successfully", "OK");

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error", "Wrong email format", "OK");
                }

            }
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
            { 
                return false;
            }

            int minLength = 5; 
            int maxLength = 15; 

            if (phoneNumber.Length < minLength || phoneNumber.Length > maxLength)
            {
                return false;
            }

            return true;
        }

        public async Task GetUser()
        {
            User result = await userService.GetUser(AppUser.Email);
            User = result;
            LevelProgress = (double)(User.Expirience % 100) / 100;
        }
        public async Task ChangePassApi(string newPasword)
        {
            userService.ChangePassword(AppUser.Email, newPasword, User.Password);
        }
        public async Task ChangePhone(string newPhone)
        {
            userService.ChangePhone(AppUser.Email, newPhone);
        }
        public async Task ChangeUsername(string newUsername)
        {
            userService.ChangeUsername(AppUser.Email, newUsername);
        }
        public async Task ChangeEmail(string newEmail)
        {
            userService.ChangeEmail(AppUser.Email, User.Password, newEmail);
            AppUser.Email = newEmail;
        }
    }
}
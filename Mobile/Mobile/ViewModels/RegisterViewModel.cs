using Mobile.MobileServices;
using Mobile.Models;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        UserService userService = new UserService();

        public ICommand RegisterCommand { get; private set; }
        public ICommand SignInButtonCommand { get; private set; }

        public Login login { get; set; }

        public RegisterViewModel()
        {
            login = new Login();

            RegisterCommand = new Command(Register);
            SignInButtonCommand = new Command(NavToSignIn);
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void NavToSignIn()
        {
            App.Current.MainPage = new SignIn();
        }

        private async void Register()
        {
            string email = login.Email;
            string password = login.Password;
            string confirmPassword = login.ConfirmPassword;
            string firstName = login.FirstName;
            string lastName = login.LastName;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
            }
            catch (FormatException)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid email address", "OK");
                return;
            }


            if (password != confirmPassword)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }
            await RegUser(email, password, firstName, lastName);
        }

        public async Task RegUser(string email, string password, string firstName, string lastName)
        {
            IEnumerable<User> tours = await userService.RegUser(email, password, firstName, lastName);
            AppUser.Email = email;
            App.Current.MainPage = new MainFlyout();
        }

    }
}

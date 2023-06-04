using Mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using Mobile.MobileServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Mobile.Views;

namespace Mobile.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        UserService userService = new UserService();
        private User User { get; set; }

        private Color emailFieldColor;
        public Color EmailFieldColor
        {
            get { return emailFieldColor; }
            set
            {
                emailFieldColor = value;
                OnPropertyChanged(nameof(EmailFieldColor));
            }
        }

        private Color passwordFieldColor;
        public Color PasswordFieldColor
        {
            get { return passwordFieldColor; }
            set
            {
                passwordFieldColor = value;
                OnPropertyChanged(nameof(PasswordFieldColor));
            }
        }

        public Login login { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get; private set; }
        public ICommand SignUpButtonCommand { get; private set; }


        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public SignInViewModel()
        {
            login = new Login();
            

            LoginCommand = new Command(Login);
            SignUpButtonCommand = new Command(SignUpButton);

            EmailFieldColor = Color.White;
            PasswordFieldColor = Color.White;
        }

        private void SignUpButton()
        {
            App.Current.MainPage = new Register();
        }


        private async void Login()
        {
            EmailFieldColor = Color.White;
            PasswordFieldColor = Color.White;

            string email = login.Email;
            string password = login.Password;

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            bool flagEmail = true;
            bool flagPassword = true;

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, pattern))
            {
                EmailFieldColor = Color.FromHex("#FFC7C7");
                flagEmail = false;
            }
            if (string.IsNullOrEmpty(password)) {

                PasswordFieldColor = Color.FromHex("#FFC7C7");
                flagPassword = false;
            }
            if(flagPassword && flagEmail)
            {
               await GetUserByEmail(email);
                if (User == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password", "OK");
                }
                else
                {
                    if (User.Email == email && User.Password == password)
                    {
                        AppUser.Email = email;
                        App.Current.MainPage = new MainFlyout();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password", "OK");
                    }
                }
            }
        }

        public async Task GetUserByEmail(string email)
        {
            User = new User();
            User = await userService.GetUser(email);
        }
    }
}

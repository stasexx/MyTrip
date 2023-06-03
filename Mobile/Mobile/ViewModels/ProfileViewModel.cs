using Mobile.MobileServices;
using Mobile.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private bool initialized = false;
        private bool isBusy;
        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private UserService userService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfileViewModel()
        {
            userService = new UserService();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public async Task GetUser()
        {
            if (initialized)
                return;

            isBusy = true;

            User result = await userService.GetUser();
            User = result;

            isBusy = false;
            initialized = true;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Models;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Отправьте запрос на веб API для аутентификации
            HttpClient client = new HttpClient();
            string apiUrl = "http://localhost:5000/Users/api/checkForEmail?email=somebody@gmail.com"; // Замените на URL вашего веб API

            // Определите HTTP заголовки или параметры, необходимые для вашего веб API
            // Например, если ваш API ожидает данные в формате JSON, вы можете установить соответствующий заголовок
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Создайте объект для отправки на сервер
            var loginData = new { Email = email, Password = password };
            string loginJson = JsonConvert.SerializeObject(loginData);

            // Отправьте POST-запрос на сервер с данными для аутентификации
            HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(loginJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                // Вход выполнен успешно
                // Получите ответ от веб API и десериализуйте его
                string apiResponse = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(apiResponse);

                // Доступ к данным пользователя
                int userId = user.UserId;
                string firstName = user.FirstName;
                // и т.д.

                // Перенаправьте пользователя на следующий экран или предоставьте доступ к функциональности приложения
                // ...
                await Navigation.PushAsync(new Profile());
            }
            else
            {
                // Вход не удался
                // Обработайте ошибку аутентификации здесь
                // ...
                await DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }
    }
}
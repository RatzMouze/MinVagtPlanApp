using Flurl.Http;
using MinVagtPlanDK.Models;
using MinVagtPlanDK.Services;
using MinVagtPlanDK.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinVagtPlanDK.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string LoginStatus
        {
            get { return loginStatus; }
            set
            {
                if (loginStatus == value)
                    return;
                loginStatus = value;
                OnPropertyChanged();
            }
        }
        public string Email {
            get { return email; }
            set {
                if (email == value)
                    return;
                email = value;
                OnPropertyChanged();
            } 
        }
        public string Password { 
            get { return password; } 
            set {
                if (password == value)
                    return;
                password = value;
                OnPropertyChanged();
            } 
        }
        public string loginStatus = string.Empty;
        public string password = string.Empty;
        public string email = string.Empty;
        public Command LoginCommand { get; }

        public LoginViewModel()
        {

            LoginCommand = new Command(OnLoginClicked);
            if (Authenticator.GetAuthKey() != null)
            {
                Shell.Current.GoToAsync($"//{nameof(SchedulePage)}");
            }
        }

        private async void OnLoginClicked(object obj)
        {

            var response = "https://api.minsmartevagtplan.dk/api/login".WithHeader("Accept", "application/json").WithHeader("Content-Type", "application/json").AllowAnyHttpStatus().PostJsonAsync(new { email = Email, password = Password }).ReceiveString();
            var result = JsonConvert.DeserializeObject<LoginResult>(response.Result);
            if (result.success)
            {
                Authenticator.SetAuthKey(result.data.token);
                Shell.Current.GoToAsync($"//{nameof(SchedulePage)}");
            }
            else if (!result.success)
            {
                Password = string.Empty;
                LoginStatus = result.message;
            }
        }
    }
}

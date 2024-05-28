using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Utils;
using VolunteerVerseMobile.Views;

namespace VolunteerVerseMobile.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _emailAddress;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _error;

        private readonly IAuthorizationApiService _authorizationApiService;

        private readonly IConnectivity _connectivity;


        public LoginViewModel(IAuthorizationApiService authorizationApiService, IConnectivity connectivity)
        {
            _authorizationApiService = authorizationApiService;

            _connectivity = connectivity;
        }

        [RelayCommand]
        public async Task Login()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");

                return;

            }


            if (string.IsNullOrWhiteSpace(EmailAddress) || string.IsNullOrWhiteSpace(Password))
            {
                return;
            }

            Error = string.Empty;

            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                LoginResponseDTO result = await _authorizationApiService.LoginAsync(EmailAddress, Password);

                AccountContext.Email = result.Email;
                AccountContext.PictureUri = result.ProfilePictureUri;
                AccountContext.FirstName = result.FirstName;
                AccountContext.LastName = result.LastName;
                AccountContext.Token = result.Token;

                await Shell.Current.GoToAsync("//main/EventListPage", true);

                await Shell.Current.Navigation.PopToRootAsync();

            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }


        }

        [RelayCommand]
        public async Task ContinueWithoutLogin()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");

                return;

            }

            AccountContext.Email = string.Empty;
            AccountContext.PictureUri = string.Empty;
            AccountContext.FirstName = string.Empty;
            AccountContext.LastName = string.Empty;
            AccountContext.Token = string.Empty;

            //await Shell.Current.GoToAsync($"{nameof(EventListPage)}", true);
            await Shell.Current.GoToAsync("//main/EventListPage", true);

            await Shell.Current.Navigation.PopToRootAsync();
        }

        [RelayCommand]
        public async Task GoToSignupPage()
        {
            await Shell.Current.GoToAsync("SignupPage");
        }




        public override Task OnAppearing()
        {
            return Task.CompletedTask;
        }
    }
}

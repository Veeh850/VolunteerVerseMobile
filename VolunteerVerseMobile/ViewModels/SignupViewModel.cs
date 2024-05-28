using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.ViewModels
{
    public partial class SignupViewModel : BaseViewModel
    {
        [ObservableProperty]
        private SignupDTO signupModel = new SignupDTO();

        private readonly IAuthorizationApiService _authorizationApiService;

        private readonly IConnectivity _connectivity;

        [ObservableProperty]
        private string _error;

        [ObservableProperty]
        private string _confirmPassword;

        public SignupViewModel(IAuthorizationApiService authorizationApiService, IConnectivity connectivity)
        {
            _authorizationApiService = authorizationApiService;
            _connectivity = connectivity;

        }

        [RelayCommand]
        public async Task Signup()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");

                return;
            }

            if (string.IsNullOrEmpty(SignupModel.FirstName) || string.IsNullOrEmpty(SignupModel.LastName) || 
                string.IsNullOrEmpty(SignupModel.Email) || string.IsNullOrEmpty(SignupModel.Phone) || 
                string.IsNullOrEmpty(SignupModel.Password) || string.IsNullOrEmpty(ConfirmPassword) ||
                SignupModel.Password != ConfirmPassword)
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

                LoginResponseDTO result = await _authorizationApiService.SignupAsync(SignupModel);

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


        public override Task OnAppearing()
        {
            return Task.CompletedTask;
        }
    }
}

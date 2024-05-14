using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Models.Account;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        [ObservableProperty]
        private AccountDetails _accountDetails;

        private readonly IAccountApiService _accountApiService;

        public ProfileViewModel(IAccountApiService accountApiService)
        {
            AccountDetails = new AccountDetails();

            _accountApiService = accountApiService;

            AccountContext.Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSmFub3MiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdXJuYW1lIjoiS2lzcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Imtpc3NqYW5vc0B5YWhvby5jb20iLCJleHAiOjE3MTU3OTY2ODl9.ZbHKxxvZ2E-67AiMN74yx_MskUOVloutU2WvNEhfiaP1zNN9lroH4xZP89Z5qoez-5WxanS-JQm9M8o-yKvojg";
        }

        [RelayCommand]
        public async Task LoadAccountDetails()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                AccountDetails = await _accountApiService.GetOwnAccountDetails();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        public override async Task OnAppearing()
        {
            await LoadAccountDetails();
        }
    }
}

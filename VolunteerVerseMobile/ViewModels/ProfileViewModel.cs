﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Models.Account;
using VolunteerVerseMobile.Utils;
using VolunteerVerseMobile.Views;

namespace VolunteerVerseMobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        [ObservableProperty]
        private AccountDetails _accountDetails;

        private readonly IAccountApiService _accountApiService;

        public ObservableCollection<ProfileEvent> ProfileEvents { get; } = new ObservableCollection<ProfileEvent>();

        public ProfileViewModel(IAccountApiService accountApiService)
        {
            AccountDetails = new AccountDetails();
            _accountApiService = accountApiService;
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

        [RelayCommand]
        public async Task LoadProfileEvents()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;

                var profileEvents = await _accountApiService.GetProfileEvents();

                if (ProfileEvents.Count != 0)
                {
                    ProfileEvents.Clear();
                }

                foreach (var item in profileEvents)
                {
                    ProfileEvents.Add(item);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Error");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task GoToDetails(int id)
        {
            await Shell.Current.GoToAsync(nameof(EventDetailsPage), true, new Dictionary<string, object>
            {
                {"eventId" , id}
            });
        }

        public override async Task OnAppearing()
        {
            await LoadAccountDetails();
            await LoadProfileEvents();
        }
    }
}
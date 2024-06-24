using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.ViewModels
{
    [QueryProperty(nameof(OrganizationId), "organizationId")]
    public partial class OrganizationDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private OrganizationDetails _organizationDetails;

        [ObservableProperty]
        private int _organizationId;

        private readonly IOrganizationApiService _organizationApiService;

        public OrganizationDetailsViewModel(IOrganizationApiService organizationApiService)
        {
            OrganizationDetails = new OrganizationDetails();

            _organizationApiService = organizationApiService;
        }

        [RelayCommand]
        public async Task LoadOrganizationDetails()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                OrganizationDetails = await _organizationApiService.GetOrganizationDetailsById(OrganizationId);
            }
            catch (Exception)
            {
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task LeaveButtonClicked()
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to leave this organization?", "Yes", "No");
            
            if (confirm)
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    if(OrganizationDetails.OrganizationUsers.Count == 1)
                    {
                        await _organizationApiService.DeleteOrganization(OrganizationId);
                    }
                    else
                    {
                        await _organizationApiService.LeaveOrganization(OrganizationId);

                    }

                    await Shell.Current.Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        [RelayCommand]
        public async Task DeleteButtonClicked()
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this organization?", "Yes", "No");
            
            if (confirm)
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    await _organizationApiService.DeleteOrganization(OrganizationId);

                    await Shell.Current.Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }


        [RelayCommand]
        public async Task AddMemberButtonClicked()
        {
            string email = await Shell.Current.DisplayPromptAsync("Add Member", "Enter email address:");


            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                await _organizationApiService.AddOrganizationMember(OrganizationId, email);

                OrganizationDetails = await _organizationApiService.GetOrganizationDetailsById(OrganizationId);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        public override async Task OnAppearing()
        {
            await LoadOrganizationDetails();
        }
    }
}

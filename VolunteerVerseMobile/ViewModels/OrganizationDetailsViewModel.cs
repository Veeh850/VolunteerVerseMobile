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

        [ObservableProperty]
        private bool _isAddMemberModalVisible;

        [ObservableProperty]
        private string _newMemberEmail;

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
            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to leave this organization?", "Yes", "No");
            
            if (confirm)
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;
                    await _organizationApiService.LeaveOrganization(OrganizationId);

                    OrganizationDetails = await _organizationApiService.GetOrganizationDetailsById(OrganizationId);
                    
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception ex)
                {
                    
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
            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to delete this organization?", "Yes", "No");
            
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

                    OrganizationDetails = await _organizationApiService.GetOrganizationDetailsById(OrganizationId);

                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
        [RelayCommand]
        private void ShowAddMemberModal()
        {
            IsAddMemberModalVisible = true;
        }

        [RelayCommand]
        private void HideAddMemberModal()
        {
            IsAddMemberModalVisible = false;
        }


        [RelayCommand]
        public async Task AddMemberButtonClicked()
        {

            string email = await Application.Current.MainPage.DisplayPromptAsync("Add Member", "Enter email address:");

            if (string.IsNullOrWhiteSpace(email))
            {
                // Handle invalid email address
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
                await LoadOrganizationDetails();
            }
            catch (Exception ex)
            {

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

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

        public override async Task OnAppearing()
        {
            await LoadOrganizationDetails();
        }
    }
}

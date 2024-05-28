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
using VolunteerVerseMobile.Views;

namespace VolunteerVerseMobile.ViewModels
{
    public partial class OrganizationListViewModel : BaseViewModel
    {
        public ObservableCollection<OrganizationPreview> OrganizationPreviews { get; } = new ObservableCollection<OrganizationPreview>();

        private readonly IOrganizationApiService _organizationApiService;

        private IConnectivity _connectivity;

        public OrganizationListViewModel(IOrganizationApiService organizationApiService, IConnectivity connectivity)
        {
            _organizationApiService = organizationApiService;
            _connectivity = connectivity;
        }

        [RelayCommand]
        public async Task LoadOrganizationList()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                $"Please check internet and try again.", "OK");
                return;
            }
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;

                var organizationPreviews = await _organizationApiService.GetAllOrganizationPreviews();

                if (OrganizationPreviews.Count != 0)
                {
                    OrganizationPreviews.Clear();
                }

                foreach (var item in organizationPreviews)
                {
                    OrganizationPreviews.Add(item);
                }
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

        [RelayCommand]
        public async Task GoToDetails(int id)
        {
            await Shell.Current.GoToAsync(nameof(OrganizationDetailsPage), true, new Dictionary<string, object>
            {
                {"organizationId" , id}
            });
        }

        public override async Task OnAppearing()
        {
            await LoadOrganizationList();
        }
    }
}

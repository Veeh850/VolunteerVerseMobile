using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
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
    public partial class EventListViewModel : BaseViewModel
    {
        public ObservableCollection<EventPreview> EventPreviews { get; } = new ObservableCollection<EventPreview>();

        private readonly IEventApiService _eventApiService;

        private IConnectivity _connectivity;

        [ObservableProperty]
        private string _searchtext;

        [ObservableProperty]
        private EventFilter _eventFilter;

        public EventListViewModel(IEventApiService eventApiService, IConnectivity connectivity)
        {
            _eventApiService = eventApiService;
            _connectivity = connectivity;

            _eventFilter = new EventFilter(string.Empty);

        }

        [RelayCommand]
        public async Task LoadEventList()
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

                var eventPreviews = await _eventApiService.GetAllEventPreviews(EventFilter);

                if(EventPreviews.Count != 0)
                {
                    EventPreviews.Clear();
                }

                foreach (var item in eventPreviews)
                {
                    EventPreviews.Add(item);
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

        [RelayCommand]
        public async Task ResetEventFilter()
        {
            EventFilter = new EventFilter("");

            await LoadEventList();
        }


        public override async Task OnAppearing()
        {
            await LoadEventList();
        }
    }
}

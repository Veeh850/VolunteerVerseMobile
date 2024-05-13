using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.ViewModels
{
    [QueryProperty(nameof(EventId),"eventId")]
    public partial class EventDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private EventDetails _eventDetails;

        [ObservableProperty]
        private int _eventId;

        [ObservableProperty]
        private string _capacity;

        private readonly IEventApiService _eventApiService;


        public EventDetailsViewModel(IEventApiService eventApiService)
        {
            EventDetails = new EventDetails();

            _eventApiService = eventApiService;
        }

        [RelayCommand]
        public async Task LoadEventDetails()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                EventDetails = await _eventApiService.GetEventDetailsById(EventId);
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
            await LoadEventDetails();
        }
    }
}

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
using VolunteerVerseMobile.Views;

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

        [RelayCommand]
        public Task GoToOrganizationDetailsPage()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        public async Task JoinButtonClicked()
        {
            if(IsBusy)
            {
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(AccountContext.Token))
                {
                    await Shell.Current.Navigation.PopToRootAsync();

                    await Shell.Current.GoToAsync(nameof(LoginPage));

                    IsBusy = false;

                    return;
                }

                IsBusy = true;

                if(EventDetails.IsJoined == false)
                {
                    await _eventApiService.RegisterForEvent(EventId);

                }
                else
                {
                    await _eventApiService.DeleteEventRegistration(EventId);
                }

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

        [RelayCommand]
        public async Task TaskButtonClicked(TaskDetailsForEvents taskDetails)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                if(string.IsNullOrEmpty(AccountContext.Token))
                {
                    await Shell.Current.Navigation.PopToRootAsync();

                    await Shell.Current.GoToAsync(nameof(LoginPage));

                    IsBusy = false;

                    return;
                }

                IsBusy = true;

                if(taskDetails.IsApplied == false)
                {
                    await _eventApiService.ApplyForTask(EventId, taskDetails.Id);

                }
                else
                {
                    await _eventApiService.RemoveApplicationForTask(EventId, taskDetails.Id);
                }

                EventDetails = await _eventApiService.GetEventDetailsById(EventId);
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
            await LoadEventDetails();
        }
    }
}

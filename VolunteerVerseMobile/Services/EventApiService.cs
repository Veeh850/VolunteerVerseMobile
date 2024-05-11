using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.Services
{
    public class EventApiService : IEventApiService
    {
        private readonly HttpClient _httpClient;

        public EventApiService()
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri(Constants.BaseUrl);
        }

        public async Task<List<EventPreview>> GetAllEventPreviews()
        {
            var response = await _httpClient.GetAsync(Constants.EventListUrl);

            if(response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    await Shell.Current.DisplayAlert("Error",errorResponse.Errors[0], "OK");

                    return null;
                }
            }

            return await response.Content.ReadFromJsonAsync<List<EventPreview>>();
        }
    }
}

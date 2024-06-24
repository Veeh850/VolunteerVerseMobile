using System.Net.Http.Headers;
using System.Net.Http.Json;
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

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);
        }

        public async Task<List<EventPreview>> GetAllEventPreviews(EventFilter? eventFilter = null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

            string url = Constants.EventUrl;

            if (eventFilter != null)
            { 

                url += "?";
            
                if (string.IsNullOrEmpty(eventFilter.Name) == false)
                {
                    url += $"name={eventFilter.Name}&";
                }

                if(string.IsNullOrEmpty(eventFilter.OrganizationName) == false)
                {
                    url += $"organizationName={eventFilter.OrganizationName}&";
                }

                if(string.IsNullOrEmpty(eventFilter.Location) == false)
                {
                    url += $"location={eventFilter.Location}&";
                }

                if(eventFilter.StartDate != null)
                {
                    url += $"startDate={eventFilter.StartDate}&";
                }

                if (eventFilter.EndDate != null)
                {
                    url += $"endDate={eventFilter.EndDate}&";
                }

            }


            var response = await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }

            return await response.Content.ReadFromJsonAsync<List<EventPreview>>();
        }

        public async Task<EventDetails> GetEventDetailsById(int id)
        {

            if (string.IsNullOrEmpty(AccountContext.Token) == false)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }

            var response = await _httpClient.GetAsync($"{Constants.EventUrl}/{id}/details");


            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }

            return await response.Content.ReadFromJsonAsync<EventDetails>();
        }

        public async Task RegisterForEvent(int eventId)
        {
            var response = await _httpClient.PostAsync($"{Constants.VolunteerUrl}/events/{eventId}", new StringContent(""));

            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }
        }

        public async Task ApplyForTask(int eventId, int taskId)
        {
            var response = await _httpClient.PostAsync($"{Constants.VolunteerUrl}/events/{eventId}/tasks/{taskId}", new StringContent(""));

            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }
        }

        public async Task DeleteEventRegistration(int eventId)
        {
            var response = await _httpClient.DeleteAsync($"{Constants.VolunteerUrl}/events/{eventId}");

            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }
        }

        public async Task RemoveApplicationForTask(int eventId, int taskId)
        {
            var response = await _httpClient.DeleteAsync($"{Constants.VolunteerUrl}/events/{eventId}/tasks/{taskId}");

            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }
        }
    }
}

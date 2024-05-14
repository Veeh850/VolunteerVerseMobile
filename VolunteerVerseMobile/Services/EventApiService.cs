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

            //_httpClient.BaseAddress = new Uri(Constants.BaseUrl);
        }
        public async Task<List<EventPreview>> GetAllEventPreviews(EventFilter? eventFilter = null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

            string url = Constants.EventListUrl;

            if(eventFilter != null)
            {
                if(string.IsNullOrEmpty(eventFilter.Name) == false)
                {
                    url = url + $"?name={eventFilter.Name}";
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

        public  async Task<EventDetails> GetEventDetailsById(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

            string url = Constants.EventListUrl;


            var response = await _httpClient.GetAsync($"{Constants.EventListUrl}/{id}/details");


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
    }
}

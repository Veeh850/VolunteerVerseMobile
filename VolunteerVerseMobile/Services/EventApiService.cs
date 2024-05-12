﻿using System.Net.Http.Headers;
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
        public async Task<List<EventPreview>> GetAllEventPreviews()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

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

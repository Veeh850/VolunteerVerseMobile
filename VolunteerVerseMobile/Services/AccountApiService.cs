using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Models.Account;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.Services
{
    public class AccountApiService : IAccountApiService
    {
        private readonly HttpClient _httpClient;

        public AccountApiService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

            //_httpClient.BaseAddress = new Uri(Constants.BaseUrl);

        }

        public async Task<AccountDetails> GetOwnAccountDetails()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

            string url = Constants.AccountDetailsUrl;

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }

            return await response.Content.ReadFromJsonAsync<AccountDetails>();
        }
    }
}

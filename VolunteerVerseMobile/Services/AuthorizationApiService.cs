using System.Net.Http.Headers;
using System.Net.Http.Json;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Models;
using VolunteerVerseMobile.Models.Account;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.Services
{
    public class AuthorizationApiService : IAuthorizationApiService
    {
        private readonly HttpClient _httpClient;

        public AuthorizationApiService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountContext.Token);

            //_httpClient.BaseAddress = new Uri(Constants.BaseUrl);
        }

        public async Task<LoginResponseDTO> LoginAsync(string emailAddress, string password)
        {
            var loginModel = new LoginWithEmailDTO { Email = emailAddress, Password = password };

            var response = await _httpClient.PostAsync(Constants.LoginUrl, ApiUtils.GenerateBody<LoginWithEmailDTO>(loginModel));

            if(response.IsSuccessStatusCode == false)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if (errorResponse != null && errorResponse.Errors.Count != 0)
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }

            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }
    }
}

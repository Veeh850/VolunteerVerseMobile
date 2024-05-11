using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Utils
{
    public static class ApiClient
    {
        public static async Task<T> Get<T>(string url)
        {
            var responseMessage = await GetFromUrlAsync(url);

            if (responseMessage.IsSuccessStatusCode == false)
            {
                var errorResponse = await responseMessage.Content.ReadFromJsonAsync<ErrorResponseDTO>();

                if(errorResponse != null && errorResponse.Errors.Count != 0) 
                {
                    throw new Exception(errorResponse.Errors[0]);
                }
            }

            return await responseMessage.Content.ReadFromJsonAsync<T>();
        }

        private static async Task<HttpResponseMessage> GetFromUrlAsync(string url)
        {
            var client = new HttpClient();

            var result = await client.GetAsync(url);

            return result;
        }
    }
}

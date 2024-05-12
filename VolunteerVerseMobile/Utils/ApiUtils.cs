using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Utils
{
    public static class ApiUtils
    {
        public static StringContent GenerateBody<T> (T model)
        {

            var jsonContent = JsonSerializer.Serialize<T>(model);

            return new StringContent(jsonContent, Encoding.UTF8, "application/json");
        }
    }
}

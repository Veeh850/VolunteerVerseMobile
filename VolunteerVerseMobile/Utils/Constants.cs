using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Utils
{
    public static class Constants
    {
        //public const string BaseUrl = "https://volunteer-verse.azurewebsites.net/api";
        public const string BaseUrl = "https://localhost:7192/api";

        public readonly static string EventListUrl = $"{BaseUrl}/events";

        public readonly static string LoginUrl = $"{BaseUrl}/accounts/login";

        public readonly static string AccountDetailsUrl = $"{BaseUrl}/profiles/own";

        public readonly static string ProfileEventsUrl = $"{BaseUrl}/profiles/events";
    }
}

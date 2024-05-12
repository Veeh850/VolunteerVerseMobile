using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Interfaces
{
    public interface IAuthorizationApiService
    {
        public Task<LoginResponseDTO> LoginAsync(string emailAddress, string password);
    }
}

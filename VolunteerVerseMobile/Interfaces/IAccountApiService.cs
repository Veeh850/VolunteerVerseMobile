using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models.Account;

namespace VolunteerVerseMobile.Interfaces
{
    public interface IAccountApiService
    {
        public Task<AccountDetails> GetOwnAccountDetails();

        public Task<List<ProfileEvent>> GetProfileEvents();
    }
}

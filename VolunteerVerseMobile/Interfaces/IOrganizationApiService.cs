using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Interfaces
{
    public interface IOrganizationApiService
    {
        public Task<List<OrganizationPreview>> GetAllOrganizationPreviews();

        public Task<OrganizationDetails> GetOrganizationDetailsById(int id);
    }
}

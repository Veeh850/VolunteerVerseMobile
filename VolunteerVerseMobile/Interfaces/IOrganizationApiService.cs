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

        public Task LeaveOrganization(int orgId);

        public Task DeleteOrganization(int orgId);

        public Task AddOrganizationMember(int orgId, string email);
    }
}

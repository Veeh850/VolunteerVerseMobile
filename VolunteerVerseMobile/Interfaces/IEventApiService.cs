using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Interfaces
{
    public interface IEventApiService
    {
        public Task<List<EventPreview>> GetAllEventPreviews(EventFilter? eventFilter = null);

        public Task<EventDetails> GetEventDetailsById(int id);
    }
}

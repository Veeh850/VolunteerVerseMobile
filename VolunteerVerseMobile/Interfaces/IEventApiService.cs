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

        public Task RegisterForEvent(int eventId);

        public Task DeleteEventRegistration(int eventId);

        public Task ApplyForTask(int eventId, int taskId);

        public Task RemoveApplicationForTask(int eventId, int taskId);
    }
}

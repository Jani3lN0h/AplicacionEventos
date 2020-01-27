using EventRepository;
using System.Collections.Generic;

namespace EventService.Interfaces
{
    public interface IEventService
    {
        List<Event> GetInfoEvents(List<Event> listEvents);
    }
}

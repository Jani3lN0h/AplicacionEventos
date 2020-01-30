using EventRepository;
using System.Collections.Generic;

namespace EventService.Interfaces
{
    public interface IEventService
    {
        List<EventDisplay> SetInfoEventsDisplay(List<Event> listEvents);
    }
}

using EventRepository;
using System.Collections.Generic;

namespace EventService.Interfaces
{
    public interface IFileService
    {
        List<Event> GetEvents(string _cRuta);
    }
}

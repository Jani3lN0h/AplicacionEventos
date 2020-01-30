using EventRepository;
using System;
using System.Collections.Generic;

namespace EventService.Interfaces
{
    public interface IFileService
    {
        Func<string, string[]> ReaderFiles { get; set; }

        Func<DateTime> ObtenerFecha { get; set; }

        List<Event> GetEvents(string _cRuta);
    }
}

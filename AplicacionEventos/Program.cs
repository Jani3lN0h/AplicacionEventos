using EventService;
using EventService.Interfaces;

namespace AplicacionEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventService eventService = new EventsService();
            IFileService fileService = new FileService();

            EventManagement eventManagement = new EventManagement(eventService, fileService);
            eventManagement.Init();
        }
    }
}

using EventRepository;
using EventService.Interfaces;
using System;
using System.Collections.Generic;

namespace AplicacionEventos
{
    public class EventManagement
    {
        private readonly string cRuta = "C:\\Users\\janiel.noh\\Desktop\\sample.txt";
        private readonly IEventService _eventService;
        private readonly IFileService _fileService;

        public EventManagement(IEventService eventService, IFileService fileService)
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void Init()
        {
            List<Event> listEvents = _fileService.GetEvents(cRuta);
            listEvents = _eventService.GetInfoEvents(listEvents);
            ShowEvents(listEvents);
        }

        private void ShowEvents(List<Event> listEvents)
        {
            foreach (Event item in listEvents)
            {
                Console.WriteLine(item.cMensaje);
            }
            Console.ReadLine();
        }
    }
}
using EventRepository;
using EventService.Interfaces;
using EventValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionEventos
{
    public class EventManagement
    {
        private string cRuta; //= "C:\\Users\\janiel.noh\\Desktop\\sample.txt";
        private readonly IEventService _eventService;
        private readonly IFileService _fileService;
        private readonly IObtainFileService _obtainFileService;
        private readonly IValidateFile _validateFile;
        private readonly IDisplayInfoService _displayInfoService;

        public EventManagement(IEventService eventService, IFileService fileService, IObtainFileService obtainFileService, IValidateFile validateFile,IDisplayInfoService displayInfoService)
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _obtainFileService = obtainFileService ?? throw new ArgumentNullException(nameof(obtainFileService));
            _validateFile = validateFile ?? throw new ArgumentNullException(nameof(validateFile));
            _displayInfoService = displayInfoService ?? throw new ArgumentNullException(nameof(displayInfoService));
        }

        public void Init()
        {
            cRuta = _obtainFileService.ObtainRouteFile();
            if (!_validateFile.ValidarExistenciaArchivo(cRuta))
            {
                _displayInfoService.DisplayMessage("El archivo no existe en la ruta especificada");
                Init();
            }
            List<Event> listEvents = _fileService.GetEvents(cRuta);
            listEvents = _eventService.GetInfoEvents(listEvents);
            _displayInfoService.ListDisplayInfo(listEvents.Select(x => x.cMensaje).ToArray());
        }
    }
}
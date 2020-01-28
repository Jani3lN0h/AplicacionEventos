using EventService;
using EventService.Interfaces;
using EventValidator;
using EventValidator.Interfaces;

namespace AplicacionEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidateDate validateDate = new ValidateDate();
            IEventService eventService = new EventsService();
            IFileService fileService = new FileService(validateDate);
            IObtainFileService obtainFileService = new ObtainFileService();
            IValidateFile validateFile = new ValidateFile();
            IDisplayInfoService displayInfoService = new DisplayInfoService();

            EventManagement eventManagement = new EventManagement(eventService, fileService, obtainFileService, validateFile, displayInfoService);
            eventManagement.Init();
        }
    }
}
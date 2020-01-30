using EventService;
using EventService.Factory;
using EventService.Factory.Interfaces;
using EventService.Interfaces;
using EventValidator;
using EventValidator.Interfaces;

namespace AplicacionEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            IDetermineType determineType = new DetermineType();
            IValidateDate validateDate = new ValidateDate();
            IDetermineTypeFactory determineTypeFactory = new DetermineTypeFactory();
            IEventService eventService = new EventsService(determineType,validateDate, determineTypeFactory);
            IFileService fileService = new FileService(validateDate);
            IObtainFileService obtainFileService = new ObtainFileService();
            IValidateFile validateFile = new ValidateFile();
            IDisplayInfoService displayInfoService = new DisplayInfoService();

            EventManagement eventManagement = new EventManagement(eventService, fileService, obtainFileService, validateFile, displayInfoService);
            eventManagement.Init();
        }
    }
}
using EventRepository;
using EventService.Factory.Interfaces;
using EventService.Interfaces;
using EventValidator.Interfaces;
using System;
using System.Collections.Generic;

namespace EventService
{
    public class EventsService : IEventService
    {
        private readonly IDetermineType _determineType;
        private readonly IValidateDate _validateDate;
        private readonly IDetermineTypeFactory _determineTypeFactory;

        public EventsService(IDetermineType determineType, IValidateDate validateDate, IDetermineTypeFactory determineTypeFactory)
        {
            _determineType = determineType ?? throw new ArgumentNullException(nameof(determineType));
            _validateDate = validateDate ?? throw new ArgumentNullException(nameof(validateDate));
            _determineTypeFactory = determineTypeFactory ?? throw new ArgumentNullException(nameof(determineTypeFactory));
        }

        public List<EventDisplay> SetInfoEventsDisplay(List<Event> listEvents)
        {

            List<EventDisplay> listDisplay = new List<EventDisplay>();

            foreach (Event item in listEvents)
            {
                EventDisplay newEvent = new EventDisplay();
                newEvent.cNombre = item.cNombre;
                newEvent.dtFecha = item.dtFecha;
                newEvent.Tipo = _determineType.CalculateType(item.dtFecha);
                newEvent.lPasado = _validateDate.DeterminePastEvent(item.dtFecha);
                newEvent.iDiferencia = _validateDate.SetMinutes(item.dtFecha);
                ITypeCalculator typeCalculator = _determineTypeFactory.ObtenerInstancia(newEvent.Tipo);
                newEvent.cMensaje = typeCalculator.CreateDisplayMessage(newEvent);

                listDisplay.Add(newEvent);
            }
            return listDisplay;
        }
    }
}

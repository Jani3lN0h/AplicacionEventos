using EventRepository;
using EventService.Interfaces;
using System.Collections.Generic;

namespace EventService
{
    public class EventsService : IEventService
    {
        public List<Event> GetInfoEvents(List<Event> listEvents)
        {
            string cPasado = "ocurrió hace";
            string cFuturo = "ocurrirá dentro de";
            foreach (Event item in listEvents)
            {
                item.cMensaje = string.Format("{0} {1}: {2} {3}", item.cNombre, (item.iDiferencia < 0 ? cPasado : cFuturo), item.iDiferencia, item.cTipo);
            }

            return listEvents;
        }
    }
}

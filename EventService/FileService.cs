using EventRepository;
using EventService.Interfaces;
using EventValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace EventService
{
    public class FileService: IFileService
    {
        private readonly IValidateDate _validateDate;

        public Func<string, string[]> ReaderFiles { get; set; }
        public Func<DateTime> ObtenerFecha { get; set; }

        public FileService(IValidateDate validateDate)
        {
            _validateDate = validateDate ?? throw new ArgumentNullException(nameof(validateDate));
            ReaderFiles = (ruta) => File.ReadAllLines(ruta);
            ObtenerFecha = () => DateTime.Now;
        }

        public List<Event> GetEvents(string _cRuta)
        {
            string[] arrEvents = ReaderFiles(_cRuta);
            List<Event> listEvents = AssignEvent(arrEvents);

            return listEvents;
        }

        private List<Event> AssignEvent(string[] arrEvents)
        {
            List<Event> listEvents = new List<Event>();
            foreach (string cEvent in arrEvents)
            {
                string[] arrValues = cEvent.Split(',');

                Event newEvent = new Event();
                newEvent.cNombre = arrValues[0];
                newEvent.dtFecha = _validateDate.SetValueFecha(arrValues[1]);
                listEvents.Add(newEvent);
            }

            return listEvents;
        }
    }
}

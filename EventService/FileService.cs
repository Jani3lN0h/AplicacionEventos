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
        private IValidateDate _validateDate;
        public FileService(IValidateDate validateDate)
        {
            _validateDate = validateDate ?? throw new ArgumentNullException(nameof(validateDate));
        }

        public List<Event> GetEvents(string _cRuta)
        {
            Array arrEvents = File.ReadAllLines(_cRuta);
            List<Event> listEvents = AssignEvent(arrEvents);

            return listEvents;
        }

        private List<Event> AssignEvent(Array arrEvents)
        {
            List<Event> listEvents = new List<Event>();
            foreach (string cEvent in arrEvents)
            {
                string[] arrValues = cEvent.Split(',');

                Event newEvent = new Event();
                newEvent.cNombre = arrValues[0];
                newEvent.cMensaje = string.Empty;
                newEvent.dtFecha = _validateDate.SetValueFecha(arrValues[1]);
                newEvent.cTipo = GetTipoFecha(newEvent.dtFecha);
                newEvent.iDiferencia = GetDiferencia(newEvent.cTipo, newEvent.dtFecha);
                listEvents.Add(newEvent);
            }

            return listEvents;
        }

        private string GetTipoFecha(DateTime dtFecha)
        {
            TimeSpan diferencia = DateTime.Now - dtFecha;
            string cTipo = string.Empty;

            if (diferencia.Days > 30)
            {
                cTipo = "MES";
            }
            else if (diferencia.Days > 0)
            {
                cTipo = "DIA";
            }
            else if (diferencia.Hours > 0)
            {
                cTipo = "HORA";
            }
            else if (diferencia.Minutes >= 0)
            {
                cTipo = "MINUTO";
            }
            return cTipo;
        }

        private int GetDiferencia(string cTipo, DateTime dtFecha)
        {
            TimeSpan diferencia = DateTime.Now - dtFecha;
            int iDiferencia;

            switch (cTipo)
            {
                case "MES":
                    iDiferencia = diferencia.Days / 30;
                    break;
                case "DIA":
                    iDiferencia = diferencia.Days;
                    break;
                case "HORA":
                    iDiferencia = diferencia.Hours;
                    break;
                case "MINUTO":
                    iDiferencia = diferencia.Minutes;
                    break;
                default:
                    iDiferencia = 0;
                    break;
            }
            return iDiferencia;
        }
    }
}

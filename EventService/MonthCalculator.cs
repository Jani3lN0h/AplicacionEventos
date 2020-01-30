using EventRepository;
using EventService.Interfaces;
using System;
using Utils.Interfaces;

namespace EventService
{
    public class MonthCalculator: ITypeCalculator
    {
        private readonly IUtil _util;
        private readonly string cLeyendaPasado = "ocurrió hace";
        private readonly string cLeyendaFuturo = "ocurrirá dentro de";

        public MonthCalculator(IUtil util)
        {
            _util = util ?? throw new ArgumentNullException(nameof(util));
        }

        public string CreateDisplayMessage(EventDisplay eventDisplay)
        {
            return string.Format("{0} {1}: {2} {3}", eventDisplay.cNombre, eventDisplay.lPasado ? cLeyendaPasado : cLeyendaFuturo, obtenerValor(eventDisplay.iDiferencia), _util.GetDisplayName(eventDisplay.Tipo));
        }

        private int obtenerValor(double dTiempo)
        {
            var tiempo = TimeSpan.FromMinutes(dTiempo);
            return (tiempo.Days/30);
        }
    }
}

using EventValidator.Interfaces;
using System;

namespace EventValidator
{
    public class ValidateDate : IValidateDate
    {
        public Func<DateTime> FechaActual { get; set; }
        public Func<string, DateTime> ConvertirFecha { get; set; }
        private const string cFormatoFecha = "dd/MM/yyyy HH:mm";

        public ValidateDate()
        {
            FechaActual = () => DateTime.Now;
            ConvertirFecha = (cFechaConvertir) => Convert.ToDateTime(cFechaConvertir);
        }

        public DateTime SetValueFecha(string cFecha)
        {
            DateTime dtReturnFecha = ConvertirFecha(cFecha);

            return dtReturnFecha;
        }

        public bool DeterminePastEvent(DateTime dtFechaEvaluar)
        {
            return (DateTime.Compare(FechaActual(), dtFechaEvaluar) >= 0);
        }

        public double SetMinutes(DateTime dtFechaEvaluar)
        {
            return Math.Abs((FechaActual() - dtFechaEvaluar).TotalMinutes);
        }
    }
}
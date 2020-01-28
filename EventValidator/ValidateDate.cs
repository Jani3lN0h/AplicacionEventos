using EventValidator.Interfaces;
using System;
using System.Globalization;

namespace EventValidator
{
    public class ValidateDate : IValidateDate
    {
        private const string cFormatoFecha = "dd/MM/yyyy HH:mm";

        public DateTime SetValueFecha(string cFecha)
        {
            DateTime dtReturnFecha = DateTime.ParseExact(cFecha, cFormatoFecha, CultureInfo.InvariantCulture);

            return dtReturnFecha;
        }
    }
}
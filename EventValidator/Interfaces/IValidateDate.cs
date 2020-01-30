using System;

namespace EventValidator.Interfaces
{
    public interface IValidateDate
    {
        DateTime SetValueFecha(string cFecha);

        bool DeterminePastEvent(DateTime dtFechaEvaluar);

        double SetMinutes(DateTime dtFechaEvaluar);
    }
}
using EventService.Interfaces;
using System;
using static EventRepository.ERangeTypes;

namespace EventService
{
    public class DetermineType : IDetermineType
    {
        private int durationMinute { get { return 1; } }

        private int durationHour { get { return (durationMinute * 60); } }

        private int durationDay { get { return (durationHour * 24); } }

        private int durationMonth { get { return (durationDay * 30); } }

        public Func<DateTime> ObtenerFecha { get; set; }

        public DetermineType()
        {
            ObtenerFecha = () => DateTime.Now;
        }

        public RangeType CalculateType(DateTime dtFechaEvaluar)
        {
            var diferencia = Math.Abs((ObtenerFecha() - dtFechaEvaluar).TotalMinutes);

            if (diferencia >= durationMonth)
            {
                return RangeType.Month;
            }
            else
            {
                if (diferencia >= durationDay)
                {
                    return RangeType.Day;
                }
                else
                {
                    if (diferencia >= durationHour)
                    {
                        return RangeType.Hour;
                    }
                    else
                    {
                        return RangeType.Minute;
                    }
                }
            }
        }
    }
}
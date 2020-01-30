using EventService.Factory.Interfaces;
using EventService.Interfaces;
using Utils;
using Utils.Interfaces;
using static EventRepository.ERangeTypes;

namespace EventService.Factory
{
    public class DetermineTypeFactory : IDetermineTypeFactory
    {
        public ITypeCalculator ObtenerInstancia(RangeType eRangeType)
        {
            IUtil util = new Util();
            ITypeCalculator CreadorMensaje = null;
            switch (eRangeType)
            {
                case RangeType.Minute:
                    CreadorMensaje = new MinuteCalculator(util);
                    break;
                case RangeType.Hour:
                    CreadorMensaje = new HourCalculator(util);
                    break;
                case RangeType.Day:
                    CreadorMensaje = new DayCalculator(util);
                    break;
                case RangeType.Month:
                    CreadorMensaje = new MonthCalculator(util);
                    break;
            }
            return CreadorMensaje;
        }
    }
}

using EventService.Interfaces;
using static EventRepository.ERangeTypes;

namespace EventService.Factory.Interfaces
{
    public interface IDetermineTypeFactory
    {
        ITypeCalculator ObtenerInstancia(RangeType eRangeType);
    }
}

using System;
using static EventRepository.ERangeTypes;

namespace EventService.Interfaces
{
    public interface IDetermineType
    {
        RangeType CalculateType(DateTime dtFechaEvaluar);
    }
}

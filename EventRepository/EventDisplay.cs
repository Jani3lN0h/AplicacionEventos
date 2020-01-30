using static EventRepository.ERangeTypes;

namespace EventRepository
{
    public class EventDisplay : Event
    {
        public string cMensaje { get; set; }

        public double iDiferencia { get; set; }

        public bool lPasado { get; set; }

        public RangeType Tipo { get; set; }
    }
}

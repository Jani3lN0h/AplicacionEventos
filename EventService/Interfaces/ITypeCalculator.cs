using EventRepository;

namespace EventService.Interfaces
{
    public interface ITypeCalculator
    {
        string CreateDisplayMessage(EventDisplay eventDisplay);
    }
}

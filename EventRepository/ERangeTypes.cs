using System.ComponentModel.DataAnnotations;

namespace EventRepository
{
    public class ERangeTypes
    {
        public enum RangeType
        {
            [Display(Name = "Minuto")]
            Minute = 0,
            [Display(Name = "Hora")]
            Hour = 1,
            [Display(Name = "Día")]
            Day = 2,
            [Display(Name = "Mes")]
            Month = 3
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Utils.Interfaces;
using static EventRepository.ERangeTypes;

namespace Utils
{
    public class Util : IUtil
    {
        public string GetDisplayName(RangeType enumType)
        {
            return enumType.GetType()
                      .GetMember(enumType.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.Name
                      ?? enumType.ToString();
        }
    }
}
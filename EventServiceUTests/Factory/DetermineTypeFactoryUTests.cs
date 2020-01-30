using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static EventRepository.ERangeTypes;

namespace EventService.Factory.Tests
{
    [TestClass()]
    public class DetermineTypeFactoryUTests
    {
        [DataRow(RangeType.Minute, typeof(MinuteCalculator))]
        [DataRow(RangeType.Hour, typeof(HourCalculator))]
        [DataRow(RangeType.Day, typeof(DayCalculator))]
        [DataRow(RangeType.Month, typeof(MonthCalculator))]
        [TestMethod()]
        public void ObtenerInstancia_TipoRangoRecibido_InstanciaCorrecta(RangeType Tipo, Type ClassType)
        {
            //Arrange
            DetermineTypeFactory SUT = new DetermineTypeFactory();

            //Act
            var result = SUT.ObtenerInstancia(Tipo);

            //Assert
            Assert.IsInstanceOfType(result, ClassType);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static EventRepository.ERangeTypes;

namespace EventService.Tests
{
    [TestClass()]
    public class DetermineTypeUTests
    {
        [DataRow("28/01/2020 23:00", RangeType.Minute)]
        [DataRow("28/01/2020 20:00",RangeType.Hour)]
        [DataRow("30/01/2020 08:00", RangeType.Day)]
        [DataRow("01/12/2019 08:00", RangeType.Month)]
        [TestMethod()]
        public void CalculateType_FechaRecibida_ResultadoCorrecto(string cFechaEvaluar, RangeType enumType)
        {
            DateTime dtFechaEvaluar = Convert.ToDateTime(cFechaEvaluar);
            var SUT = new DetermineType();
            SUT.ObtenerFecha = () => new DateTime(2020, 1, 28, 22, 50, 0);

            var result = SUT.CalculateType(dtFechaEvaluar);

            Assert.AreEqual(enumType, result);
        }
    }
}
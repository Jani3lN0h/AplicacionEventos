using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EventValidator.Tests
{
    [TestClass()]
    public class ValidateDateUTests
    {
        [TestMethod()]
        public void SetValueFecha_FechaCorrecta_FechaAsignadaCorrectamente()
        {
            //Arrange
            ValidateDate SUT = new ValidateDate();
            SUT.ConvertirFecha = (fecha) => new DateTime(2019, 1, 28);

            //Act
            var resultado = SUT.SetValueFecha("Fecha");

            //Assert
            Assert.AreEqual(new DateTime(2019, 1, 28), resultado);
        }

        [DataRow("01/01/2020 08:00", true)]
        [DataRow("01/03/2020 08:00", false)]
        [TestMethod()]
        public void DeterminePastEvent_FechaRecibida_DeterminaCorrectamenteFecha(string cFecha, bool lResult)
        {
            //Arrange
            ValidateDate SUT = new ValidateDate();
            SUT.ConvertirFecha = (fecha) => new DateTime(2019, 1, 28);
            DateTime dtFechaEvaluar = Convert.ToDateTime(cFecha);

            //Act
            var resultado = SUT.DeterminePastEvent(dtFechaEvaluar);

            //Assert
            Assert.AreEqual(lResult, resultado);
        }

        [DataRow("28/01/2020 19:10", 10)]
        [DataRow("28/01/2020 20:00", 60)]
        [TestMethod()]
        public void SetMinutesTest(string cFecha, int iResult)
        {
            //Arrange
            ValidateDate SUT = new ValidateDate();
            SUT.FechaActual = () => new DateTime(2020, 1, 28, 19, 0, 0);
            DateTime dtFechaEvaluar = Convert.ToDateTime(cFecha);

            //Act
            var resultado = SUT.SetMinutes(dtFechaEvaluar);

            //Assert
            Assert.AreEqual(iResult, resultado);
        }
    }
}
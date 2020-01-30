using EventRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Utils;
using Utils.Interfaces;
using static EventRepository.ERangeTypes;

namespace EventService.Tests
{
    [TestClass()]
    public class DayCalculatorUTests
    {
        [TestMethod()]
        public void DayCalculator_IUtilNulo_Exception()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DayCalculator(null));
        }

        [TestMethod()]
        public void DayCalculator_IUtilCorrecto_InstanciaCorrecta()
        {
            //Arrange
            Mock<IUtil> util = new Mock<IUtil>();
            DayCalculator SUT = new DayCalculator(util.Object);

            //Assert
            Assert.IsInstanceOfType(SUT, typeof(DayCalculator));
        }

        [TestMethod()]
        public void CreateDisplayMessage_EventoRecibido_CreaMensajeCorrecto()
        {
            IUtil util = new Util();
            DayCalculator SUT = new DayCalculator(util);
            EventDisplay eventDisplay = new EventDisplay();
            eventDisplay.cNombre = "Test";
            eventDisplay.dtFecha = new DateTime(2020, 2, 1);
            eventDisplay.iDiferencia = 1440;
            eventDisplay.Tipo = RangeType.Day;

            var result = SUT.CreateDisplayMessage(eventDisplay);

            Assert.AreEqual("Test ocurrirá dentro de: 1 Día", result);
        }
    }
}
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
    public class HourCalculatorUTests
    {
        [TestMethod()]
        public void HourCalculator_IUtilNulo_Exception()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new HourCalculator(null));
        }

        [TestMethod()]
        public void HourCalculator_IUtilCorrecto_InstanciaCorrecta()
        {
            //Arrange
            Mock<IUtil> util = new Mock<IUtil>();
            HourCalculator SUT = new HourCalculator(util.Object);

            //Assert
            Assert.IsInstanceOfType(SUT, typeof(HourCalculator));
        }

        [TestMethod()]
        public void CreateDisplayMessage_EventoRecibido_CreaMensajeCorrecto()
        {
            IUtil util = new Util();
            HourCalculator SUT = new HourCalculator(util);
            EventDisplay eventDisplay = new EventDisplay();
            eventDisplay.cNombre = "Test";
            eventDisplay.dtFecha = new DateTime(2020, 2, 1, 22, 0, 0);
            eventDisplay.iDiferencia = 120;
            eventDisplay.Tipo = RangeType.Hour;

            var result = SUT.CreateDisplayMessage(eventDisplay);

            Assert.AreEqual("Test ocurrirá dentro de: 2 Hora", result);
        }
    }
}
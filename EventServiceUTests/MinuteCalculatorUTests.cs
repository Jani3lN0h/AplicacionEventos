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
    public class MinuteCalculatorUTests
    {
        [TestMethod()]
        public void MinuteCalculator_IUtilNulo_Exception()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new MinuteCalculator(null));
        }

        [TestMethod()]
        public void MinuteCalculator_IUtilCorrecto_InstanciaCorrecta()
        {
            //Arrange
            Mock<IUtil> util = new Mock<IUtil>();
            MinuteCalculator SUT = new MinuteCalculator(util.Object);

            //Assert
            Assert.IsInstanceOfType(SUT, typeof(MinuteCalculator));
        }

        [TestMethod()]
        public void CreateDisplayMessage_EventoRecibido_CreaMensajeCorrecto()
        {
            IUtil util = new Util();
            MinuteCalculator SUT = new MinuteCalculator(util);
            EventDisplay eventDisplay = new EventDisplay();
            eventDisplay.cNombre = "Test";
            eventDisplay.dtFecha = new DateTime(2020, 2, 1);
            eventDisplay.iDiferencia = 20;
            eventDisplay.Tipo = RangeType.Minute;

            var result = SUT.CreateDisplayMessage(eventDisplay);

            Assert.AreEqual("Test ocurrirá dentro de: 20 Minuto", result);
        }
    }
}
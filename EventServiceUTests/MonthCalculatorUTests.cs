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
    public class MonthCalculatorUTests
    {
        [TestMethod()]
        public void MonthCalculator_IUtilNulo_Exception()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new MonthCalculator(null));
        }

        [TestMethod()]
        public void MonthCalculator_IUtilCorrecto_InstanciaCorrecta()
        {
            //Arrange
            Mock<IUtil> util = new Mock<IUtil>();
            MonthCalculator SUT = new MonthCalculator(util.Object);

            //Assert
            Assert.IsInstanceOfType(SUT, typeof(MonthCalculator));
        }

        [TestMethod()]
        public void CreateDisplayMessage_EventoRecibido_CreaMensajeCorrecto()
        {
            IUtil util = new Util();
            MonthCalculator SUT = new MonthCalculator(util);
            EventDisplay eventDisplay = new EventDisplay();
            eventDisplay.cNombre = "Test";
            eventDisplay.dtFecha = new DateTime(2020, 2, 1);
            eventDisplay.iDiferencia = 50400;
            eventDisplay.Tipo = RangeType.Month;

            var result = SUT.CreateDisplayMessage(eventDisplay);

            Assert.AreEqual("Test ocurrirá dentro de: 1 Mes", result);
        }
    }
}
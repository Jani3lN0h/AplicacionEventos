using EventRepository;
using EventService.Factory.Interfaces;
using EventService.Interfaces;
using EventValidator.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using static EventRepository.ERangeTypes;

namespace EventService.Tests
{
    [TestClass()]
    public class EventsServiceUTests
    {
        [TestMethod()]
        public void EventsServiceTest_IDetermineTypeNulo_Exception()
        {
            //Arrange
            Mock<IValidateDate> validateDate = new Mock<IValidateDate>();
            Mock<IDetermineTypeFactory> determineTypeFactory = new Mock<IDetermineTypeFactory>();

            //Act-Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EventsService(null, validateDate.Object, determineTypeFactory.Object));
        }

        [TestMethod()]
        public void EventsServiceTest_IValidateDateNulo_Exception()
        {
            //Arrange
            Mock<IDetermineType> determineType = new Mock<IDetermineType>();
            Mock<IDetermineTypeFactory> determineTypeFactory = new Mock<IDetermineTypeFactory>();

            //Act-Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EventsService(determineType.Object, null, determineTypeFactory.Object));
        }

        [TestMethod()]
        public void EventsServiceTest_IDetermineTypeFactoryNulo_Exception()
        {
            //Arrange
            Mock<IDetermineType> determineType = new Mock<IDetermineType>();
            Mock<IValidateDate> validateDate = new Mock<IValidateDate>();

            //Act-Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EventsService(determineType.Object, validateDate.Object, null));
        }

        [TestMethod()]
        public void EventsServiceTest_DependenciasCorrectas_InstanciaCorrecta()
        {
            //Arrange
            Mock<IDetermineType> determineType = new Mock<IDetermineType>();
            Mock<IValidateDate> validateDate = new Mock<IValidateDate>();
            Mock<IDetermineTypeFactory> determineTypeFactory = new Mock<IDetermineTypeFactory>();

            //Act
            var resultado = new EventsService(determineType.Object, validateDate.Object, determineTypeFactory.Object);

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(EventsService));
        }

        [TestMethod()]
        public void SetInfoEventsDisplay_ListaEventos_RegresaInformacionEventos()
        {
            //Arrange
            Mock<IDetermineType> determineType = new Mock<IDetermineType>();
            Mock<IValidateDate> validateDate = new Mock<IValidateDate>();
            Mock<IDetermineTypeFactory> determineTypeFactory = new Mock<IDetermineTypeFactory>();

            determineType.Setup(x => x.CalculateType(It.IsAny<DateTime>())).Returns(RangeType.Day);
            validateDate.Setup(v => v.SetValueFecha(It.IsAny<string>())).Returns(new DateTime(2020, 01, 28));
            validateDate.Setup(vd => vd.SetMinutes(It.IsAny<DateTime>())).Returns(2.5);
            determineTypeFactory.Setup(f => f.ObtenerInstancia(It.IsAny<RangeType>())).Returns(new HourCalculator(new Util()));

            var SUT = new EventsService(determineType.Object, validateDate.Object, determineTypeFactory.Object);

            //Act
            var resultado = SUT.SetInfoEventsDisplay(new List<Event>() { new Event() { cNombre = "Test", dtFecha = new DateTime(2019, 01, 28) } });

            //Assert
            Assert.IsTrue(resultado.Any());
        }

        [TestMethod()]
        public void SetInfoEventsDisplay_ListaEventos_RegresaMensaje()
        {
            //Arrange
            Mock<IDetermineType> determineType = new Mock<IDetermineType>();
            Mock<IValidateDate> validateDate = new Mock<IValidateDate>();
            Mock<IDetermineTypeFactory> determineTypeFactory = new Mock<IDetermineTypeFactory>();

            determineType.Setup(x => x.CalculateType(It.IsAny<DateTime>())).Returns(RangeType.Day);
            validateDate.Setup(v => v.SetValueFecha(It.IsAny<string>())).Returns(new DateTime(2020, 01, 28));
            validateDate.Setup(vd => vd.SetMinutes(It.IsAny<DateTime>())).Returns(2.5);
            determineTypeFactory.Setup(f => f.ObtenerInstancia(It.IsAny<RangeType>())).Returns(new HourCalculator(new Util()));

            var SUT = new EventsService(determineType.Object, validateDate.Object, determineTypeFactory.Object);

            //Act
            var resultado = SUT.SetInfoEventsDisplay(new List<Event>() { new Event() { cNombre = "Test", dtFecha = new DateTime(2019, 01, 28) } });

            //Assert
            Assert.IsTrue(resultado[0].cMensaje != string.Empty);
        }
    }
}
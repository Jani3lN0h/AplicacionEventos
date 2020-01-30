using EventValidator;
using EventValidator.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace EventService.Tests
{
    [TestClass()]
    public class FileServiceUTests
    {
        [TestMethod()]
        public void GetEvents_ArchivoNoExistente_ExcepcionLanzada()
        {
            //Arrange
            var DOCValidateDate = new Mock<IValidateDate>();
            var SUT = new FileService(DOCValidateDate.Object);
            SUT.ReaderFiles = (ruta) => throw new FileNotFoundException();

            //Assert
            Assert.ThrowsException<FileNotFoundException>(()=>SUT.GetEvents("ArchivoNoExistente"));
        }

        [TestMethod()]
        public void GetEvents_SinArchivo_ExcepcionLanzada()
        {
            //Arrange
            var DOCValidateDate = new Mock<IValidateDate>();
            var SUT = new FileService(DOCValidateDate.Object);
            SUT.ReaderFiles = (Nullable) => throw new FileNotFoundException();

            //Assert
            Assert.ThrowsException<FileNotFoundException>(() => SUT.GetEvents("ArchivoNoExistente"));
        }

        [TestMethod()]
        public void GetEvents_LineasExistentes_EventosCorrectos()
        {
            //Arrange
            var DOCValidateDate = new Mock<IValidateDate>();
            DOCValidateDate.Setup(doc => doc.SetValueFecha(It.IsAny<string>())).Returns(DateTime.Now);
            var SUT = new FileService(DOCValidateDate.Object);
            string[] arrEvents = new string[] { "E1, 05/08/2019", "E2, 16/04/2020" };
            SUT.ReaderFiles = (ruta) => arrEvents;

            //Act
            var result = SUT.GetEvents("ArchivoExistente");

            //Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod()]
        public void GetEvents_ArchivoEventoCorrecto_EventoFechaCorrecta()
        {
            //Arrange
            var SUT = new FileService(new ValidateDate());
            string[] arrEvents = new string[] { "E1, 05/08/2019" };
            SUT.ReaderFiles = (ruta) => arrEvents;

            //Act
            var result = SUT.GetEvents("ArchivoExistente");

            //Assert
            Assert.AreEqual(result[0].dtFecha, new DateTime(2019, 08, 05));
        }

        [TestMethod()]
        public void GetEvents_ArchivoEventoCorrecto_EventoNombreCorrecto()
        {
            //Arrange
            var SUT = new FileService(new ValidateDate());
            string[] arrEvents = new string[] { "E1, 05/08/2019" };
            SUT.ReaderFiles = (ruta) => arrEvents;

            //Act
            var result = SUT.GetEvents("ArchivoExistente");

            //Assert
            Assert.AreEqual("E1", result[0].cNombre);
        }

        [TestMethod()]
        public void GetEvents_ArchivoEventoCorrecto_EventoFechaHoraCorrecta()
        {
            //Arrange
            var SUT = new FileService(new ValidateDate());
            string[] arrEvents = new string[] { "E1, 05/08/2019 11:03" };
            SUT.ReaderFiles = (ruta) => arrEvents;

            //Act
            var result = SUT.GetEvents("ArchivoExistente");

            //Assert
            Assert.AreEqual(new DateTime(2019, 08, 05, 11, 03, 0), result[0].dtFecha);
        }

        //[DataRow("05/08/2019 12:05", "HORA")]
        //[DataRow("05/08/2019 10:53", "MINUTO")]
        //[DataRow("08/08/2019 12:05", "DIA")]
        //[DataRow("05/10/2019 12:05", "MES")]
        //[TestMethod()]
        //public void GetEvents_DiferenciaHoras_EventoCalculadoCorrectamente(string dtFechaActual, string cTipoEsperado)
        //{
        //    //Arrange
        //    var SUT = new FileService(new ValidateDate());
        //    string[] arrEvents = new string[] { "E1, 05/08/2019 11:03" };
        //    SUT.ReaderFiles = (ruta) => arrEvents;
        //    SUT.ObtenerFecha = () => Convert.ToDateTime(dtFechaActual);

        //    //Act
        //    var result = SUT.GetEvents("ArchivoExistente");

        //    //Assert
        //    Assert.AreEqual(cTipoEsperado, result[0].cTipo);
        //}

        [TestMethod()]
        public void GetEvents_ArchivoEventoCorrecto_LlamadaValidador()
        {
            //Arrange
            var DOCValidateDate = new Mock<IValidateDate>();
            DOCValidateDate.Setup(doc => doc.SetValueFecha(It.IsAny<string>())).Returns(DateTime.Now);
            var SUT = new FileService(DOCValidateDate.Object);
            string[] arrEvents = new string[] { "E1, 05/08/2019 11:03", "E1, 05/08/2019 11:03" };
            SUT.ReaderFiles = (ruta) => arrEvents;

            //Act
            var result = SUT.GetEvents("ArchivoExistente");

            //Assert
            DOCValidateDate.Verify(doc => doc.SetValueFecha(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod()]
        public void GetEvents_ArchivoEventoCorrecto_VerificarValorRecibido()
        {
            //Arrange
            string valorRecibido = string.Empty;
            var DOCValidateDate = new Mock<IValidateDate>();
            DOCValidateDate.Setup(doc => doc.SetValueFecha(It.IsAny<string>())).Callback<string>((cadena) => valorRecibido = cadena);
            var SUT = new FileService(DOCValidateDate.Object);
            string[] arrEvents = new string[] { "E1,05/08/2019 11:03", "E1,05/08/2019 11:03" };
            SUT.ReaderFiles = (ruta) => arrEvents;

            //Act
            var result = SUT.GetEvents("ArchivoExistente");

            //Assert
            Assert.AreEqual("05/08/2019 11:03", valorRecibido);
        }
    }
}
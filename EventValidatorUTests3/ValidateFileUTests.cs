using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventValidator.Tests
{
    [TestClass()]
    public class ValidateFileUTests
    {

        [DataRow(true)]
        [DataRow(false)]
        [TestMethod()]
        public void ValidarExistenciaArchivo_ArchivoRecibido_ResultadoSegunParametro(bool lExistFile)
        {
            //Arrange
            ValidateFile SUT = new ValidateFile();
            SUT.ValidaArchivo = (ruta) => lExistFile;

            //Act
            var result = SUT.ValidarExistenciaArchivo("RutaArchivo");

            //Assert
            Assert.AreEqual(lExistFile, result);
        }
    }
}
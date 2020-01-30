using EventValidator.Interfaces;
using System;
using System.IO;
namespace EventValidator
{
    public class ValidateFile: IValidateFile
    {
        public Func<string, bool> ValidaArchivo { get; set; }

        public ValidateFile()
        {
            ValidaArchivo = (ruta) => File.Exists(ruta);
        }

        public bool ValidarExistenciaArchivo(string cRuta)
        {
            bool lExisteArchivo = ValidaArchivo(cRuta);

            return lExisteArchivo;
        }
    }
}

using System.IO;
namespace EventValidator
{
    public class ValidateFile
    {
        public bool ValidarExistenciaArchivo(string _cRuta)
        {
            bool lExisteArchivo = File.Exists(_cRuta);

            return lExisteArchivo;
        }
    }
}

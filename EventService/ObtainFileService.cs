using EventService.Interfaces;
using System;

namespace EventService
{
    public class ObtainFileService : IObtainFileService
    {
        public string ObtainRouteFile()
        {
            Console.WriteLine("Escribe la ruta del archivo: ");
            return Console.ReadLine();
        }
    }
}
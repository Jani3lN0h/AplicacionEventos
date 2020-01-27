using System;

namespace EventRepository
{
    public class Event
    {
        public string cNombre { get; set; }

        public DateTime dtFecha { get; set; }

        public string cMensaje { get; set; }

        public int iDiferencia { get; set; }

        public string cTipo { get; set; }
    }
}

using System;

namespace cajero
{
    class Banco : Cliente  // clase derivada (hija)
    {
        public string nombreBanco;  // campo nombre del banco

        public Banco(string nombre, long cedula, string nombreBanco) : base(nombre, cedula)
        {
            this.nombreBanco = nombreBanco;
        }
    }
}

using System;
using System.Collections.Generic;

namespace cajero

{
    class Cliente  // clase base (padre)
    {
        public string nombre;  // campo nombre del cliente
        public long cedula;

        public Cliente(string nombre, long cedula)
        {
            this.nombre = nombre;
            this.cedula = cedula;
        }
    }

}

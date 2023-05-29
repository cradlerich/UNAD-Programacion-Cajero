
using System;
using System.Collections.Generic;

namespace cajero

{
    class BaseDatosCajero
    {
        public List<Cuenta> cuentas; // Lista de cuentas
        public BaseDatosCajero()
        {
            cuentas = new List<Cuenta>();
            cuentas.Add(new Cuenta("Ana Lucia Castro", 1222335469, "Banco XYZ", 333777847999, 3000000, 1234, 2000));
            cuentas.Add(new Cuenta("Jose Ricardo Castro Gonzalez", 80199527, "Banco XYZ", 122229874065, 15000000, 1234, 800));
            cuentas.Add(new Cuenta("Elsa Badillo Plazas", 1020753345, "Banco ABC", 111222333444, 250000, 9004, 20));
            cuentas.Add(new Cuenta("Roberto Bolanos Gomez", 19435663, "Banco ABC", 333333444444, 7000000, 7965, 500));
            cuentas.Add(new Cuenta("David Gomez Hurtado", 70998234, "Banco ZZZ", 828282121212, 1500000, 7766, 230));
            cuentas.Add(new Cuenta("Ana Lucia Castro", 1222335469,"Banco ZZZ", 999000000555, 10000000, 1234, 400));
        }
    }
}

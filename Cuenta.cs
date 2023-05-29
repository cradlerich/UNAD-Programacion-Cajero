using System;
using cajero.Util;

namespace cajero

{
    class Cuenta : Banco
    {
        public long numeroCuenta; // campo numeroCuenta de la cuenta
        public double saldo;
        public int clave, puntos;

        public Cuenta(string nombre, long cedula, string nombreBanco, long numeroCuenta, double saldo, int clave, int puntos) : base(nombre, cedula, nombreBanco)
        {
            this.numeroCuenta = numeroCuenta;
            this.saldo = saldo;
            this.clave = clave;
            this.puntos = puntos;
        }
        public void bienvenido()
        {
            Console.WriteLine($"Bienvenido(a) al Cajero UNAD, no olvide que sus operaciones son premiadas en puntos ViveColombia.");
            Console.WriteLine($"Hemos detectado que ha ingresado el usuario(a) {nombre} identificado(a) con CC:{cedula}.");
            Console.WriteLine($"Su cuenta pertenece al {nombreBanco}. Su número de cuenta es {numeroCuenta}.");
        }

        public bool verificarCuenta(long numero, int contraseña)
        {
            return numeroCuenta == numero && clave == contraseña;
        }
        public bool cuentaTransferencia(long numero)
        {
            return numeroCuenta == numero;
        }
    }
}

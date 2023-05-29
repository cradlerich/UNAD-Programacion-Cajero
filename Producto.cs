using System;
using System.IO;
using cajero.Util;

namespace cajero
{
    public interface IOperacion
    {
        string Operation();
        void OperationATM(long numeroIngresado);
    }
    class ConsultaSaldo : IOperacion
    {
        public void OperationATM(long numeroIngresado)
        {
            Printer.WriteTitle("CAJERO UNAD - MODULO CONSULTA SALDO");
            BaseDatosCajero baseDatos = new BaseDatosCajero();

            foreach (Cuenta cuenta in baseDatos.cuentas)
            {
                if (cuenta.numeroCuenta == numeroIngresado)
                {
                    double saldoActual = cuenta.saldo;
                    string SaldoPesos = saldoActual.ToString("C");
                    Printer.WriteResult(SaldoPesos);
                    break; // Termina el bucle una vez que se encuentra el saldo
                }
            }
        }
        public string Operation()
        {
            return $"Consulta Saldo: ";
        }
    }

    
    class Retiros : IOperacion
    {
        double valorRetiro, retirosDia, saldoActual;
        public string Operation()
        {
            return $"Retiro dinero cajero de la cuenta";
        }
        public void OperationATM(long numeroIngresado)
        {
            Printer.WriteTitle("CAJERO UNAD - MODULO RETIROS");
            Console.WriteLine("\nIntroduce la cantidad de dinero a retirar\nRecuerdad que el monto máximo diario es de $2.000.000");
            double valorRetiro = Convert.ToInt64(Console.ReadLine());
            BaseDatosCajero baseDatos = new BaseDatosCajero();

            foreach (Cuenta cuenta in baseDatos.cuentas)
            {
                if (cuenta.numeroCuenta == numeroIngresado)
                {
                    string name = cuenta.nombre;
                    long identificacion = cuenta.cedula;
                    string banco = cuenta.nombreBanco;
                    long cuentabancaria = cuenta.numeroCuenta;
                    double saldoActual = cuenta.saldo;
                    int pass = cuenta.clave;
                    int puntos = cuenta.puntos;
                    if (valorRetiro <= 2000000)
                    {
                        if(valorRetiro<=saldoActual)
                        {
                            double retirosDia = saldoActual - valorRetiro;
                            string retire = retirosDia.ToString("C");
                            string valorRetirado = valorRetiro.ToString("C");
                            Printer.WriteResult($"Valor retirado: {valorRetirado}");
                            Printer.WriteResult($"Saldo disponible: {retire}");

                        }
                        else
                        {
                            Printer.WriteResult("Saldo insuficiente para realizar el retiro");
                        }
                    }
                    else
                    {
                        Printer.WriteResult("El valor de retiro excede el monto máximo diario");
                    }
                }
            }
        }
    }
    class Transferencias : IOperacion
    {
        public string SaldoPesos { get; private set; }
        public string Operation()
        {
            return $"Transferencias: ";
        }
        public void OperationATM(long numeroIngresado)
        {
            Printer.WriteTitle("CAJERO UNAD - MODULO TRANSFERENCIAS");
            Console.WriteLine("\nIntroduce la cuenta a la cual se va a transferir el dinero");
            long cuentaDestino = Convert.ToInt64(Console.ReadLine());
            BaseDatosCajero baseDatos = new BaseDatosCajero();

            foreach (Cuenta cuenta in baseDatos.cuentas)
            {
                if (cuenta.numeroCuenta == numeroIngresado)
                {
                    string banco = cuenta.nombreBanco;
                    double saldo = cuenta.saldo;
                    Console.WriteLine($"Solo transacciones permitidas para el {banco}");
                    string banDestino = validacion(cuentaDestino);
                    Console.WriteLine($"El banco destino es el {banDestino}\n");
                    if (banDestino == banco)
                    {
                        Console.WriteLine($"Introduzca valor de transferencia: ");
                        double transDestino = Convert.ToInt64(Console.ReadLine());
                        if (transDestino <= saldo)
                        {
                            double saldoActual= saldo - transDestino;
                            string restransfer = transDestino.ToString("C");
                            string resultadoSaldo = saldoActual.ToString("C");
                            Printer.WriteResult($"Transferencia exitosa a la cuenta {cuentaDestino}, por un valor de {restransfer}. Su saldo es de {resultadoSaldo}");
                        }
                        else
                        {
                            Printer.WriteResult($"El valor a transferir es superior a su saldo");
                        }
                    }
                    else
                    {
                        Printer.WriteResult($"Recuerde solo transancciones entre cuentas del mismo banco");
                    }
                }
            }
        }
        public virtual string validacion(long cuentaDestino)
        {
            BaseDatosCajero baseDatos = new BaseDatosCajero();
            try
            {
                bool cuentaEncontrada = false;

                foreach (Cuenta cuenta in baseDatos.cuentas)
                {
                    if (cuenta.cuentaTransferencia(cuentaDestino))
                    {
                        cuentaEncontrada = true;
                        string banDestino = cuenta.nombreBanco;
                        return banDestino;
                    }
                }
                if (!cuentaEncontrada)
                {
                    Printer.WriteResult("Lo sentimos, la cuenta o contraseña ingresada es inválida");
                }

            }
            catch (FormatException)
            {
                Printer.WriteResult("Error!!: Debes ingresar un número de cuenta válido; intenta más tarde");
            }
            catch (ArgumentException ex)
            {
                Printer.WriteResult(ex.Message);
            }
            return null;
        }
    }
    class ConsultaPuntos : IOperacion
    {
        public string Operation()
        {
            return $"Consulta Puntos";
        }
        public void OperationATM(long numeroIngresado)
        {
            Printer.WriteTitle("CAJERO UNAD - MODULO CONSULTA PUNTOS");
            BaseDatosCajero baseDatos = new BaseDatosCajero();
            foreach (Cuenta cuenta in baseDatos.cuentas)
            {
                if (cuenta.numeroCuenta == numeroIngresado)
                {
                    int puntaje = cuenta.puntos;
                    Printer.WriteResult($"Tienes acumulados {puntaje} pts ViveColombia");
                    break; // Termina el bucle una vez que se encuentra el saldo
                }
            }
        }
    }
    class CanjePuntos : IOperacion
    {
        public string Operation()
        {
            return $"Canje Puntos";
        }
        public void OperationATM(long numeroIngresado)
        {
            Printer.WriteTitle("CAJERO UNAD - MODULO CANJE PUNTOS");
            Console.WriteLine("Por cada puntocanjeas $100");
            BaseDatosCajero baseDatos = new BaseDatosCajero();
            foreach (Cuenta cuenta in baseDatos.cuentas)
            {
                if (cuenta.numeroCuenta == numeroIngresado)
                {
                    double saldoActual = cuenta.saldo;
                    int puntaje = cuenta.puntos;
                    double canje = puntaje * 100;
                    string canjeado = canje.ToString("C");
                    double saldoDouble = saldoActual + canje;
                    string saldoFinal = saldoDouble.ToString("C");
                    Printer.WriteResult($"Canjeaste {puntaje}, por {canjeado}, tu saldo es de {saldoFinal}");
                    break; // Termina el bucle una vez que se encuentra el saldo
                }
            }
        }
    }
}
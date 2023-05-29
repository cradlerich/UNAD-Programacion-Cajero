using System;
using cajero.Util;

namespace cajero
{
    class CajeroMenu
    {
        public void Main()
        {
            bool salir = false;
            while(!salir)
            {
                try
                {
                    BaseDatosCajero baseDatos = new BaseDatosCajero();
                    Printer.WriteTitle("CAJERO UNAD -- BIENVENIDOS");
                    Console.Write("\nIntroduce tu número de cuenta: ");
                    long numeroIngresado = Convert.ToInt64(Console.ReadLine());

                    Console.Write("Introduce tu contraseña: ");
                    int contraseñaIngresada = Convert.ToInt32(Console.ReadLine());

                    bool cuentaEncontrada = false;

                    foreach (Cuenta cuenta in baseDatos.cuentas)
                    {
                        if (cuenta.verificarCuenta(numeroIngresado, contraseñaIngresada))
                        {
                            Printer.WriteTitle("CAJERO UNAD -- MENU OPERACIONES");
                            cuenta.bienvenido();
                            cuentaEncontrada = true;
                            Printer.WriteResult("Escoja el tipo de operación a realizar:");
                            Console.WriteLine($"1. Consulta Saldo.\n2. Retiro Cajero.\n3. Transferencias.\n4. Consulta puntos ViveColombia.\n5. Canje puntos ViveColombia.");
                            int chooseMethod;
                            chooseMethod = Convert.ToInt16(Console.ReadLine());

                            switch (chooseMethod)
                            {
                                case 1:
                                    ClientCode(new ConsultaSaldoCreator(), numeroIngresado);
                                    break;
                                case 2:
                                    ClientCode(new RetirosCreator(), numeroIngresado);
                                    break;
                                case 3:
                                    ClientCode(new TransferenciasCreator(), numeroIngresado);
                                    break;
                                case 4:
                                    ClientCode(new ConsultaPuntosCreator(), numeroIngresado);
                                    break;
                                case 5:
                                    ClientCode(new CanjePuntosCreator(), numeroIngresado);
                                    break;
                                default:
                                    throw new ArgumentException("Opción inválida");
                            }
                        }
                    }
                    if (!cuentaEncontrada)
                    {
                        Printer.WriteResult("Lo sentimos, la cuenta o contraseña ingresada es inválida");
                    }
                    Console.WriteLine("\n¿Desea realizar otra operación? (S/N)");
                    string respuesta = Console.ReadLine();

                    if (respuesta.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        salir = true;  // Establecer la variable de salida para finalizar el ciclo
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
                catch (System.OverflowException)
                {
                    Printer.WriteResult("Error!!! Numero invalido");
                }

            }
        }
        public void ClientCode(Creator creator, long numeroIngresado)
        {
            Console.WriteLine("Realizando la operación," +
                " cajero UNAD.\n" + creator.SomeOperation());
            
            IOperacion movimiento = creator.FactoryMethod();
            movimiento.OperationATM(numeroIngresado);
        }
    }
}
using static System.Console;

namespace cajero.Util

{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '='));
        }
        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 63;
            DrawLine(tamaño);
            DrawLine(tamaño);
            WriteLine($"|\t\t**\t\t{titulo}\t\t**\t\t|");
            DrawLine(tamaño);
            DrawLine(tamaño);
        }
        public static void WriteResult(string resultado)
        {
            var tamaño = resultado.Length + 4;
            DrawLine(tamaño);
            WriteLine($" {resultado} ");
            DrawLine(tamaño);
        }
    }
}
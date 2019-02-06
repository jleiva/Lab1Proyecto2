using System;

namespace ProcesarApi.Models
{
    public class Operacion
    {
        public String TipoOperacion { get; set; }
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public double Resultado { get; set; }

        public double Procesar(Operacion op)
        {
            switch (op.TipoOperacion)
            {
                case "Suma":
                    op.Resultado = op.Valor1 + op.Valor2;
                    return op.Resultado;
                case "Resta":
                    op.Resultado = op.Valor1 - op.Valor2;
                    return op.Resultado;
                case "Division":
                    op.Resultado = op.Valor1 / op.Valor2;
                    return op.Resultado;
                case "Multiplicacion":
                    op.Resultado = op.Valor1 * op.Valor2;
                    return op.Resultado;
                default:
                    return 0;
            }
        }
    }
}
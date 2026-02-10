using System;

namespace CalculadoraForms
{
    internal class Calculadora
    {
        //atributos
        private decimal numeros;
        private string operador;
        //propiedades
        public decimal Numeros
        {
            get { return numeros; }
            set { numeros = value; }
        }
        public string Operador
        {
            get { return operador; }
            set { operador = value; }
        }
        //constructor
        public Calculadora()
        {
            this.numeros = 0m;
            this.operador = "";
        }
        public Calculadora(decimal numeros, string operador)
        {
            this.numeros = numeros;
            this.operador = operador;
        }
        //metodos
        public decimal Sumar(decimal num1, decimal num2) => num1 + num2;
        public decimal Restar(decimal num1, decimal num2) => num1 - num2;
        public decimal Multiplicar(decimal num1, decimal num2) => num1 * num2;
        public decimal Dividir(decimal num1, decimal num2)
        {
            if (num2 != 0m)
            {
                return num1 / num2;
            }
            else
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }
        }
        public decimal Potencia(decimal @base, decimal exponente)
        {
            // Si exponente es entero, calcular exactamente con decimal
            if (decimal.Truncate(exponente) == exponente)
            {
                long exp;
                try
                {
                    exp = (long)exponente;
                }
                catch
                {
                    throw new InvalidOperationException("Exponente entero demasiado grande.");
                }

                if (exp == 0) return 1m;
                bool negativo = exp < 0;
                exp = Math.Abs(exp);

                decimal result = 1m;
                decimal b = @base;
                while (exp > 0)
                {
                    if ((exp & 1) == 1) result *= b;
                    b *= b;
                    exp >>= 1;
                }

                if (negativo)
                {
                    if (result == 0m) throw new DivideByZeroException("División por cero en potencia con exponente negativo.");
                    return 1m / result;
                }

                return result;
            }

            // Para exponentes no enteros, usar Math.Pow como fallback (pierde parte de la precisión)
            double dblBase = (double)@base;
            double dblExp = (double)exponente;
            double dblRes = Math.Pow(dblBase, dblExp);
            return Convert.ToDecimal(dblRes);
        }
        public decimal Raiz(decimal num1)
        {
            if (num1 < 0m) throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo.");
            if (num1 == 0m) return 0m;

            // Newton-Raphson para sqrt en decimal
            decimal x0 = (decimal)Math.Sqrt((double)num1); // buena aproximación inicial
            decimal tolerance = 1e-28m;
            for (int i = 0; i < 100; i++)
            {
                decimal x1 = 0.5m * (x0 + num1 / x0);
                if (Math.Abs((double)(x1 - x0)) < (double)tolerance) return x1;
                x0 = x1;
            }
            return x0;
        }
        public decimal Porcentaje(decimal num1, decimal num2) => (num1 * num2) / 100m;
        public decimal InvertirSigno(decimal num1) => -num1;
    }
}

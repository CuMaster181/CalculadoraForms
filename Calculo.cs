using System;

namespace CalculadoraForms
{
    internal class Calculo
    {
        //atributos
        private decimal resultado;
        //propiedades
        public decimal Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        //constructor
        public Calculo()
        {
            this.resultado = 0m;
        }
        public Calculo(decimal resultado)
        {
            this.resultado = resultado;
        }
        //metodos
        public decimal RealizarOperacion(decimal num1, decimal num2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            return operador switch
            {
                "+" => calculadora.Sumar(num1, num2),
                "-" => calculadora.Restar(num1, num2),
                "*" => calculadora.Multiplicar(num1, num2),
                "/" => calculadora.Dividir(num1, num2),
                _ => throw new InvalidOperationException("Operador no válido."),
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraForms
{
    internal class Calculo
    {
        //atributos
        private double resultado;
        //propiedades
        public double Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        //constructor
        public Calculo()
        {
            this.resultado = 0;
        }
        public Calculo(double resultado)
        {
                this.resultado = resultado;
        }
        //metodos
        public double RealizarOperacion(double num1, double num2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            switch (operador)
            {
                case "+":
                    return calculadora.Sumar(num1, num2);
                case "-":
                    return calculadora.Restar(num1, num2);
                case "*":
                    return calculadora.Multiplicar(num1, num2);
                case "/":
                    return calculadora.Dividir(num1, num2);
                default:
                    throw new InvalidOperationException("Operador no válido.");
            }
        }
    }
}

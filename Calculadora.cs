using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraForms
{
    internal class Calculadora
    {
        //atributos
        private double numeros;
        private string operador;
        //propiedades
        public double Numeros
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
            this.numeros = 0;
            this.operador = "";
        }
        public Calculadora(double numeros, string operador)
        {
            this.numeros = numeros;
            this.operador = operador;

        }
        //metodos
        public double Sumar(double num1, double num2)
        {
                return num1 + num2;
        }
        public double Restar(double num1, double num2)
        {
                return num1 - num2;
        }
        public double Multiplicar(double num1, double num2)
        {
                return num1 * num2;
        }
        public double Dividir(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }
        }
        public double Potencia(double num1, double num2)
        {
                return Math.Pow(num1, num2);
        }
        public double Raiz(double num1)
        {
             if (num1 >= 0)
             {
                return Math.Sqrt(num1);
             }
             else
             {
                throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo.");
             }
        }
        public double Porcentaje(double num1, double num2)
        {
                return (num1 * num2) / 100;
        }
        public double InvertirSigno(double num1)
        {
                return -num1;
        }
    }
}

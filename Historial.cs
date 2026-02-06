using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraForms
{
    internal class Historial
    {
        //atributos
        private List<string> operaciones;
        //propiedades
        public List<string> Operaciones
        {
            get { return operaciones; }
            set { operaciones = value; }
        }
        //constructor
        public Historial()
        {
            this.operaciones = new List<string>();
        }
        public Historial(List<string> operaciones)
        {
            this.operaciones = operaciones;
        }
        //metodos
        public void AgregarOperacion(string operacion)
        {
            operaciones.Add(operacion);
        }
        public void LimpiarHistorial()
        {
            operaciones.Clear();
        }
    }
}

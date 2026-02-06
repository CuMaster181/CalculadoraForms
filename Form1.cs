using System;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora = new Calculadora();
        private Historial historial = new Historial();
        private double? firstNumber = null;
        private string operador = "";
        private bool nuevaEntrada = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            if (nuevaEntrada || txtDisplay.Text == "0")
            {
                txtDisplay.Text = btn.Text;
                nuevaEntrada = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (nuevaEntrada)
            {
                txtDisplay.Text = "0,";
                nuevaEntrada = false;
                return;
            }

            if (!txtDisplay.Text.Contains(","))
                txtDisplay.Text += ",";
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            try
            {
                if (double.TryParse(txtDisplay.Text, out double value))
                {
                    if (firstNumber == null)
                    {
                        firstNumber = value;
                    }
                    else if (!string.IsNullOrEmpty(operador) && !nuevaEntrada)
                    {
                        // encadenar operaciones (ej: 2 + 3 + 4)
                        double result = RealizarOperacion((double)firstNumber, value, operador);
                        firstNumber = result;
                        txtDisplay.Text = result.ToString();
                    }
                }

                operador = btn.Text switch
                {
                    "÷" => "/",
                    "×" => "*",
                    "?" => "-",
                    "+" => "+",
                    _ => btn.Text
                };

                nuevaEntrada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetCalculator();
            }
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstNumber == null || string.IsNullOrEmpty(operador))
                    return;

                if (!double.TryParse(txtDisplay.Text, out double secondNumber))
                    return;

                double result = RealizarOperacion((double)firstNumber, secondNumber, operador);
                string entry = $"{firstNumber} {operador} {secondNumber} = {result}";
                historial.AgregarOperacion(entry);
                lstHistory.Items.Insert(0, entry);

                txtDisplay.Text = result.ToString();
                firstNumber = null;
                operador = "";
                nuevaEntrada = true;
            }
            catch (DivideByZeroException dbz)
            {
                MessageBox.Show(dbz.Message, "División por cero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetCalculator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetCalculator();
            }
        }

        private double RealizarOperacion(double num1, double num2, string op)
        {
            // Usa Calculo para + - * /
            var calculo = new Calculo();
            return op switch
            {
                "+" => calculo.RealizarOperacion(num1, num2, "+"),
                "-" => calculo.RealizarOperacion(num1, num2, "-"),
                "*" => calculo.RealizarOperacion(num1, num2, "*"),
                "/" => calculo.RealizarOperacion(num1, num2, "/"),
                _ => throw new InvalidOperationException("Operador no soportado.")
            };
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            firstNumber = null;
            operador = "";
            nuevaEntrada = true;
        }

        private void BtnSign_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double value))
            {
                double inverted = calculadora.InvertirSigno(value);
                txtDisplay.Text = inverted.ToString();
            }
        }

        private void BtnPercent_Click(object sender, EventArgs e)
        {
            if (firstNumber != null && double.TryParse(txtDisplay.Text, out double value))
            {
                // porcentaje relativo al primer número: (first * value) / 100
                double result = calculadora.Porcentaje((double)firstNumber, value);
                txtDisplay.Text = result.ToString();
                string entry = $"{firstNumber} % {value} = {result}";
                historial.AgregarOperacion(entry);
                lstHistory.Items.Insert(0, entry);
                nuevaEntrada = true;
            }
            else if (double.TryParse(txtDisplay.Text, out double single))
            {
                // porcentaje simple de 100
                double result = calculadora.Porcentaje(single, 100);
                txtDisplay.Text = result.ToString();
                nuevaEntrada = true;
            }
        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double value))
            {
                try
                {
                    double result = calculadora.Raiz(value);
                    string entry = $"?({value}) = {result}";
                    historial.AgregarOperacion(entry);
                    lstHistory.Items.Insert(0, entry);
                    txtDisplay.Text = result.ToString();
                    nuevaEntrada = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnPow_Click(object sender, EventArgs e)
        {
            // Preparar potencia: guarda el primer número y establece operador "pow"
            if (double.TryParse(txtDisplay.Text, out double value))
            {
                firstNumber = value;
                operador = "pow";
                nuevaEntrada = true;
            }
        }

        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            historial.LimpiarHistorial();
            lstHistory.Items.Clear();
        }
    }
}

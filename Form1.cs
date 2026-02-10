using System;
using System.Globalization;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora = new Calculadora();
        private Historial historial = new Historial();
        private decimal? firstNumber = null;
        private string operador = "";
        private bool nuevaEntrada = true;
        private readonly string decimalSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

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
                txtDisplay.Text = "0" + decimalSep;
                nuevaEntrada = false;
                return;
            }

            if (!txtDisplay.Text.Contains(decimalSep))
                txtDisplay.Text += decimalSep;
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            try
            {
                if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
                {
                    if (firstNumber == null)
                    {
                        firstNumber = value;
                    }
                    else if (!string.IsNullOrEmpty(operador) && !nuevaEntrada)
                    {
                        decimal result = RealizarOperacion((decimal)firstNumber, value, operador);
                        firstNumber = result;
                        txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
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

                if (!decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal secondNumber))
                    return;

                decimal result;
                if (operador == "pow")
                {
                    result = calculadora.Potencia((decimal)firstNumber, secondNumber);
                }
                else
                {
                    result = RealizarOperacion((decimal)firstNumber, secondNumber, operador);
                }

                string entry = $"{firstNumber} {operador} {secondNumber} = {result}";
                historial.AgregarOperacion(entry);
                lstHistory.Items.Insert(0, entry);

                txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
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

        private decimal RealizarOperacion(decimal num1, decimal num2, string op)
        {
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

        private void BtnClear_Click(object sender, EventArgs e) => ResetCalculator();

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            firstNumber = null;
            operador = "";
            nuevaEntrada = true;
        }

        private void BtnSign_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
            {
                decimal inverted = calculadora.InvertirSigno(value);
                txtDisplay.Text = inverted.ToString(CultureInfo.CurrentCulture);
            }
        }

        private void BtnPercent_Click(object sender, EventArgs e)
        {
            if (firstNumber != null && decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
            {
                decimal result = calculadora.Porcentaje((decimal)firstNumber, value);
                txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
                string entry = $"{firstNumber} % {value} = {result}";
                historial.AgregarOperacion(entry);
                lstHistory.Items.Insert(0, entry);
                nuevaEntrada = true;
            }
            else if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal single))
            {
                decimal result = calculadora.Porcentaje(single, 100m);
                txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
                nuevaEntrada = true;
            }
        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
            {
                try
                {
                    decimal result = calculadora.Raiz(value);
                    string entry = $"?({value}) = {result}";
                    historial.AgregarOperacion(entry);
                    lstHistory.Items.Insert(0, entry);
                    txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
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
            if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
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

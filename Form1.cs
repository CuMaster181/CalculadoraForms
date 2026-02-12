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
                    "−" => "-",
                    "+" => "+",
                    _ => btn.Text
                };

                lblOperation.Text = $"{firstNumber} {btn.Text}";

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

                string entry = $"{firstNumber} {(operador == "pow" ? "xʸ" : operador)} {secondNumber} = {result}";
                historial.AgregarOperacion(entry);
                lstHistory.Items.Insert(0, entry);

                txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
                firstNumber = null;
                operador = "";
                lblOperation.Text = "";
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

        // Ahora BtnClear borra un carácter a la vez; si ya está en nueva entrada o es "0" hace reset completo.
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (nuevaEntrada || txtDisplay.Text == "0")
            {
                ResetCalculator();
                return;
            }

            string text = txtDisplay.Text;

            // Si sólo queda un carácter, volvemos a "0"
            if (text.Length <= 1)
            {
                txtDisplay.Text = "0";
                nuevaEntrada = true;
                return;
            }

            // Eliminar último carácter
            text = text[..^1];

            // Si queda sólo un signo negativo o vacío, mostrar "0"
            if (string.IsNullOrEmpty(text) || text == "-" )
            {
                txtDisplay.Text = "0";
            }
            else
            {
                txtDisplay.Text = text;
            }
        }

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            firstNumber = null;
            operador = "";
            lblOperation.Text = "";
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
            // Comportamiento:
            // - Si no hay primer operando => divide el valor actual entre 100 (10% -> 0.1)
            // - Si hay primer operando:
            //     * Para + y - : el segundo operando se interpreta como porcentaje del primero (A + B% => B = A * B / 100)
            //     * Para * y / : el segundo operando se interpreta como valor/100 (A * B% => A * (B/100))
            // Se actualiza la pantalla con el valor convertido y se añade entrada al historial.
            if (!decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
                return;

            decimal percentValue;
            string entry;

            if (firstNumber != null && !string.IsNullOrEmpty(operador))
            {
                // operador esperado: "+", "-", "*", "/", "pow"
                if (operador == "+" || operador == "-")
                {
                    // porcentaje relativo al primer número
                    percentValue = calculadora.Porcentaje((decimal)firstNumber, value); // first * value / 100
                    txtDisplay.Text = percentValue.ToString(CultureInfo.CurrentCulture);
                    lblOperation.Text = $"{firstNumber} {operador} {value}%";
                    entry = $"{firstNumber} {operador} {value}% = {percentValue}";
                }
                else if (operador == "*" || operador == "/")
                {
                    // porcentaje como fracción (value/100)
                    percentValue = calculadora.Porcentaje(value, 1m); // value / 100
                    txtDisplay.Text = percentValue.ToString(CultureInfo.CurrentCulture);
                    lblOperation.Text = $"{firstNumber} {operador} {value}%";
                    entry = $"{firstNumber} {operador} {value}% -> {percentValue}";
                }
                else if (operador == "pow")
                {
                    // Para potencia no tiene sentido porcentaje relativo; tratamos como value/100
                    percentValue = calculadora.Porcentaje(value, 1m);
                    txtDisplay.Text = percentValue.ToString(CultureInfo.CurrentCulture);
                    lblOperation.Text = $"{firstNumber} xʸ {value}%";
                    entry = $"{firstNumber} xʸ {value}% -> {percentValue}";
                }
                else
                {
                    // fallback: dividir entre 100
                    percentValue = calculadora.Porcentaje(value, 1m);
                    txtDisplay.Text = percentValue.ToString(CultureInfo.CurrentCulture);
                    lblOperation.Text = $"{value}%";
                    entry = $"{value}% = {percentValue}";
                }
            }
            else
            {
                // sin primer operando -> simple porcentaje (valor/100)
                percentValue = calculadora.Porcentaje(value, 1m); // value / 100
                txtDisplay.Text = percentValue.ToString(CultureInfo.CurrentCulture);
                lblOperation.Text = $"{value}%";
                entry = $"{value}% = {percentValue}";
            }

            historial.AgregarOperacion(entry);
            lstHistory.Items.Insert(0, entry);
            nuevaEntrada = true;
        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDisplay.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
            {
                try
                {
                    decimal result = calculadora.Raiz(value);
                    string entry = $"√({value}) = {result}";
                    historial.AgregarOperacion(entry);
                    lstHistory.Items.Insert(0, entry);
                    txtDisplay.Text = result.ToString(CultureInfo.CurrentCulture);
                    lblOperation.Text = ""; // limpiar etiqueta en operación unaria
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
                lblOperation.Text = $"{firstNumber} xʸ";
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

namespace CalculadoraForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnPercent;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnSqrt;
        private System.Windows.Forms.Button btnPow;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnClearHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnSqrt = new System.Windows.Forms.Button();
            this.btnPow = new System.Windows.Forms.Button();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(320, 39);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 62);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 40);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(93, 62);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 40);
            this.btnSign.TabIndex = 2;
            this.btnSign.Text = "±";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.BtnSign_Click);
            // 
            // btnPercent
            // 
            this.btnPercent.Location = new System.Drawing.Point(174, 62);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(75, 40);
            this.btnPercent.TabIndex = 3;
            this.btnPercent.Text = "%";
            this.btnPercent.UseVisualStyleBackColor = true;
            this.btnPercent.Click += new System.EventHandler(this.BtnPercent_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.Location = new System.Drawing.Point(255, 62);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(75, 40);
            this.btnDiv.TabIndex = 4;
            this.btnDiv.Text = "÷";
            this.btnDiv.UseVisualStyleBackColor = true;
            this.btnDiv.Click += new System.EventHandler(this.ButtonOperator_Click);
            // 
            // first row digits and operators
            // 
            this.btn7.Location = new System.Drawing.Point(12, 108);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 40);
            this.btn7.TabIndex = 5;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btn8.Location = new System.Drawing.Point(93, 108);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 40);
            this.btn8.TabIndex = 6;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btn9.Location = new System.Drawing.Point(174, 108);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 40);
            this.btn9.TabIndex = 7;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btnMul.Location = new System.Drawing.Point(255, 108);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(75, 40);
            this.btnMul.TabIndex = 8;
            this.btnMul.Text = "×";
            this.btnMul.UseVisualStyleBackColor = true;
            this.btnMul.Click += new System.EventHandler(this.ButtonOperator_Click);
            // 
            // second row
            // 
            this.btn4.Location = new System.Drawing.Point(12, 154);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 40);
            this.btn4.TabIndex = 9;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btn5.Location = new System.Drawing.Point(93, 154);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 40);
            this.btn5.TabIndex = 10;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btn6.Location = new System.Drawing.Point(174, 154);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 40);
            this.btn6.TabIndex = 11;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btnSub.Location = new System.Drawing.Point(255, 154);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(75, 40);
            this.btnSub.TabIndex = 12;
            this.btnSub.Text = "−";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.ButtonOperator_Click);
            // 
            // third row
            // 
            this.btn1.Location = new System.Drawing.Point(12, 200);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 40);
            this.btn1.TabIndex = 13;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btn2.Location = new System.Drawing.Point(93, 200);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 40);
            this.btn2.TabIndex = 14;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btn3.Location = new System.Drawing.Point(174, 200);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 40);
            this.btn3.TabIndex = 15;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btnAdd.Location = new System.Drawing.Point(255, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 40);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.ButtonOperator_Click);
            // 
            // bottom row
            // 
            this.btn0.Location = new System.Drawing.Point(12, 246);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(156, 40);
            this.btn0.TabIndex = 17;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            this.btnDot.Location = new System.Drawing.Point(174, 246);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(75, 40);
            this.btnDot.TabIndex = 18;
            this.btnDot.Text = ",";
            this.btnDot.UseVisualStyleBackColor = true;
            this.btnDot.Click += new System.EventHandler(this.BtnDot_Click);
            // 
            this.btnEqual.Location = new System.Drawing.Point(255, 246);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(75, 40);
            this.btnEqual.TabIndex = 19;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.BtnEqual_Click);
            // 
            // sqrt and pow
            // 
            this.btnSqrt.Location = new System.Drawing.Point(12, 292);
            this.btnSqrt.Name = "btnSqrt";
            this.btnSqrt.Size = new System.Drawing.Size(156, 34);
            this.btnSqrt.TabIndex = 20;
            this.btnSqrt.Text = "√";
            this.btnSqrt.UseVisualStyleBackColor = true;
            this.btnSqrt.Click += new System.EventHandler(this.BtnSqrt_Click);
            // 
            this.btnPow.Location = new System.Drawing.Point(174, 292);
            this.btnPow.Name = "btnPow";
            this.btnPow.Size = new System.Drawing.Size(75, 34);
            this.btnPow.TabIndex = 21;
            this.btnPow.Text = "xʸ";
            this.btnPow.UseVisualStyleBackColor = true;
            this.btnPow.Click += new System.EventHandler(this.BtnPow_Click);
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 15;
            this.lstHistory.Location = new System.Drawing.Point(338, 12);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(230, 289);
            this.lstHistory.TabIndex = 22;
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Location = new System.Drawing.Point(338, 307);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(230, 34);
            this.btnClearHistory.TabIndex = 23;
            this.btnClearHistory.Text = "Limpiar historial";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.BtnClearHistory_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(580, 340);
            this.Controls.Add(this.btnClearHistory);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.btnPow);
            this.Controls.Add(this.btnSqrt);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnPercent);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

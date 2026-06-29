using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double runningTotal = 0;
        private string lastOperator = "+";
        private bool clearOnNextDigit = false;

        TextBox txtDisplay;

        public Form1()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            this.Width = 300;
            this.Height = 400;
            this.Text = "Calculator";

            txtDisplay = new TextBox();
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.Font = new System.Drawing.Font("Segoe UI", 20);
            txtDisplay.Top = 10;
            txtDisplay.Left = 10;
            txtDisplay.Width = 260;
            this.Controls.Add(txtDisplay);

            // -------------------------
            // DIGIT BUTTONS (1–9)
            // -------------------------
            string[] digitButtons =
            {
                "7","8","9",
                "4","5","6",
                "1","2","3"
            };

            int x = 10, y = 70;
            int col = 0;

            foreach (string b in digitButtons)
            {
                Button btn = new Button();
                btn.Text = b;
                btn.Width = 60;
                btn.Height = 50;
                btn.Left = x;
                btn.Top = y;
                btn.Font = new System.Drawing.Font("Segoe UI", 14);
                btn.Click += Digit_Click;

                this.Controls.Add(btn);

                col++;
                x += 65;

                if (col == 3)
                {
                    col = 0;
                    x = 10;
                    y += 55;
                }
            }

            // -------------------------
            // BOTTOM ROW: C   0   =
            // -------------------------
            int rowY = y;

            // C button
            Button btnC = new Button();
            btnC.Text = "C";
            btnC.Width = 60;
            btnC.Height = 50;
            btnC.Left = 10;
            btnC.Top = rowY;
            btnC.Font = new System.Drawing.Font("Segoe UI", 14);
            btnC.Click += Clear_Click;
            this.Controls.Add(btnC);

            // 0 button
            Button btn0 = new Button();
            btn0.Text = "0";
            btn0.Width = 60;
            btn0.Height = 50;
            btn0.Left = 10 + 65;
            btn0.Top = rowY;
            btn0.Font = new System.Drawing.Font("Segoe UI", 14);
            btn0.Click += Digit_Click;
            this.Controls.Add(btn0);

            // = button
            Button btnEq = new Button();
            btnEq.Text = "=";
            btnEq.Width = 60;
            btnEq.Height = 50;
            btnEq.Left = 10 + (65 * 2);
            btnEq.Top = rowY;
            btnEq.Font = new System.Drawing.Font("Segoe UI", 14);
            btnEq.Click += Equal_Click;
            this.Controls.Add(btnEq);

            // -------------------------
            // OPERATOR COLUMN
            // ---------------------------
            string[] opButtons = { "+", "-", "*", "/" };

            int opX = 10 + (65 * 3);
            int opY = 70;

            foreach (string b in opButtons)
            {
                Button btn = new Button();
                btn.Text = b;
                btn.Width = 60;
                btn.Height = 50;
                btn.Left = opX;
                btn.Top = opY;
                btn.Font = new System.Drawing.Font("Segoe UI", 14);
                btn.Click += Operator_Click;

                this.Controls.Add(btn);

                opY += 55;
            }
        }

        private void Digit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0" || clearOnNextDigit)
            {
                txtDisplay.Text = btn.Text;
                clearOnNextDigit = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ApplyLastOperation();
            lastOperator = btn.Text;
            clearOnNextDigit = true;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            ApplyLastOperation();
            txtDisplay.Text = runningTotal.ToString();
            lastOperator = "+";
            clearOnNextDigit = true;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            runningTotal = 0;
            lastOperator = "+";
            txtDisplay.Text = "0";
            clearOnNextDigit = false;
        }

        private void ApplyLastOperation()
        {
            double currentValue = double.Parse(txtDisplay.Text);

            switch (lastOperator)
            {
                case "+": runningTotal += currentValue; break;
                case "-": runningTotal -= currentValue; break;
                case "*": runningTotal *= currentValue; break;
                case "/": runningTotal /= currentValue; break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private CalculatorController _calculator;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _calculator = new CalculatorController();
            UpdateDisplay();
        }

        private void DigitPressedEvent(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var text = btn.Text;
            _calculator.PressDigit(text);
            UpdateDisplay();
        }

        private void PressZeroEvent(object sender, EventArgs e)
        {
            _calculator.PressZero();
            UpdateDisplay();
        }

        private void PressOperationEvent(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var text = btn.Text;
            var operation = Operation.Add;
            switch (text)
            {
                case "+":
                    operation = Operation.Add;
                    break;
                case "-":
                    operation = Operation.Subtract;
                    break;
                case "x":
                    operation = Operation.Multiply;
                    break;
                case "/":
                    operation = Operation.Divide;
                    break;
                case "%":
                    operation = Operation.Remainder;
                    break;
                case "!":
                    operation = Operation.Factorial;
                    break;
            }
            _calculator.PressOperation(operation);
            UpdateDisplay();
        }

        private void EqualsPressedEvent(object sender, EventArgs e)
        {
            _calculator.PressCompute();
            UpdateDisplay();
        }

        private void ClearPressEvent(object sender, EventArgs e)
        {
            _calculator.PressClear();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            label1.Text = _calculator.GetDisplay();
        }
        
    }
}
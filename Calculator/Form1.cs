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
        bool trueOrFalse = true;
        string operation;
        int resultNum;
        private Operation _operation;

        public Form1()
        {
            InitializeComponent();


        }






        private bool CheckDot()
        {
            
            if (label1.Text.Contains(".")||label1.Text=="")
            {
                return false;
            }

            return true;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!CheckDot())
                    return;
            }
            if (!(button.Text == "0" && CheckZero()))
            {
                label1.Text += button.Text;
                if (label1.Text.StartsWith("0")&&!(label1.Text.EndsWith("0") )&& !(label1.Text.Contains(".")))
                {
                    label1.Text = "";
                }
            }
            //if (label1.Text=="")
            //{
            //    if (label1.Text=="0")
            //    {
            //        button1.Enabled;
            //    }
            //}
          
           
        }

        private bool CheckZero()
        {
            
            return label1.Text == "0";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _operation = new Operation();

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            //label1.Text = btn.Text;
            var operatorType = _operation.GetOperatorType(btn.Text);

            PerformOperator(operatorType);
        }
        private void PerformOperator(OperatorType oprt)
        {
            if (_operation.FirstValue == "")
            {
                if (label1.Text != "")
                {
                    _operation.FirstValue = label1.Text;
                    _operation.Operator = oprt;
                    label1.Text = "";
                }
                return;
            }
            if (label1.Text != "")
            {
                _operation.SecondValue = label1.Text;

                var result = _operation.Calculate();

                if (double.IsInfinity(Convert.ToDouble(result)))
                {
                    label2.Text = "Cannot divide by zero";
                }
                else
                {
                    _operation.FirstValue = result;
                    label2.Text = result;
                    _operation.SecondValue = string.Empty;
                    label1.Text = string.Empty;
                    _operation.Operator = oprt;
                }
            }
            else
                _operation.Operator = oprt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _operation.FirstValue = string.Empty;
            _operation.SecondValue = string.Empty;
            label1.Text = string.Empty;
            label2.Text = string.Empty;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (_operation.FirstValue != "" && label1.Text != "")
            {
                _operation.SecondValue = label1.Text;
                label2.Text = _operation.Calculate();
                _operation.FirstValue = label2.Text;
                label1.Text = string.Empty;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            var input = 0.0;
            if (label2.Text!=""&&label2.Text!="0")
            {
                input = Convert.ToDouble(label2.Text);

            }
            else if(label1.Text!="")
            {
                input = Convert.ToDouble(label1.Text);
            }

            label1.Text = string.Empty;
            label2.Text = (Math.Pow(input, 2)).ToString();
            _operation.FirstValue = label2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var input = 0.0;
            if (label2.Text != "" && label2.Text != "0")
            {
                input = Convert.ToDouble(label2.Text);
            }
            else if (label1.Text != "")
            {
                input = Convert.ToDouble(label1.Text);
            }

            label1.Text = string.Empty;
            label2.Text = (Math.Sqrt(input)).ToString();
            _operation.FirstValue = label2.Text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void left_button_Click(object sender, EventArgs e)
        {
            tbBox.Text += "(";
        }

        private void right_button_Click(object sender, EventArgs e)
        {
           
                tbBox.Text += ")";

        }

        private void AC_button_Click(object sender, EventArgs e)
        {
            tbBox.Clear();
        }
        private void CE_button_Click(object sender, EventArgs e)
        {
            int lenght = tbBox.Text.Length - 1;
            string text = tbBox.Text;
            tbBox.Clear();
            for (int i = 0; i < lenght; i++)
            {
                tbBox.Text = tbBox.Text + text[i];
            }
        }


        private void button_7_Click(object sender, EventArgs e)
        {
            tbBox.Text += "7";
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            tbBox.Text += "8";
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            tbBox.Text += "9";
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            tbBox.Text += "/";
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            tbBox.Text += "4";
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            tbBox.Text += "5";
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            tbBox.Text += "6";
        }

        private void button_mult_Click(object sender, EventArgs e)
        {
            tbBox.Text += "*";
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            tbBox.Text += "1";

        }

        private void button_2_Click(object sender, EventArgs e)
        {
            tbBox.Text += "2";

        }

        private void button_3_Click(object sender, EventArgs e)
        {
            tbBox.Text += "3";

        }

        private void button_min_Click(object sender, EventArgs e)
        {
            tbBox.Text += "-";

        }

        private void button_0_Click(object sender, EventArgs e)
        {
            tbBox.Text += "0";

        }

        private void button_point_Click(object sender, EventArgs e)
        {
            
            tbBox.Text += ",";
            if (tbBox.Text == ",")
            {
                tbBox.Text = "0,";
                tbBox.SelectionStart = 2;
            }
            
            
      
        }

        private void button_calculator_Click(object sender, EventArgs e)
        {
            tbBox.Text += "=";
            tbBox.Text= Convert.ToString(calculator(infixToPostfix(tbBox.Text)));
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            tbBox.Text += "+";
        }

        private string infixToPostfix(string infix)
        {
            try
            {
                var stack = new Stack<string>();
                var stackPrior = new Stack<byte>();
                stackPrior.Push(0);

                string postfix = "";
                const string OPERANRS = "0123456789.,";
                for (int i = 0; i < infix.Length; i++)
                {
                    string work_char = Convert.ToString(infix[i]);// p.1
                    byte prior = 0;
                    bool flag = true;

                    for (int j = 0; j < OPERANRS.Length; j++) // p.2
                        if (work_char == Convert.ToString(OPERANRS[j]))
                        {
                            postfix += work_char;
                            flag = false;
                            break;
                        }
                    if (!flag)
                        continue;
                    //prior set
                    if (work_char == "(")
                        prior = 0;
                    if (work_char == ")")
                        prior = 1;
                    if (work_char == "+" || work_char == "-")
                        prior = 2;
                    if (work_char == "/" || work_char == "*")
                        prior = 3;
                    //

                    if (work_char == "=")//p.6
                    {
                        while (stack.Count != 0)
                        {
                            postfix += stack.Pop();
                        }
                        postfix += "=";
                        break;
                    }

                    while (true)
                    {
                        if (prior == 0 || prior > stackPrior.Peek())// p.3
                        {
                            stack.Push(work_char);
                            stackPrior.Push(prior);

                            postfix += " ";
                            break;
                        }
                        else //p.5
                        {
                            postfix += stack.Pop();
                            stackPrior.Pop();
                        }
                    }

                    if (prior == 1)//p.4
                    {
                        stack.Pop();
                        stackPrior.Pop();
                        stack.Pop();
                        stackPrior.Pop();
                    }

                }
                Index.Text = postfix.ToString();
                return postfix;
            }
            catch (Exception) { return "0";}
        }

        private double calculator(string rpnString)
        {
            try
            {
                Stack<double> numbersStack = new Stack<double>();
                double op1, op2;
                for (int i = 0; i < rpnString.Length; i++)
                {
                    if (rpnString[i] == ' ')
                        continue;
                    if (Char.IsDigit(rpnString[i]))
                    {
                        int j;
                        for (j = i; j < rpnString.Length; j++)
                        {
                            if (!Char.IsDigit(rpnString[j]) && rpnString[j] != ',')
                                break;
                        }
                        string str;
                        str = rpnString.Substring(i, j - i);
                        numbersStack.Push(Convert.ToDouble(str));
                        i = j - 1;
                    }


                    if (rpnString[i] == '+' || rpnString[i] == '-' || rpnString[i] == '*' || rpnString[i] == '/')
                    {
                        op2 = numbersStack.Pop();
                        op1 = numbersStack.Pop();
                        numbersStack.Push(ApplyOperation(rpnString[i], op1, op2));
                    }
                }
                return numbersStack.Pop();
            }
            catch (Exception) { MessageBox.Show("Error..."); return 0; }

        }
        private static double ApplyOperation(char operation, double op1, double op2)
        {
            switch (operation)
            {
                case '+': return (op1 + op2);
                case '-': return (op1 - op2);
                case '*': return (op1 * op2);
                case '/': return (op1 / op2);
                default: return 0;
            }
        }

        private void tbBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbBox.Text == ",")
            {
                tbBox.Text = "0,";
                tbBox.SelectionStart = 2;
            }

            if (tbBox.Text.Length == 0)
            {
                if (e.KeyChar == 44)
                { tbBox.Text += "0,"; }
            }

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 44 && e.KeyChar != 8)
                e.Handled = true;

            if (e.KeyChar == ',')
            {
                if (tbBox.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
        }
    }
}

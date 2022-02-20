﻿using System;
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

        }

        private void button_calculator_Click(object sender, EventArgs e)
        {
            tbBox.Text += "=";
            infixToPostfix(tbBox.Text);
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            tbBox.Text += "+";
        }
    
        private string infixToPostfix(string infix)
        {
            string postfix = "";
            var stack = new Stack<string>();
            var stackPrior = new Stack<byte>();
            string operants = "0123456789";
            for (int i = 0; i < infix.Length; i++)
            {
                string work_char = Convert.ToString(infix[i]);// p.1
                byte prior=0;
                bool flag = true;
                for (int j = 0; j < 10; j++) // p.2
                    if (work_char == Convert.ToString(operants[j]))
                    {
                        postfix += work_char;
                        flag = false;
                        break;
                    }
                if (!flag)
                    continue;
                if (work_char == "(")
                    prior = 0;
                if (work_char == ")")
                    prior = 1;
                if (work_char == "+"|| work_char == "-")
                    prior = 2;
                if (work_char == "/" || work_char == "*")
                    prior = 3;
                while (true)
                {
                    if (prior == 0 || prior > stackPrior.Peek())// p.3
                    {
                        stack.Push(work_char);
                        stackPrior.Push(prior);
                        break;
                    }
                    else
                    {
                        postfix += stack.Pop();
                        stackPrior.Pop();
                    }
                }
                if (prior == 1)
                {
                    stack.Pop();
                    stackPrior.Pop();
                    stack.Pop();
                    stackPrior.Pop();
                }
                if (work_char == "=")
                {
                    while (stack.Count != 0)
                    {
                        postfix += stack.Pop();
                    }
                    postfix += "=";
                    break;
                }
              
            }
            return postfix;
        }

        private double calculator(string post)
        {
            double result;
            string[] mas = post.Split(' ');
            string temp_string;
            for (int i = 0; i < mas.Length; i++)
                switch (mas[i])
                {
                    case "+":
                        temp_string = (double.Parse(mas[i - 2]) + double.Parse(mas[i - 1])).ToString();
                        tbBox.AppendText(mas[i - 2] + "+" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);
                        i -= 2;
                        break;
                    case "-":
                        temp_string = (double.Parse(mas[i - 2]) - double.Parse(mas[i - 1])).ToString();
                        tbBox.AppendText(mas[i - 2] + "-" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);
                        i -= 2;
                        break;
                    case "*":
                        temp_string = (double.Parse(mas[i - 2]) * double.Parse(mas[i - 1])).ToString();
                        tbBox.AppendText(mas[i - 2] + "*" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);

                        i -= 2;
                        break;
                    case "/":
                        temp_string = (double.Parse(mas[i - 2]) / double.Parse(mas[i - 1])).ToString();
                        tbBox.AppendText(mas[i - 2] + "/" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);
                        i -= 2;
                        break;
                         
                }
            return double.Parse(mas[0]);



            var stack = new Stack<string>();
            string[] operants = { "0123456789" };

            for (int i = 0; i<mas.Length; i++)
            {
                if ()
            }
            return result;
        }

    }
}

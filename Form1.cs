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

        }

        private void CE_button_Click(object sender, EventArgs e)
        {

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

        }

        private void button_plus_Click(object sender, EventArgs e)
        {

        }
        private string infixToPostfix(string infix)
        {
            string postfix = "";
            var stack = new Stack<string>();
            var stackPrior = new Stack<string>();
            string[] operants = { "0123456789" };
            for (int i = 0; i < infix.Length; i++)
            {

                for (int j = 0; j < 10; j++)
                    if (Convert.ToString(infix[i]) == operants[j])
                    {
                        postfix += operants[j];
                        continue;
                    }
                if (infix[i] == '(')
                {

                }
                /////////frfrrrrrrrrrrrrrrr
                ///g
                ///tgtg
            }
            return postfix;
        }
        private double calculator()
        {
            double result;

            hello world salsam dasdasl dasldlsadlas dlasldsaldas ldasldlsa
            return result;
        }
    }
}

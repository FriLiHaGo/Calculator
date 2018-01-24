using CalcLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCalc
{
    public partial class Form1 : Form
    {
        private Calc Calc { get; set; }
        private bool IsInputEnter { get; set; }

        public Form1()
        {
            InitializeComponent();
            Calc = new Calc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbOperations.Items.Clear();
            lbOperations.Items.AddRange(Calc.GetOperations());
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (lbOperations.SelectedItem == null)
            {
                return;
            }

            var oper = lbOperations.SelectedItem.ToString();

            var result = Calc.Exec(oper, tbInput.Text.Trim().Split(' '));

            lblResult.Text = result.ToString();
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Enabled = lbOperations.SelectedItem != null;
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            btnCalc.Enabled = !string.IsNullOrWhiteSpace(tbInput.Text);

            if (string.IsNullOrWhiteSpace(tbInput.Text))
            {
                lblResult.Text = string.Empty;
            }
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbInput.Text) && e.KeyCode == Keys.Enter)
            {
                IsInputEnter = true;
                btnCalc_Click(sender, e);
            }
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsInputEnter == true)
            {
                IsInputEnter = false;
                e.Handled = true;
            }
        }

        private void tbInput_DoubleClick(object sender, EventArgs e)
        {
            tbInput.Clear();
        }
    }
}

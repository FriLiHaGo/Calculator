using CalcLibrary;
using CalcDB.Models;
using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private System.Threading.Timer timer;

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

            #region Сохранение в БД

            var or = new OperationResult()
            {
                OperationId = lbOperations.SelectedIndex,
                Result = result,
                ExecutionTime = new Random().Next(100, 4000),
                Error = "",
                Args = tbInput.Text.Trim(),
                CreationDate = DateTime.Now
            };

            var operResultRepository = new BaseRepository<OperationResult>();
            operResultRepository.Save(or);

            #endregion
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput.Enabled = lbOperations.SelectedItem != null;
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            //timer?.Dispose();

            btnCalc.Enabled = !string.IsNullOrWhiteSpace(tbInput.Text);

            //if (string.IsNullOrWhiteSpace(tbInput.Text))
            //{
            //    lblResult.Text = string.Empty;
            //}
            //else
            //{
            //    timer = new System.Threading.Timer(new TimerCallback(ToExec), null, 1000, -1);
            //}
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbInput.Text) && e.KeyCode == Keys.Enter)
            {
                IsInputEnter = true;
                var oper = lbOperations.SelectedItem.ToString();
                var result = Calc.Exec(oper, tbInput.Text.Trim().Split(' '));
                lblResult.Text = result.ToString();
            }
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsInputEnter == true)
            {
                e.Handled = true;
                IsInputEnter = false;
            }
        }

        private void tbInput_DoubleClick(object sender, EventArgs e)
        {
            tbInput.Clear();
        }

        private void ToExec(object ob)
        {
            Func<string> func = () => lbOperations.SelectedItem.ToString();
            var oper = (string)Invoke(func);

            var result = Calc.Exec(oper, tbInput.Text.Trim().Split(' '));

            Invoke(new Action(() => lblResult.Text = result.ToString()));
        }
    }
}

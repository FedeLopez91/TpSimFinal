using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpSimFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.txtNroIteraciones.Text = "15000";
            this.txtMostrarDesde.Text = "1";
            this.txtMostrarHasta.Text = "1000";
            this.txtPresupuesto.Text = "2000000";
        }

        private void ValidarMostrarDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void ValidarNroIteraciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void ValidarMostrarHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void ValidarPresupuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void ValidarSoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// If you want, you can allow decimal (float) numbers
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void calcularDivisionPresupuesto(object sender, EventArgs e)
        {
            this.lblCantPres1.Text = "1";
            this.lblCantPres2.Text = "2";
            this.lblCantPres3.Text = "3";
            this.lblCantPres4.Text = "4";

            //for (int i = 0; i < 4; i++)
            //{
            //    var name = string.Format("lblCantPres{0}", i);
            //    //if (this.Controls.ContainsKey(name))
            //    //{
            //        var currentLabel = this.Controls[name] as Label;
            //        if (currentLabel != null) currentLabel.Text = "Test"+i;
            //    //}
            //}

            //var t = this.GetType();
            //var controls = t.GetProperties();
            ////MessageBox.Show(controls.Count);
            //foreach (PropertyInfo fi in controls)
            //{
            //    if (fi.GetType() == typeof(Label))
            //    {
            //        var a = 2;
            //    }

            //    //if (fi.PropertyType.ToString() == "XXXXX")
            //    //{

            //    //    MessageBox.Show(fi.Name);
            //    //}
            //}
        }
    }
}

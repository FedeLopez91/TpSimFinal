using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        }

        private void calcularDivisionPresupuesto(object sender, EventArgs e)
        {

            var labels = panelPresupuesto.Controls.OfType<Label>().Where(x => x.Name.Contains("lblCantPres"));
            var presupuesto = Convert.ToDecimal(this.txtPresupuesto.Text, new CultureInfo("en-US"))/ labels.Count();
            var i = 4;

            foreach (Control fi in labels)
            {
                var name = string.Format("lblCantPres{0}", i);
                if (fi.Name == name)
                {
                    fi.Text = string.Format("{0}", presupuesto*i);
                }
                i--;
            }
        }
    }
}

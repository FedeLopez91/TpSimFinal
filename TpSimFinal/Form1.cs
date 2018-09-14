using Simlib;
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
        //Proyecto A
        Distribuciones<double> distProyA1;
        Distribuciones<double> distProyA2;
        Distribuciones<double> distProyA3;
        Distribuciones<double> distProyA4;
        //Proyecto B
        Distribuciones<double> distProyB1;
        Distribuciones<double> distProyB2;
        Distribuciones<double> distProyB3;
        Distribuciones<double> distProyB4;
        //Proyecto C
        Distribuciones<double> distProyC1;
        Distribuciones<double> distProyC2;
        Distribuciones<double> distProyC3;
        Distribuciones<double> distProyC4;

        //Inversion
        Distribuciones<double> inversion;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            txtNroIteraciones.Text = "15000";
            txtMostrarDesde.Text = "1";
            txtCantMostrar.Text = "1000";
            txtPresupuesto.Text = "2000000";

            createParamProyectos();
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
            var distribucionInversion= new List<Probabilidades<double>>();
            var labels = panelPresupuesto.Controls.OfType<Label>().Where(x => x.Name.Contains("lblCantPres"));
            var presupuesto = Convert.ToDecimal(this.txtPresupuesto.Text, new CultureInfo("en-US"))/ labels.Count();
            var i = 4;

            foreach (Control fi in labels)
            {
                var name = string.Format("lblCantPres{0}", i);
                if (fi.Name == name)
                {
                    fi.Text = string.Format("{0}", presupuesto*i);
                    distribucionInversion.Add(new Probabilidades<double>(Convert.ToInt32(presupuesto * i), 0.25));
                }
                i--;
            }
            this.inversion = new Distribuciones<double>(distribucionInversion);
        }

        private void createParamProyectos()
        {
            var dgvParam = gbParametros.Controls.OfType<Panel>().Where(x => x.Name.Contains("pProy"));

            foreach (var item in dgvParam)
            {
                var a = item.Controls.OfType<DataGridView>();
                foreach (var dgv in a)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        dgv.Rows.Add(i, 0.25);
                    }
                   
                }
            }

        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                MessageBox.Show("La Suma de las probabilidades porcentuales debe ser igual a 100");
                return;
            }
        }

        private void generarDistribucionCantidad()
        {
            //List<Probabilidades<int>> ListaCantAutos = new List<Probabilidades<int>>();
            //foreach (DataGridViewRow r in dgwcantautos.Rows)
            //{
            //    var valor = r.Cells[0].Value;
            //    var probabilidad = r.Cells[1].Value;
            //    ListaCantAutos.Add(new Probabilidades<int>(Convert.ToInt32(valor), Convert.ToDouble(probabilidad)));
            //}
            //this.CantAutosVendidos = new Distribuciones<int>(ListaCantAutos);
        }

        private bool validar()
        {
            //int acum = 0;
            //foreach (DataGridViewRow row in dgwcantautos.Rows)
            //{
            //    acum += Convert.ToInt32(row.Cells[1].Value);
            //}
            //if (acum != 100) return false;
            //acum = 0;
            //foreach (DataGridViewRow row in dgwTipoAuto.Rows)
            //{
            //    acum += Convert.ToInt32(row.Cells[1].Value);
            //}
            //if (acum != 100) return false;
            //acum = 0;
            //foreach (DataGridViewRow row in dgwcomisionAL.Rows)
            //{
            //    acum += Convert.ToInt32(row.Cells[1].Value);
            //}
            //if (acum != 100) return false;
            //acum = 0;
            //foreach (DataGridViewRow row in dgwcomisionAM.Rows)
            //{
            //    acum += Convert.ToInt32(row.Cells[1].Value);
            //}
            //if (acum != 100) return false;
            return true;
        }

        private void Simular()
        {
            //ManejadorSimulacion manejador = new ManejadorSimulacion(this.CantAutosVendidos, this.TipoAuto);

            /*dgw_simulacion.DataSource = */
            //manejador.Simular(
            //    int.Parse(txt_cantSemanas.Text),
            //    int.Parse(txt_cantMostrar.Text),
            //    int.Parse(txt_mostrarDesde.Text));
            //dgw_simulacion.DataSource = manejador.Info;

            //dgw_simulacion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //lblResultado.Text = $"Promedio de Comision de Vendedores: {manejador.Promedio_Vendedores.ToString("C")}" +
            //    "\nComisión promedio de los vendedores en una semana (total): " + manejador.Promedio_Total;
            //lblpromparcial.Text = $"Promedio Vendedor 1: {manejador.Promedio_V1}\n" +
            //    $"Promedio Vendedor 2: {manejador.Promedio_V2}\n" +
            //    $"Promedio Vendedor 3: {manejador.Promedio_V3}\n" +
            //    $"Promedio Vendedor 4: {manejador.Promedio_V4}";
            //TcRSimulacion.SelectTab(TpRSimulacion);


        }
    }
}

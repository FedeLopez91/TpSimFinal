﻿using Simlib;
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
        Distribuciones<double>[] ProyectoA = new Distribuciones<double>[4];
        

        //Proyecto B
        Distribuciones<double> distProyB1;
        Distribuciones<double> distProyB2;
        Distribuciones<double> distProyB3;
        Distribuciones<double> distProyB4;
        Distribuciones<double>[] ProyectoB = new Distribuciones<double>[4];
        //Proyecto C
        Distribuciones<double> distProyC1;
        Distribuciones<double> distProyC2;
        Distribuciones<double> distProyC3;
        Distribuciones<double> distProyC4;
        Distribuciones<double>[] ProyectoC = new Distribuciones<double>[4];

        //Inversion
        Distribuciones<double> Inversion;

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

            CreateParamProyectos();
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
            CreateDistribucionPresupuesto();
        }

        private void CreateDistribucionPresupuesto()
        {
            var distribucionInversion = new List<Probabilidades<double>>();
            var labels = panelPresupuesto.Controls.OfType<Label>().Where(x => x.Name.Contains("lblCantPres"));
            var presupuesto = Convert.ToDecimal(this.txtPresupuesto.Text, new CultureInfo("en-US")) / labels.Count();
            var i = 4;
            var prob = (double)((decimal)1 / 4);
            foreach (Control fi in labels)
            {
                var name = string.Format("lblCantPres{0}", i);
                if (fi.Name == name)
                {
                    fi.Text = string.Format("{0}", presupuesto * i);
                    distribucionInversion.Add(new Probabilidades<double>(Convert.ToDouble(presupuesto * i), prob));
                }
                i--;
            }
            this.Inversion = new Distribuciones<double>(distribucionInversion);
        }

        private void CreateParamProyectos()
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
            CreateDistribucionPresupuesto();
            GetdgwProyectos();

            Simular();
           
        }

        private void GetdgwProyectos()
        {
            
            var dgvParam = gbParametros.Controls.OfType<Panel>().Where(x => x.Name.Contains("pProy"));

            foreach (var item in dgvParam)
            {
                var a = item.Controls.OfType<DataGridView>();
                foreach (var dgv in a)
                {
                    List<Probabilidades<double>> ListProbabilidad = new List<Probabilidades<double>>();
                    var name = dgv.Name.Substring(3, 6);
                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        var valor = r.Cells[0].Value;
                        var probabilidad = r.Cells[1].Value;
                        ListProbabilidad.Add(new Probabilidades<double>(Convert.ToDouble(valor), Convert.ToDouble(probabilidad)));
                    }

                    Type type = typeof(Distribuciones<double>);
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(List<Probabilidades<double>>) });
                    object instance = ctor.Invoke(new object[] { ListProbabilidad });

                    switch (name)
                    {
                        case "ProyA1":
                            distProyA1 = (Distribuciones<double>)instance;
                            break;
                        case "ProyA2":
                            distProyA2 = (Distribuciones<double>)instance;
                            break;
                        case "ProyA3":
                            distProyA3 = (Distribuciones<double>)instance;
                            break;
                        case "ProyA4":
                            distProyA4 = (Distribuciones<double>)instance;
                            break;
                        case "ProyB1":
                            distProyB1 = (Distribuciones<double>)instance;
                            break;
                        case "ProyB2":
                            distProyB2 = (Distribuciones<double>)instance;
                            break;
                        case "ProyB3":
                            distProyB3 = (Distribuciones<double>)instance;
                            break;
                        case "ProyB4":
                            distProyB4 = (Distribuciones<double>)instance;
                            break;
                        case "ProyC1":
                            distProyC1 = (Distribuciones<double>)instance;
                            break;
                        case "ProyC2":
                            distProyC2 = (Distribuciones<double>)instance;
                            break;
                        case "ProyC3":
                            distProyC3 = (Distribuciones<double>)instance;
                            break;
                        case "ProyC4":
                            distProyC4 = (Distribuciones<double>)instance;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private bool validar()
        {
            var dgvParam = gbParametros.Controls.OfType<Panel>().Where(x => x.Name.Contains("pProy"));

            foreach (var item in dgvParam)
            {
                var a = item.Controls.OfType<DataGridView>();
                foreach (var dgv in a)
                {
                    var acum = 0.0m;
                    var name = dgv.Name.Substring(3, 6);
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        var ab = Convert.ToDecimal(row.Cells[1].Value, new CultureInfo("en-US"));
                        acum += ab;
                    }
                    if (acum != 1) return false;

                    
                }
            }
            return true;
        }

        private void Simular()
        {
            ProyectoA[0] = distProyA1;
            ProyectoA[1] = distProyA2;
            ProyectoA[2] = distProyA3;
            ProyectoA[3] = distProyA4;

            ProyectoB[0] = distProyB1;
            ProyectoB[1] = distProyB2;
            ProyectoB[2] = distProyB3;
            ProyectoB[3] = distProyB4;

            ProyectoC[0] = distProyC1;
            ProyectoC[1] = distProyC2;
            ProyectoC[2] = distProyC3;
            ProyectoC[3] = distProyC4;

            ManejadorSimulacion manejador = new ManejadorSimulacion(ProyectoA, ProyectoB, ProyectoC, Inversion);

            /*dgw_simulacion.DataSource = */
            manejador.Simular(int.Parse(txtNroIteraciones.Text), int.Parse(txtCantMostrar.Text), int.Parse(txtMostrarDesde.Text), int.Parse(txtPresupuesto.Text));

            //Seteo la Lista de Vectores del Gestor como Fuente de la Tabla.
            dgvSimulacion.DataSource = manejador.Simulacion;
            
            
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

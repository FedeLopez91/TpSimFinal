using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Simlib.Tabla_Probabilidades;

namespace Simlib
{
    public class ManejadorSimulacion
    {

        private Distribuciones<int> DistCantAutos;
        private Distribuciones<TipoAuto> DistTiposAuto;

        public DataTable Info { get; protected set; }
        public double Promedio_V1 { get; protected set; }
        public double Promedio_V2{ get; protected set; }
        public double Promedio_V3{ get; protected set; }
        public double Promedio_V4{ get; protected set; }
        public double Promedio_Vendedores{ get; protected set; }
        public double Promedio_Total { get; protected set; }

        /*private Distribuciones DistComisionesLujo;
        private Distribuciones DistComisionesMediano;*/


        public ManejadorSimulacion(Distribuciones<int> CantidadAutos, Distribuciones<TipoAuto> TipoAuto)
        {
            this.DistCantAutos = CantidadAutos;
            this.DistTiposAuto = TipoAuto;
        }

        public void Simular(int CantSemanas, int filasMostrar, int mostrarDesde)
        {
            DataTable tabla = new DataTable(); //Tabla que será devuelta

            tabla.Columns.Add("Semana Numero:");

            tabla.Columns.Add("(v1) RND Cant Autos");
            tabla.Columns.Add("(v1) Cantidad Autos");
            tabla.Columns.Add("(v1) RND Tipo Auto");
            tabla.Columns.Add("(v1) Tipo Auto");
            tabla.Columns.Add("(v1) RND Comision");
            tabla.Columns.Add("(v1) Comision");
            tabla.Columns.Add("(v1) Comision Total");
            tabla.Columns.Add("(v1) Comision Acumulada");

            tabla.Columns.Add("(v2) RND Cant Autos");
            tabla.Columns.Add("(v2) Cantidad Autos");
            tabla.Columns.Add("(v2) RND Tipo Auto");
            tabla.Columns.Add("(v2) Tipo Auto");
            tabla.Columns.Add("(v2) RND Comision");
            tabla.Columns.Add("(v2) Comision");
            tabla.Columns.Add("(v2) Comision Total");
            tabla.Columns.Add("(v2) Comision Acumulada");

            tabla.Columns.Add("(v3) RND Cant Autos");
            tabla.Columns.Add("(v3) Cantidad Autos");
            tabla.Columns.Add("(v3) RND Tipo Auto");
            tabla.Columns.Add("(v3) Tipo Auto");
            tabla.Columns.Add("(v3) RND Comision");
            tabla.Columns.Add("(v3) Comision");
            tabla.Columns.Add("(v3) Comision Total");
            tabla.Columns.Add("(v3) Comision Acumulada");

            tabla.Columns.Add("(v4) RND Cant Autos");
            tabla.Columns.Add("(v4) Cantidad Autos");
            tabla.Columns.Add("(v4) RND Tipo Auto");
            tabla.Columns.Add("(v4) Tipo Auto");
            tabla.Columns.Add("(v4) RND Comision");
            tabla.Columns.Add("(v4) Comision");
            tabla.Columns.Add("(v4) Comision Total");
            tabla.Columns.Add("(v4) Comision Acumulada");

            tabla.Columns.Add("Comision Total");
            tabla.Columns.Add("Comision Acumulada Total");
            

            var mostrarHasta = mostrarDesde + filasMostrar;

            string[] vector = new string[35];

            double acum_v1 = 0;
            double acum_v2 = 0;
            double acum_v3 = 0;
            double acum_v4 = 0;
            double acum_total = 0;
            for (int semana = 1; semana <= CantSemanas; semana++)
            {
                vector[0] = semana.ToString();

                var ven1 = SubVectorVendedor();
                var ven2 = SubVectorVendedor();
                var ven3 = SubVectorVendedor();
                var ven4 = SubVectorVendedor();

                acum_v1 += Convert.ToDouble(ven1[6]);
                acum_v2 += Convert.ToDouble(ven2[6]);
                acum_v3 += Convert.ToDouble(ven3[6]);
                acum_v4 += Convert.ToDouble(ven4[6]);

                double total = Convert.ToDouble(ven1[6]) + 
                    Convert.ToDouble(ven2[6]) + 
                    Convert.ToDouble(ven3[6]) + 
                    Convert.ToDouble(ven4[6]);

                acum_total += total;

                // del 1 al 7
                agregarSubVendedor(ref vector, ref ven1, 1);
                vector[8] = acum_v1.ToString();
                
                //del 9 al 15
                agregarSubVendedor(ref vector, ref ven2, 9);
                vector[16] = acum_v2.ToString();

                //del 17 al 23
                agregarSubVendedor(ref vector, ref ven3, 17);
                vector[24] = acum_v3.ToString();

                //del 25 al 31
                agregarSubVendedor(ref vector, ref ven4, 25);
                vector[32] = acum_v4.ToString();

                vector[33] = total.ToString();
                vector[34] = acum_total.ToString();

                //Agregar a la tabla a mostrar;
                if (semana >= mostrarDesde && semana < mostrarHasta)
                    tabla.LoadDataRow(vector, true);
            }

            //Agregar Fila final
            tabla.LoadDataRow(vector, true);

            //logica final
            Promedio_V1 = acum_v1 / CantSemanas;
            Promedio_V2 = acum_v2 / CantSemanas;
            Promedio_V3 = acum_v3 / CantSemanas;
            Promedio_V4 = acum_v4 / CantSemanas;

            Promedio_Vendedores = (Promedio_V1 + Promedio_V2 + Promedio_V3 + Promedio_V4) / 4;

            Promedio_Total = acum_total / CantSemanas;

            //Setear Tabla
            this.Info = tabla;
        }

        private String[] SubVectorVendedor()
        {
            String[] subVector = new String[7];
            //Cantidad Auto (Rnd + Nro) - Tipo Autos (Rnd + nro) - Comisiones (Rnd + Nros) - Comision Total Ven

            RndValor<int> demanda = this.DistCantAutos.generar();


            string tipos_rnd_tx = "";
            string tipos_tx = "";
            string comisiones_rnd_tx = "";
            string comisiones_tx = "";
            double comision_total = 0;
            for (int i = 0; i < demanda.Valor; i++)
            {
                var tipo = this.DistTiposAuto.generar();
                tipos_rnd_tx += tipo.Random + "\n";
                tipos_tx += tipo.Valor.Nombre + "\n";
                var comision = tipo.Valor.DistribucionComision.generar();
                comisiones_rnd_tx += comision.Random + "\n";
                comisiones_tx += comision.Valor + "\n";
                comision_total += comision.Valor;
            }

            //Cantidad Auto (Rnd + Nro) - Tipo Autos (Rnd + nro) - Comisiones (Rnd + Nros) - Comision Total Ven
            subVector[0] = demanda.Random.ToString();
            subVector[1] = demanda.Valor.ToString();
            subVector[2] = tipos_rnd_tx;
            subVector[3] = tipos_tx;
            subVector[4] = comisiones_rnd_tx;
            subVector[5] = comisiones_tx;
            subVector[6] = comision_total.ToString();


            return subVector;
        }

        private void agregarSubVendedor(ref string[] vector,ref string[] vendedor, int desde)
        {
            for (int i = 0; i < vendedor.Length; i++)
            {
                vector[desde + i] = vendedor[i];
            }
        }
        
    }
}

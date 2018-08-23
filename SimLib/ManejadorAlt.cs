using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Simlib;

namespace Simlib
{
    public class ManejadorAlt
    {
        public DataTable info { get; protected set; }
        public double PromedioIndividual { get; protected set; }
        public double PromedioGrupal { get; protected set; }

        public Distribuciones<int> DistribucionCantidad { get; protected set; }
        public Distribuciones<double> DistribucionComAL { get; protected set; }
        public Distribuciones<double> DistribucionComAM { get; protected set; }

        public ManejadorAlt(Distribuciones<int> cantidad, Distribuciones<double> lujo, Distribuciones<double> mediano)
        {
            this.DistribucionCantidad = cantidad;
            this.DistribucionComAL = lujo;
            this.DistribucionComAM = mediano;
        }

        //public void Simular(int CantSemanas, int filasMostrar, int mostrarDesde, Distribuciones<int> cantautos, Distribuciones<TipoAuto> tipoAuto, Distribuciones<double> ComisionesAL, Distribuciones<double> ComisionesAM)
        //{
        //    DataTable tabla = new DataTable(); //Tabla que será devuelta
        //    tabla.Columns.Add("Semana Numero:");
        //    tabla.Columns.Add("RND Cant Autos");
        //    tabla.Columns.Add("Cantidad Autos");
        //    tabla.Columns.Add("RND Tipo Auto");
        //    tabla.Columns.Add("Tipo Auto");
        //    tabla.Columns.Add("RND Comision");
        //    tabla.Columns.Add("Comision");
        //    tabla.Columns.Add("Comision Total");
        //    tabla.Columns.Add("Comision Acumulada");

        //    var mostrarHasta = mostrarDesde + filasMostrar;
        //    Random r = new Random();
        //    //double acumtotalvendedor = 0;
        //    double acum = 0;
        //    //textpromparcial += "Promedio por Semana:\n";

        //    String[] vector = new String[9];


        //    for (int j = 1; j <= CantSemanas; j++)//bucle por semana

        //    {
        //        //Semana
        //        vector[0] = j.ToString();

        //        double rndCantAuto = cantautos.GenerarRnd();
        //        //Rnd Cantidad Autos
        //        vector[1] = rndCantAuto.ToString();
        //        //Cantidad Autos
        //        vector[2] = cantautos.ObtenerValorAsociado(rndCantAuto).ToString();
        //        String rndComisionTexto = "";
        //        String rndtipoAutoTexto = "";
        //        String tipoAutoTexto = "";
        //        String comisionTexto = "";
        //        double ComisionTotal = 0;
        //        //Iteraciones por autos (Demanda)
        //        for (int k = 0; k < int.Parse(vector[2]); k++)
        //        {
        //            double rndtipoAuto = tipoAuto.GenerarRnd();
        //            var tipoauto = tipoAuto.ObtenerValorAsociado(rndtipoAuto);

        //            int tipoaut = tipoauto.Numero;

        //            //double rndcomision = Math.Truncate(r.NextDouble() * 100);
        //            //double comision = buscarcomision(tipoaut, rndcomision, ComisionesAL, ComisionesAM);
        //            var valorRnd = buscarcomision(tipoaut);
        //            double rndcomision = valorRnd.Random;
        //            double comision = valorRnd.Valor;

        //            rndtipoAutoTexto += rndtipoAuto.ToString() + Environment.NewLine;
        //            tipoAutoTexto += buscarTipo(tipoaut) + Environment.NewLine;
        //            rndComisionTexto += (rndtipoAuto.Equals("1") ? " " : rndcomision.ToString()) + Environment.NewLine;
        //            comisionTexto += comision + Environment.NewLine;

        //            ComisionTotal = ComisionTotal + comision;
        //        }
        //        acum += ComisionTotal;
        //        vector[3] = rndtipoAutoTexto.ToString();
        //        vector[4] = tipoAutoTexto;
        //        vector[5] = rndComisionTexto;
        //        vector[6] = comisionTexto;
        //        vector[7] = ComisionTotal.ToString();
        //        vector[8] = acum.ToString();
        //        //vector[9] = vendedor.ToString();

        //        if (j >= mostrarDesde && j < mostrarHasta)
        //            tabla.LoadDataRow(vector, true);
        //    }

        //    tabla.LoadDataRow(vector, true);


        //    //Promedio semanal de ventas del unico vendedor.
        //    //this.PromedioIndividual = double.Parse(vector[8]) / CantSemanas;//acumulado/cantsemanas
        //    this.PromedioIndividual = acum / CantSemanas;//acumulado/cantsemanas



        //    //acumtotalvendedor += double.Parse(vector[8]);//suma los acumulados
        //    //acum += promparcial;

        //    //promtotal = acum / 4;
        //    this.PromedioGrupal = this.PromedioIndividual * 4;
        //    this.info = tabla;
        //}

        public RndValor<double> buscarcomision(int tipo/*, double rnd, Distribuciones<double> comisionAL, Distribuciones<double> comisionAM*/)
        {
            switch (tipo)
            {

                case 1:
                    //Auto Compacto
                    return new RndValor<double>(01, 250);

                case 2:
                    //Auto Mediano
                    return this.DistribucionComAM.generar();
                case 3:
                    //Auto De Lujo
                    return this.DistribucionComAL.generar();
                default:
                    return null;

            }
        }

        public string buscarTipo(int tipo)
        {
            switch (tipo)
            {

                case 1:
                    //Auto Compacto
                    return "Compacto(C)";

                case 2:
                    //Auto Mediano
                    return "Auto Mediano(AM)";

                case 3:
                    //Auto De Lujo
                    return "Auto de Lujo(AL)";

                default:
                    return "n";

            }
        }
    }
}

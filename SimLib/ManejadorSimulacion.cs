using SimLib;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Simlib
{
    public class ManejadorSimulacion
    {
        public List<VectorSimulacion> Simulacion { get; set; }
        public DataTable Info { get; protected set; }
        public Distribuciones<double>[] ProyectoA { get; protected set; }
        public Distribuciones<double>[] ProyectoB { get; protected set; }
        public Distribuciones<double>[] ProyectoC { get; protected set; }
        public Distribuciones<double> Inversion { get; protected set; }

        public ManejadorSimulacion(Distribuciones<double>[] proyectoA, Distribuciones<double>[] proyectoB, 
            Distribuciones<double>[] proyectoC, Distribuciones<double> inversion)
        {
            ProyectoA = proyectoA;
            ProyectoB = proyectoB;
            ProyectoC = proyectoC;
            Inversion = inversion;
        }

        public void Simular(int cantIteraciones, int filasMostrar, int mostrarDesde, int presupuesto)
        {
            Simulacion = new List<VectorSimulacion>();
            var mostrarHasta = mostrarDesde + filasMostrar;
            var vAnterior = new VectorSimulacion();

            for (int semana = 1; semana <= cantIteraciones; semana++)
            {
                var vActual = new VectorSimulacion(); ;

                var RNDA = Inversion.Generar();
                vActual.RndProyectoA = RNDA.Random;
                vActual.InversionProyectoA = RNDA.Valor;
                var indicePA = RNDA.PosicionTabla;

                var RNDVPNA = ProyectoA[indicePA].Generar();
                vActual.RndVPNProyectoA = RNDVPNA.Random;
                vActual.VPNProyectoA = RNDVPNA.Valor;

                var RNDB = Inversion.Generar();
                vActual.RndProyectoB = RNDB.Random;
                vActual.InversionProyectoB = RNDB.Valor;
                var indicePB = RNDB.PosicionTabla;

                var RNDVPNB = ProyectoB[indicePB].Generar();
                vActual.RndVPNProyectoB = RNDVPNB.Random;
                vActual.VPNProyectoB = RNDVPNB.Valor;

                var RNDC = Inversion.Generar();
                vActual.RndProyectoC = RNDC.Random;
                vActual.InversionProyectoC = RNDC.Valor;
                var indicePC = RNDC.PosicionTabla;

                var RNDVPNC = ProyectoC[indicePC].Generar();
                vActual.RndVPNProyectoC = RNDVPNC.Random;
                vActual.VPNProyectoC = RNDVPNC.Valor;

                vActual.AcumVPN = vActual.VPNProyectoA + vActual.VPNProyectoB + vActual.VPNProyectoC;

                if(vActual.AcumVPN > vAnterior.AcumMejorVPN)
                {
                    vActual.AcumMejorVPN = vActual.AcumVPN;

                    vActual.InversionMejorProyectoA = vActual.InversionProyectoA;
                    vActual.VPNMejorProyectoA = vActual.VPNProyectoA;

                    vActual.InversionMejorProyectoB = vActual.InversionProyectoB;
                    vActual.VPNMejorProyectoB = vActual.VPNProyectoB;

                    vActual.InversionMejorProyectoC = vActual.InversionProyectoC;
                    vActual.VPNMejorProyectoC = vActual.VPNProyectoC;
                }
                else
                {
                    vActual.AcumMejorVPN = vAnterior.AcumMejorVPN;

                    vActual.InversionMejorProyectoA = vAnterior.InversionMejorProyectoA;
                    vActual.VPNMejorProyectoA = vAnterior.VPNMejorProyectoA;

                    vActual.InversionMejorProyectoB = vAnterior.InversionMejorProyectoB;
                    vActual.VPNMejorProyectoB = vAnterior.VPNMejorProyectoB;

                    vActual.InversionMejorProyectoC = vAnterior.InversionMejorProyectoC;
                    vActual.VPNMejorProyectoC = vAnterior.VPNMejorProyectoC;
                }

                vAnterior = vActual;
                //Agregar a la tabla a mostrar;
                if (semana >= mostrarDesde && semana < mostrarHasta)
                {
                    Simulacion.Add(vActual);
                }

                ////Agregar Fila final
                //tabla.LoadDataRow(vector, true);

                ////Setear Tabla
                //this.Info = tabla;
            }
            Simulacion.Add(vAnterior);

        }

        public VectorSimulacion getLastItemSimulacion()
        {
            return Simulacion.Last();
        }
    }
}

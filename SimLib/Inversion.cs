using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLib
{
    public class Inversion
    {
        [DisplayName("Inv Pro A")]
        public double InversionProyectoA { get; set; }
        [DisplayName("VPN Pro A")]
        public double VPNProyectoA { get; set; }
        [DisplayName("Inv Pro B")]
        public double InversionProyectoB { get; set; }
        [DisplayName("VPN Pro B")]
        public double VPNProyectoB { get; set; }
        [DisplayName("Inv Pro C")]
        public double InversionProyectoC { get; set; }
        [DisplayName("VPN Pro C")]
        public double VPNProyectoC { get; set; }
        [DisplayName("Cantidad")]
        public int Contador { get; set; }
        [DisplayName("Acum VPN")]
        public double VPNAcum { get; set; }
        //public double Probabilidad { get; set; }
    }
}

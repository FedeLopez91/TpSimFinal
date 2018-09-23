using System.ComponentModel;


namespace SimLib
{
    public class VectorSimulacion
    {
        [DisplayName("Fila")]
        public int NroFila { get; set; }
        [DisplayName("RND Pro A")]
        public double RndProyectoA { get; set; }
        [DisplayName("Inv Pro A")]
        public double InversionProyectoA { get; set; }
        //public double RndVPNProyectoA { get; set; }
        //public double VPNProyectoA { get; set; }
        [DisplayName("RND Pro B")]
        public double RndProyectoB { get; set; }
        [DisplayName("Inv Pro B")]
        public double InversionProyectoB { get; set; }
        //public double RndVPNProyectoB { get; set; }
        //public double VPNProyectoB { get; set; }
        [DisplayName("RND Pro C")]
        public double RndProyectoC { get; set; }
        [DisplayName("Inv Pro C")]
        public double InversionProyectoC { get; set; }

        [DisplayName("TOTAL")]
        public double SumPresupuesto { get; set; }
        [DisplayName("Es Válido?")]
        public string PresupuestoValido { get; set; }
        [DisplayName("RND VPN Pro A")]
        public double RndVPNProyectoA { get; set; }
        [DisplayName("VPN Pro A")]
        public double VPNProyectoA { get; set; }
        [DisplayName("RND VPN Pro B")]
        public double RndVPNProyectoB { get; set; }
        [DisplayName("VPN Pro B")]
        public double VPNProyectoB { get; set; }
        [DisplayName("RND VPN Pro C")]
        public double RndVPNProyectoC { get; set; }
        [DisplayName("VPN Pro C")]
        public double VPNProyectoC { get; set; }

        //public double AcumVPN { get; set; }
        //public double AcumMejorVPN { get; set; }

        //public double InversionMejorProyectoA { get; set; }
        //public double VPNMejorProyectoA { get; set; }
        //public double InversionMejorProyectoB { get; set; }
        //public double VPNMejorProyectoB { get; set; }
        //public double InversionMejorProyectoC { get; set; }
        //public double VPNMejorProyectoC { get; set; }
    }
}

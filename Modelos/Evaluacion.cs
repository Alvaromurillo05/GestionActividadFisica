using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    [Table("Evaluaciones")]
    public class Evaluacion
    {
        public long Id { get; set; }
        public DateTime Fecha {  get; set; }
        public int IdPersona { get; set; }
        public virtual Persona Persona { get; set; }
        public bool AntecendenteDiabetes { get; set; }
        public bool AntecendenteCancer { get; set; }
        public int IdCiudad { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public decimal Peso { get; set; }
        public decimal Talla { get; set; }
        public int IdRegimenAfiliacion { get; set; }
        public virtual RegimenAfiliacion RegimenAfiliacion { get; set; }
        public decimal PresionSistolica { get; set; }
        public decimal PresionDiastolica { get; set; }
        public decimal PliegueTriceps { get; set; }
        public decimal Biceps { get; set; }
        public decimal PliegueSubescapular { get; set; }
        public decimal PliegueCrestaIliaca { get; set; }
        public decimal PliegueSuparespinal { get; set; }
        public decimal PliegueAbdominal { get; set; }
        public decimal PliegueMuslo { get; set; }
        public decimal PlieguePierna { get; set; }
        public decimal PerimetroCintura { get; set; }
        public decimal PerimetroCadera { get; set; }
        public decimal PerimetroPierna { get; set; }
        public decimal PerimetroCodo { get; set; }
        public decimal DiametroRodilla { get; set; }
        public decimal BrazoDescansado { get; set; }
        public decimal BrazoTenso { get; set; }
        public decimal TestWells { get; set; }
        public decimal SaltoHorizontal { get; set; }
        public decimal TestVelocidad { get; set; }
        public decimal SaltoVertical { get; set; }
        public decimal TestAgilidad { get; set; }
        public decimal TestAbdominales { get; set; }
        public decimal TestPushUp { get; set; }
        public decimal PesoBarra { get; set; }
        public decimal PesoTotal { get; set; }
        public int RepeticionesVelocidad { get; set; }
        public decimal ManoDerechaDinamometria { get; set; }
        public decimal ManoIzquierdaDinamometria { get; set; }
        public int IntentosTestSentadilla { get; set; }
        public int RepeticionesTestSentadilla { get; set; }
        public decimal PuntajeTestResistenciaGeneral { get; set; }
    }
}

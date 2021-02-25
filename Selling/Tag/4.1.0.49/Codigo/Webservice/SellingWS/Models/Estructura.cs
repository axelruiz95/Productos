//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SellingWS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estructura
    {
        public Estructura()
        {
            this.Hueco = new HashSet<Hueco>();
        }
    
        public string ESTClave { get; set; }
        public string ALMClave { get; set; }
        public string AREClave { get; set; }
        public Nullable<int> TESTClave { get; set; }
        public string Clave { get; set; }
        public Nullable<int> Color { get; set; }
        public Nullable<decimal> Escala { get; set; }
        public Nullable<decimal> OrigenX { get; set; }
        public Nullable<decimal> OrigenY { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<decimal> Largo { get; set; }
        public Nullable<decimal> Alto { get; set; }
        public Nullable<decimal> Ancho { get; set; }
        public Nullable<int> Columnas { get; set; }
        public Nullable<int> Niveles { get; set; }
        public Nullable<int> TipoRotacion { get; set; }
        public string PasilloColoca { get; set; }
        public string PasilloRecoge { get; set; }
        public Nullable<bool> Rotada { get; set; }
        public string USRClave { get; set; }
        public Nullable<int> formaEnvioInicial { get; set; }
        public Nullable<int> formaEnvioFinal { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<bool> Baja { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
        public Nullable<int> SecuenciaRecoleccion { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Hueco> Hueco { get; set; }
    }
}
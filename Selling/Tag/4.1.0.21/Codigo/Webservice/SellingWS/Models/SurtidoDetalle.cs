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
    
    public partial class SurtidoDetalle
    {
        public int TipoDocumento { get; set; }
        public string DOCClave { get; set; }
        public string UBCClave { get; set; }
        public string PROClave { get; set; }
        public Nullable<int> TProducto { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Surtido { get; set; }
        public Nullable<decimal> Transito { get; set; }
        public Nullable<int> TipoRechazo { get; set; }
        public Nullable<decimal> Und { get; set; }
        public string AREClave { get; set; }
        public string Recolector { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
        public Nullable<int> RechazoRF { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
    }
}
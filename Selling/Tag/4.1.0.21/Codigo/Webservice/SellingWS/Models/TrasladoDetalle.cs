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
    
    public partial class TrasladoDetalle
    {
        public string DTRSClave { get; set; }
        public string TRSClave { get; set; }
        public Nullable<int> fila { get; set; }
        public string PROClave { get; set; }
        public Nullable<int> TProducto { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Recibido { get; set; }
        public Nullable<int> filaOriginal { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Traslado Traslado { get; set; }
    }
}
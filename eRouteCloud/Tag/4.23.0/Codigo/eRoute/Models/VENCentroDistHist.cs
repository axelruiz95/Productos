//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eRoute.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENCentroDistHist
    {
        public string VendedorId { get; set; }
        public string AlmacenId { get; set; }
        public System.DateTime VCHFechaInicial { get; set; }
        public Nullable<System.DateTime> FechaFinal { get; set; }
        public System.DateTime MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}
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
    
    public partial class RutaProductoEsquema
    {
        public string RUTClave { get; set; }
        public string EsquemaID { get; set; }
        public System.DateTime MFechaHora { get; set; }
        public string MUsuarioID { get; set; }
    
        public virtual Esquema Esquema { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
}
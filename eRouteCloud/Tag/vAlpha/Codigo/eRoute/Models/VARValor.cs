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
    
    public partial class VARValor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VARValor()
        {
            this.VAVDescripcion = new HashSet<VAVDescripcion>();
        }
    
        public string VARCodigo { get; set; }
        public string VAVClave { get; set; }
        public string Grupo { get; set; }
        public short Estado { get; set; }
        public System.DateTime MFechaHora { get; set; }
        public string ClaveSAT { get; set; }
        public string MUsuarioID { get; set; }
    
        public virtual ValorReferencia ValorReferencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VAVDescripcion> VAVDescripcion { get; set; }
    }
}
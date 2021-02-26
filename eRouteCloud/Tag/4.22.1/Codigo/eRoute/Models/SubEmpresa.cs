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
    
    public partial class SubEmpresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubEmpresa()
        {
            this.SEMHist = new HashSet<SEMHist>();
            this.Producto = new HashSet<Producto>();
            this.ExcepcionFac = new HashSet<ExcepcionFac>();
            this.TransProd = new HashSet<TransProd>();
        }
    
        public string SubEmpresaId { get; set; }
        public string ClaveSubEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreCorto { get; set; }
        public string RFC { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Localidad { get; set; }
        public string ReferenciaDom { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumeroInterior { get; set; }
        public string CodigoPostal { get; set; }
        public byte[] Logotipo { get; set; }
        public string Telefono { get; set; }
        public short TipoEstado { get; set; }
        public System.DateTime MFechaHora { get; set; }
        public string MUsuarioID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEMHist> SEMHist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExcepcionFac> ExcepcionFac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransProd> TransProd { get; set; }
    }
}
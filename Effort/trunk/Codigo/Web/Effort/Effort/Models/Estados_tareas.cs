//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Effort.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estados_tareas
    {
        public Estados_tareas()
        {
            this.Riesgos = new HashSet<Riesgos>();
            this.Tarea = new HashSet<Tarea>();
        }
    
        public int idEstado { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<Riesgos> Riesgos { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}

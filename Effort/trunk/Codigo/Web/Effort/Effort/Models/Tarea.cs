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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Tarea
    {
        public Tarea()
        {
            this.Esfuerzo = new HashSet<Esfuerzo>();
            this.Riesgos = new HashSet<Riesgos>();
        }
    
        public int idTarea { get; set; }
         [Required(ErrorMessage = "Campo obligatorio")]
        public string titulo { get; set; }
         [Required(ErrorMessage = "Campo obligatorio")]
        public string descripcion { get; set; }
        public Nullable<double> presupuesto { get; set; }
        public Nullable<double> horas_estimadas_dia { get; set; }
        public int idTipo { get; set; }
        public string idProyecto { get; set; }
        public string idEquipo { get; set; }
        public int idEstado { get; set; }
        public int idVersion { get; set; }
        public Nullable<int> predecesora { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }
        public double avanceTarea { get; set; }
    
        public virtual Equipo Equipo { get; set; }
        public virtual ICollection<Esfuerzo> Esfuerzo { get; set; }
        public virtual Estados_tareas Estados_tareas { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual ICollection<Riesgos> Riesgos { get; set; }
        public virtual Tipo_tarea Tipo_tarea { get; set; }
        public virtual Versiones Versiones { get; set; }
    }
}

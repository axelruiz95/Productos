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
    
    public partial class Venta
    {
        public string VENClave { get; set; }
        public Nullable<int> Periodo { get; set; }
        public Nullable<int> Mes { get; set; }
        public string PDVClave { get; set; }
        public string Folio { get; set; }
        public Nullable<int> Tipo { get; set; }
        public string Cliente { get; set; }
        public string Cajero { get; set; }
        public string CAJClave { get; set; }
        public Nullable<decimal> CostoTot { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> ImpuestoTot { get; set; }
        public Nullable<decimal> DescuentoTot { get; set; }
        public Nullable<decimal> RedondeoImp { get; set; }
        public Nullable<decimal> PuntosTot { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string FacturaId { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<bool> Baja { get; set; }
        public Nullable<bool> Acreditada { get; set; }
        public string Nota { get; set; }
        public string PICClave { get; set; }
        public string ALMClave { get; set; }
        public Nullable<int> Prioridad { get; set; }
        public string CajeroAnterior { get; set; }
        public string PDVAnterior { get; set; }
        public Nullable<int> MotivoCancelacion { get; set; }
        public string AutorizaCancelacion { get; set; }
        public Nullable<System.DateTime> FechaCancelacion { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
        public string MONClave { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        public Nullable<double> DescuentoDirecto { get; set; }
        public string FolioSAP { get; set; }
        public Nullable<int> EnvioConcentrador { get; set; }
        public string TipoAplicacion { get; set; }
        public Nullable<int> TipoImpuesto { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        public virtual Cliente Cliente1 { get; set; }
        public virtual Picking Picking { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
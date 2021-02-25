﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SellingWS.Models;
using SellingWS.Models.API;
using SellingWS.Models.RawQuery;
using SellingWS.Resources;

namespace SellingWS.Controllers
{
    /// <summary>
    /// Controlador de Ubicaciones
    /// </summary>
    public class UbicacionController : ApiController
    {
        private SellingEntities db = new SellingEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region CONSTANTES

        private readonly int TGrupoFamilia = 2;
        private readonly int TClasificacionProducto = 3;

        #endregion

        // GET api/Ubicacion/ProductosInventario
        /// <summary>
        /// Productos existentes en una Ubicación.
        /// </summary>
        /// <param name="id">El identificador de la Ubicación.</param>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public IEnumerable<ApiProductoInventario> ProductosInventario(string id, string ALMClave)
        {
            Ubicacion ubicacion =  (
                from u in db.Ubicacion
                where (u.Ubicacion1.Replace("-", "") == id.Replace("-", "") && u.Baja==false)
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                select u
            ).SingleOrDefault();

            if (ubicacion == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,Resources.Mensajes.Recibo_Ubicacion_NotFound));
            }

            CompanyParam tallaColor = db.CompanyParam.FirstOrDefault
                                        (tc => tc.PARClave == "TallaColor");
                                        

            IEnumerable<ApiProductoInventario> productos = null;

            if (tallaColor == null || tallaColor.Valor == "0")
            {
                productos = from p in db.Producto
                            where p.Baja == false
                            join peu in db.prd_exist_uba
                            on p.PROClave equals peu.PROClave
                            where peu.Existencia > 0
                            join u in db.Ubicacion
                            on new { peu.UBCClave, UBCClave1 = peu.UBCClave, Baja = (bool?)false } equals new { ubicacion.UBCClave, UBCClave1 = u.UBCClave, u.Baja }
                            select new ApiProductoInventario
                            {
                                PROClave = p.Clave,
                                Nombre = p.Nombre,
                                Estado = peu.Estado,
                                Existencia = peu.Existencia,
                                Apartado = peu.Apartado,
                                Bloqueado = peu.Bloqueado,
                                Color = "",
                                Talla = ""
                            };
            }
            else 
            {
                productos = from p in db.Producto
                            where p.Baja == false
                            join peu in db.prd_exist_uba
                            on p.PROClave equals peu.PROClave
                            where peu.Existencia > 0
                            join talla in db.ValorRef
                            on p.Talla equals talla.Valor
                            where talla.Campo=="Talla" && talla.Tabla=="Producto"
                            join color in db.ValorRef
                            on p.Color equals color.Valor
                            where color.Campo == "Color" && color.Tabla == "Producto"
                            join u in db.Ubicacion
                            on new { peu.UBCClave, UBCClave1 = peu.UBCClave, Baja = (bool?)false } equals new { ubicacion.UBCClave, UBCClave1 = u.UBCClave, u.Baja }
                            select new ApiProductoInventario
                            {
                                PROClave = p.Modelo,
                                Nombre = p.Nombre,
                                Estado = peu.Estado,
                                Existencia = peu.Existencia,
                                Apartado = peu.Apartado,
                                Bloqueado = peu.Bloqueado,
                                Talla = talla.Descripcion,
                                Color = color.Descripcion
                            };
            }
            return productos;
        }

        // GET api/Ubicacion/ValidarUbicacionCambioEstado/
        /// <summary>
        /// Si una ubicación es válida para Cambio de Estado.
        /// </summary>
        /// <param name="id">El identificador de la Ubicación.</param>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <returns>Boolean</returns>
        [HttpGet]
        public HttpResponseMessage ValidarUbicacionCambioEstado(string id, string ALMClave)
        {

            int? testClave = (from u in db.Ubicacion
                              where (u.Ubicacion1.Replace("-", "") == id.Replace("-", "") && u.Baja==false)
                              join e in db.Estructura
                                on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                              select e.TESTClave).FirstOrDefault();

            if (testClave == null) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.CambioEstado_Ubicacion_NotFound));

            //Podrá realizar el cambio de estado de un material dentro de una ubicación de cualquier tipo exceptuando las de tipo Transito
            if (testClave == 3)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.CambioEstado_Ubicacion_NoContent));

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // GET api/Ubicacion/ValidarOrigenReubicacion/
        /// <summary>
        /// Si una ubicación es válida para Reubicación.
        /// </summary>
        /// <param name="id">El identificador de la Ubicación.</param>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <returns>Boolean</returns>
        [HttpGet]
        public HttpResponseMessage ValidarOrigenReubicacion(string id, string ALMClave)
        {

            int? testClave = (from u in db.Ubicacion
                              where (u.Ubicacion1.Replace("-", "") == id.Replace("-", "") && u.Baja==false)
                              join e in db.Estructura
                                on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                              select e.TESTClave
                              ).FirstOrDefault();

            if (testClave == null) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Reubicacion_UbicacionOrigen_NotFound));

            //Solo permitirá cambio de ubicación que pertenezcan a una estructura de tipo almacenaje TESTClave=1 o TESTClave=2
            if (testClave != 1 && testClave != 2) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Reubicacion_UbicacionOrigen_NoContent));

            //Valida que la ubicación no este bloqueada por conteo
            int? estado = db.Ubicacion.FirstOrDefault(x => x.Ubicacion1.Replace("-", "") == id.Replace("-", "") && x.Baja==false).Estado;
            if (estado == 2)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Almacenaje_Ubicacion_NoContent2));

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage ValidaDestinoDefecto(string origenUBCClave, string destinoUBCClave, string SUCClave, string datos, string cantidades, string ALMClave)
        {
            string[] productoArray = datos.Split(',');//codigoMaterial,PRVClave,motivoDev
            string[] cantidadArray = cantidades.Split(',');

            //Almacen de devoluciones
            Almacen almDestino = (
                    from a in db.Almacen
                    where a.SUCClave == SUCClave && a.Baja == false
                    join e in db.Estructura
                        on new { a.ALMClave, Baja = (bool?)false } equals new { e.ALMClave, e.Baja }
                    join u in db.Ubicacion
                        on new { e.ESTClave, ubicacion = destinoUBCClave.Replace("-", ""), Baja = (bool?)false } equals new { u.ESTClave, ubicacion = u.Ubicacion1.Replace("-", ""), u.Baja }
                    select a
                ).Distinct().SingleOrDefault();

            if(almDestino == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Reubicacion_UbicacionDestino_NotFound));

            Ubicacion Ubicacion = (
                    from u in db.Ubicacion
                    where (u.Ubicacion1.Replace("-", "") == origenUBCClave.Replace("-", "") && u.Baja == false)
                    join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                    select u
            ).FirstOrDefault();


            if (Ubicacion == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Reubicacion_UbicacionOrigen_NotFound));

            Sucursal sucursal = db.Sucursal.FirstOrDefault(s => s.Baja == false && (s.SUCClave == SUCClave || s.Clave == SUCClave));

            string folio="";
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            string procedimiento;
            SqlConnection dbCon;
            SqlCommand cmd;
            
            //Crea el folio para el traspaso
            DataTable dtu = new DataTable();
            SqlDataAdapter du = new SqlDataAdapter();
            dbCon = db.Database.Connection as SqlConnection;

            procedimiento = "sp_recupera_folio";

            du.SelectCommand = new SqlCommand(procedimiento, dbCon);
            du.SelectCommand.CommandType = CommandType.StoredProcedure;
            du.SelectCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = 5;
            du.SelectCommand.Parameters.Add("@PDVClave", SqlDbType.VarChar).Value = ALMClave;
            du.Fill(dtu);
            du.Dispose();

            dtu.TableName = procedimiento;

            IEnumerable<ApiProveedor> folios = dtu.AsEnumerable().Select(row => new ApiProveedor
            {
                PRVClave = (row.Field<Int32>("UltimoConsecutivo")+1).ToString(),
                Clave = row.Field<Int32>("Mes").ToString(),
                RazonSocial = row.Field<Int32>("Periodo").ToString()
            });

            if (folios.Count() == 0)
            {
                folio = DateTime.Today.Year.ToString().Substring(2) + ("00" + DateTime.Today.Month.ToString()).Substring(1) + "-1";
                procedimiento = "sp_crea_folio";
                dbCon = db.Database.Connection as SqlConnection;
                cmd = new SqlCommand(procedimiento, dbCon);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Tipo", 5);
                cmd.Parameters.AddWithValue("PDVClave", ALMClave);

                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();
            }
            else 
            {
                ApiProveedor FolioTraspaso = folios.First();
                folio = FolioTraspaso.RazonSocial.Substring(2) + ("00" + FolioTraspaso.Clave).Substring(1) +"-"+FolioTraspaso.PRVClave;

                procedimiento = "sp_act_folio";
                dbCon = db.Database.Connection as SqlConnection;
                cmd = new SqlCommand(procedimiento, dbCon);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Tipo", 5);
                cmd.Parameters.AddWithValue("PDVClave", ALMClave);
                cmd.Parameters.AddWithValue("Incremento", 1);

                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();
            }
            
            folio = sucursal.Clave + folio;

            //Crea el traspaso entre almacenes
            string claveNueva = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();
            procedimiento = "sp_crea_transferencia";
            dbCon = db.Database.Connection as SqlConnection;
            cmd = new SqlCommand(procedimiento, dbCon);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("MVAClave", claveNueva);
            cmd.Parameters.AddWithValue("SUCClave", SUCClave);
            cmd.Parameters.AddWithValue("ALMClave", ALMClave);
            cmd.Parameters.AddWithValue("Tipo", 3);
            cmd.Parameters.AddWithValue("Motivo", "TRASPASO CALIDAD");
            cmd.Parameters.AddWithValue("Solicita", "");
            cmd.Parameters.AddWithValue("ALMDestino", almDestino.ALMClave);
            cmd.Parameters.AddWithValue("Folio", folio);
            cmd.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
            cmd.Parameters.AddWithValue("Registro", usrClave);
            cmd.Parameters.AddWithValue("Autorizo", usrClave);
            cmd.Parameters.AddWithValue("Notas", "");
            cmd.Parameters.AddWithValue("Estado", 2);
            cmd.Parameters.AddWithValue("Total", 0);
            cmd.Parameters.AddWithValue("UBCClave", Ubicacion.UBCClave);
            cmd.Parameters.AddWithValue("Usuario", usrClave);

            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();

            //Se crea el encabezado de devolucion
            db.Database.ExecuteSqlCommand(
                    "INSERT INTO Devolucion(DEVClave,Tipo,Periodo,Mes,Folio,Atendio,Fecha,Motivo,Estado,MFechaHora,MUsuarioId) " +
                    " VALUES(@DEVClave,@Tipo,@Periodo,@Mes,@Folio,@Atendio,@Fecha,@Motivo,@Estado,@MFechaHora,@MUsuarioId)",
                    new SqlParameter("@DEVClave", claveNueva),
                    new SqlParameter("@Tipo", "1"),
                    new SqlParameter("@Periodo", DateTime.Now.Year),
                    new SqlParameter("@Mes", DateTime.Now.Month),
                    new SqlParameter("@Folio", folio),
                    new SqlParameter("@Atendio", usrClave),
                    new SqlParameter("@Fecha", DateTime.Now),
                    new SqlParameter("@Motivo", productoArray[2]),
                    new SqlParameter("@Estado", "1"),
                    new SqlParameter("@MFechaHora", DateTime.Now),
                    new SqlParameter("@MUsuarioId", usrClave)
                );
            db.SaveChanges();

            string PROClave, PRVClave, Motivo;//codigoMaterial,PRVClave,motivoDev
            string DMVAClave;
            int contador;
            int fila = 0;
            for (int i = 0; i < productoArray.Length; i+=3)
            {
                contador = i;

                PROClave = productoArray[contador];
                PRVClave = productoArray[contador + 1];
                Motivo = productoArray[contador + 2];
                DMVAClave = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();

                Producto producto = (from p in db.Producto
                      where p.Baja == false &&
                      (p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.NumParte.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.Alterno1.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.Alterno2.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.Alterno3.Replace("-", "") == PROClave.Replace("-", "") ||
                      p.ProductoUnidad.Any(x => x.GTIN.Replace("-", "") == PROClave.Replace("-", "") && x.Factor == 1))
                    select p   
                ).FirstOrDefault();


                procedimiento = "sp_inserta_detalletransferencia";
                dbCon = db.Database.Connection as SqlConnection;
                cmd = new SqlCommand(procedimiento, dbCon);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DMVAClave", DMVAClave);
                cmd.Parameters.AddWithValue("MVAClave", claveNueva);
                cmd.Parameters.AddWithValue("PROClave", producto.PROClave);
                cmd.Parameters.AddWithValue("TProducto", producto.TProducto);
                cmd.Parameters.AddWithValue("Costo", producto.CostoVigente);
                cmd.Parameters.AddWithValue("Cantidad", cantidadArray[fila]);
                cmd.Parameters.AddWithValue("Fila", (fila+1) * 10);

                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();

                //Se inserta el detalle de la devolucion
                procedimiento = "sp_inserta_devdet";
                dbCon = db.Database.Connection as SqlConnection;
                cmd = new SqlCommand(procedimiento, dbCon);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DEVClave", claveNueva);
                cmd.Parameters.AddWithValue("Partida", (fila + 1) * 10);
                cmd.Parameters.AddWithValue("PROClave", producto.PROClave);
                cmd.Parameters.AddWithValue("TProducto", producto.TProducto);
                cmd.Parameters.AddWithValue("Costo", producto.CostoVigente);
                cmd.Parameters.AddWithValue("Precio", 0);
                cmd.Parameters.AddWithValue("Cantidad", cantidadArray[fila]);
                cmd.Parameters.AddWithValue("Subtotal", 0);
                cmd.Parameters.AddWithValue("Descuento", 0);
                cmd.Parameters.AddWithValue("Impuesto", 0);
                cmd.Parameters.AddWithValue("Puntos", 0);
                cmd.Parameters.AddWithValue("Total", 0);
                cmd.Parameters.AddWithValue("Motivo", Motivo);
                cmd.Parameters.AddWithValue("Defecto", "1");
                cmd.Parameters.AddWithValue("PRVClave", PRVClave);

                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();


                fila++;
            }



            //Crea el movimiento de salida del almacen origen
            procedimiento = "st_genera_movimiento";
            dbCon = db.Database.Connection as SqlConnection;
            cmd = new SqlCommand(procedimiento, dbCon);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TipoMov", 2);
            cmd.Parameters.AddWithValue("Motivo", 6);
            cmd.Parameters.AddWithValue("ALMClave", ALMClave);
            cmd.Parameters.AddWithValue("TipoDoc", 6);
            cmd.Parameters.AddWithValue("Documento",claveNueva);
            cmd.Parameters.AddWithValue("Referencia",folio);
            cmd.Parameters.AddWithValue("Autorizo", usrClave);
            cmd.Parameters.AddWithValue("Picking", 0);
            cmd.Parameters.AddWithValue("Usuario", usrClave);
            cmd.Parameters.AddWithValue("AfectaInv", 1);
            cmd.Parameters.AddWithValue("Ubicacion", Ubicacion.UBCClave);
            
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();


            Ubicacion UBCClaveDest = db.Ubicacion.SingleOrDefault(x => x.Ubicacion1.Replace("-","") == destinoUBCClave.Replace("-",""));

            //Crea el movimiento de salida del almacen destino
            procedimiento = "st_genera_movimiento";
            dbCon = db.Database.Connection as SqlConnection;
            cmd = new SqlCommand(procedimiento, dbCon);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("TipoMov", 1);
            cmd.Parameters.AddWithValue("Motivo", 6);
            cmd.Parameters.AddWithValue("ALMClave", almDestino.ALMClave);
            cmd.Parameters.AddWithValue("TipoDoc", 6);
            cmd.Parameters.AddWithValue("Documento",claveNueva);
            cmd.Parameters.AddWithValue("Referencia",folio);
            cmd.Parameters.AddWithValue("Autorizo", usrClave);
            cmd.Parameters.AddWithValue("Picking", 0);
            cmd.Parameters.AddWithValue("Usuario", usrClave);
            cmd.Parameters.AddWithValue("AfectaInv", 1);
            cmd.Parameters.AddWithValue("Ubicacion", UBCClaveDest.UBCClave);
            
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();


            //Obtiene los diferentes destinos para crear el traspaso

            /*dbCon = db.Database.Connection as SqlConnection;
            procedimiento = "st_muestra_suc_devolucion";
            du.SelectCommand = new SqlCommand(procedimiento, dbCon);
            du.SelectCommand.CommandType = CommandType.StoredProcedure;
            du.SelectCommand.Parameters.Add("@DEVClave", SqlDbType.VarChar).Value = claveNueva;
            du.Fill(dtu);
            du.Dispose();

            dtu.TableName = procedimiento;

            ApiProveedor[] destinos = dtu.AsEnumerable().Select(row => new ApiProveedor
            {
                PRVClave = row.Field<String>("SUCClave"),
                Clave = row.Field<String>("ALMClave")
            }).ToArray();
            
            for(int i=0; i < destinos.Count(); i++)
            {*/
                try
                {
                    procedimiento = "st_crea_traslado_autHH";
                    dbCon = db.Database.Connection as SqlConnection;
                    cmd = new SqlCommand(procedimiento, dbCon);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DEVClave", claveNueva);
                    cmd.Parameters.AddWithValue("SUCClave", SUCClave);
                    cmd.Parameters.AddWithValue("ALMClave", almDestino.ALMClave);
                    cmd.Parameters.AddWithValue("UBCClave", UBCClaveDest.UBCClave);
                    //cmd.Parameters.AddWithValue("SUCDestino", destinos[i].PRVClave);
                    //cmd.Parameters.AddWithValue("ALMDestino", destinos[i].Clave);
                    cmd.Parameters.AddWithValue("Usuario", usrClave);
                    //cmd.Parameters.AddWithValue("Todos", 0);

                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                    dbCon.Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
                }
            //}
            
            //Crea el cargo a proveedor 
            procedimiento = "st_crea_cargoproveedor";
            dbCon = db.Database.Connection as SqlConnection;
            cmd = new SqlCommand(procedimiento, dbCon);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NCClave", claveNueva);
            cmd.Parameters.AddWithValue("Usuario", usrClave);
            cmd.Parameters.AddWithValue("DEVClave", 1);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            dbCon.Close();

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // GET api/Ubicacion/ValidarUbicacionAlmacenaje/
        /// <summary>
        /// Si una ubicación es válida para Almacenaje.
        /// </summary>
        /// <param name="id">El identificador de la Ubicación.</param>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <returns>HttpStatusCode</returns>
        [HttpGet]
        public HttpResponseMessage ValidarUbicacionAlmacenaje(String id, string ALMClave)
        {
            var origen = (from u in db.Ubicacion
                where (u.Ubicacion1.Replace("-", "") == id.Replace("-", "") && u.Baja==false)
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                select new {Estructura = e, Ubicacion = u}
            ).FirstOrDefault();

            //C 2.1 validara que la ubicación exista. De lo contrario enviar mensaje de error.
            if (origen == null) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Almacenaje_Ubicacion_NotFound));

            
            //C 2.2 valida que la ubicación sea de tipo Stage (2) o transito (3), de lo contrario enviar mensaje de error.
            if (!(origen.Estructura.TESTClave == 2 || origen.Estructura.TESTClave == 3) )
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Almacenaje_Ubicacion_NoContent));

           
            // valida que la ubicacion de transito no se encuentre en proceso de recibo en cualquier documento 
            if (origen.Estructura.TESTClave == 3)
            {
                ReciboAlmacenT recT = db.ReciboAlmacenT.FirstOrDefault(x => x.UBCClave == origen.Ubicacion.UBCClave && x.Estado == 1);

                if (recT != null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Ubicacion_Transito_Utilizado));
            }

            //C 2.3 Valida que la ubicación no este bloqueada.
            if ((origen.Ubicacion.Estado == 0 || origen.Ubicacion.Estado == 2) && origen.Estructura.TESTClave!=3)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Almacenaje_Ubicacion_NoContent2));
                        
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // GET api/Ubicacion/ValidarAjusteInventario
        /// <summary>
        /// Si una ubicación es válida para Ajuste de Inventario.
        /// </summary>
        /// <param name="Ubicacion">El identificador de la Ubicación.</param>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <returns>HttpStatusCode</returns>
        [HttpGet]
        public HttpResponseMessage ValidarAjusteInventario(String Ubicacion, string ALMClave)
        {
            var origen = (from u in db.Ubicacion
                          where u.Ubicacion1.Replace("-","") == Ubicacion.Replace("-","") && u.Baja==false
                          join e in db.Estructura
                              on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                          select new { Estructura = e, Ubicacion = u }
            ).FirstOrDefault();

            //G 1 Se validara que exista la ubicación
            if (origen == null) //Existe?
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.AjusteInventario_Ubicacion_NotFound));

            //G 1 y que pertenezca a una estructura  de tipo Stage(1) o Almacenaje(2)
            if (!(origen.Estructura.TESTClave == 1 || origen.Estructura.TESTClave == 2))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.AjusteInventario_Ubicacion_NoContent));

            //Valida que la ubicación no este bloqueada por conteo
            if (origen.Ubicacion.Estado == 2)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Almacenaje_Ubicacion_NoContent2));

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // GET api/Ubicacion/Recibo/
        /// <summary>
        /// Si una ubicación es válida para Recibir, recibe en caso de que sea válido
        /// </summary>
        /// <param name="UBCClave">Nombre de la ubicacion</param>
        /// <param name="ALMClave">Clave del Almacén</param>
        /// <param name="crearUBC">Si solicita crear la ubicacion en caso de que no exista </param>
        /// <param name="PROClave">Clave del Producto</param>
        /// <param name="IdRecibo">Clave del Recibo</param>
        /// <param name="cantidad">Cantidad de prodcuto</param>
        /// <returns>HttpStatusCode</returns>
        [HttpGet]
        public HttpResponseMessage Recibo(string UBCClave, string ALMClave, bool crearUBC, string PROClave, string IdRecibo, decimal cantidad)
        {
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();
            
            ReciboAlmacen recibo = db.ReciboAlmacen.FirstOrDefault(x=>x.ALMClave == ALMClave && x.IdRecibo == IdRecibo);

            if(recibo==null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Recibo_IdRecibo_NotFound));

            //Si el recibo ya no está en Proceso (Estado == 1) regresar error
            if(recibo.Estado != 1)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { enProceso = false }));
            
            var destino = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == UBCClave.Replace("-", "") && u.Baja==false
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                select new { Ubicacion = u, Estructura = e }
            ).FirstOrDefault();

            Ubicacion ubicacion = null;
            Estructura estructura = null;
            
            if(destino != null){
                ubicacion = destino.Ubicacion;
                estructura = destino.Estructura;
            }

            if(ubicacion == null && crearUBC==false) //No existe y no se va a crear
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { ubicacionNoExiste = true }));
            
            decimal codigo;
            List<PaqueteDetalle> paqueteDetalle;

            Producto productoVal = db.Producto.SingleOrDefault(p =>
                p.Baja == false &&
                p.Clave.Replace("-", "") == PROClave.Replace("-", "") ||
                p.NumParte == PROClave ||
                p.Alterno1 == PROClave ||
                p.Alterno2 == PROClave ||
                p.Alterno3 == PROClave ||
                p.ProductoUnidad.Any(x => x.GTIN == PROClave && x.Factor == 1)
              );


            if (productoVal == null)
            {
                paqueteDetalle = db.Database.SqlQuery<PaqueteDetalle>(
                        "select pd.PROClave, pd.Cantidad from PaqueteDetalle pd inner join Paquete p on p.IdPaquete = pd.IdPaquete " +
                        "and p.IdPaquete=@IdPaquete and p.Estado=1 and Baja=0",
                        new SqlParameter("@IdPaquete", PROClave)
                    ).ToList();
            }
            else 
            {
                PaqueteDetalle paqDet = new PaqueteDetalle();
                paqDet.cantidad = cantidad;
                paqDet.PROClave = PROClave;
                paqueteDetalle = new List<PaqueteDetalle>();
                paqueteDetalle.Add(paqDet);
            }
            
            foreach (PaqueteDetalle detalles in paqueteDetalle) 
            {
                PROClave = detalles.PROClave;
                cantidad = (decimal)detalles.cantidad;
                //Existe el producto?
                Producto producto = db.Producto.FirstOrDefault
                    (p =>
                        p.Baja==false &&
                        (p.Clave.Replace("-", "") == PROClave.Replace("-", "") || 
                        p.NumParte == PROClave || 
                        p.Alterno1 == PROClave || 
                        p.Alterno2 == PROClave || 
                        p.Alterno3 == PROClave || 
                        p.ProductoUnidad.Any(x => (x.GTIN == PROClave) && x.Factor == 1))
                    );
                if (producto == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        Resources.Mensajes.Recibo_Producto_NotFound));

                if (ubicacion==null)//Primero crear la Ubicacion
                {
                    //B 4 El sistema recupera la primer estructura de Tipo Transito  que se encuentre
                    estructura = db.Estructura.First(x=>x.Baja==false && x.ALMClave==ALMClave && x.TESTClave==3);
                    
                    if (estructura == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Recibo_EstructuraTransito_NotFound));

                    var nuevaUbcClave = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();
                    //B 4 Se le crea en el único hueco que contiene la nueva ubicación
                    ubicacion = new Ubicacion
                    {
                        UBCClave = nuevaUbcClave,
                        ESTClave = estructura.ESTClave,
                        HUEClave = estructura.Hueco.First().HUEClave,
                        Estado = 0,
                        Fase = 1,
                        MFechaHora = DateTime.Now,
                        MUsuarioId = usrClave,
                        Ubicacion1 = UBCClave,
                        Volumen = 0,
                        Baja = false
                    };

                    db.Ubicacion.Add(ubicacion);
                    db.SaveChanges();

                    prd_exist_uba peu = new prd_exist_uba
                    {
                        UBCClave = nuevaUbcClave,
                        PROClave = producto.PROClave,
                        Existencia = 0,
                        Estado = 0,
                        MFechaHora = DateTime.Now,
                        MUsuarioId = usrClave,
                        Apartado = 0,
                        Bloqueado = 0
                    };

                    db.prd_exist_uba.Add(peu);
                    db.SaveChanges();
                }

                //B 4 si existe verifica que sea de tipo transito de lo contrario envía mensaje de error
                if (estructura.TESTClave != 3)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        Resources.Mensajes.Recibo_Ubicacion_NoTransito));

                //Validar que la ubicacion no este utilizada 
                //ReciboAlmacenT recT = db.ReciboAlmacenT.FirstOrDefault(x => x.IdRecibo != recibo.IdRecibo && x.UBCClave == ubicacion.UBCClave && x.Estado != 2);
                var recT = (
                             from RA in db.ReciboAlmacen
                             join RAT in db.ReciboAlmacenT
                             on new { RA.IdRecibo } equals new { RAT.IdRecibo }
                             where RA.Estado != 2 && RAT.IdRecibo != recibo.IdRecibo && RAT.UBCClave == ubicacion.UBCClave
                             select new {RAT}
                           ).FirstOrDefault();

                if (recT != null)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                           Resources.Mensajes.Ubicacion_Utilizada));
                }
          
                
                //Si no tiene estrategia
                Estrategia areaEstrategia = producto.Estrategia.FirstOrDefault(x=>x.ALMClave==ALMClave && x.Ubicacion.Baja==false);
                if (areaEstrategia == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        Resources.Mensajes.Recibo_Estrategia_NotFound));

                //B 5 Si la ubicación no esta vacía, valida que área de los productos en la ubicación en transito sea igual a la del producto leído
                if (ubicacion.prd_exist_uba.Count(x => x.Existencia > 0) > 0 &&
                    !ubicacion.prd_exist_uba.Any(
                        x => x.Producto.Estrategia.Any(estra => estra.ALMClave == ALMClave && estra.Ubicacion.Baja == false && estra.AREClave == areaEstrategia.AREClave)))
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        Resources.Mensajes.Recibo_Ubicacion_NoArea));

                //B 5.1 incrementara la cantidad recibida del material en el detalle de la orden de recibo
            
                IEnumerable<ReciboAlmacenD> recibosDetalle =
                    recibo.ReciboAlmacenD.Where(x => x.PROClave == producto.PROClave && x.Recibido < x.Cantidad);
                decimal? cantidadPorAcomodar = cantidad;
                decimal? cantidadRecibida;
                foreach (ReciboAlmacenD reciboDetalle in recibosDetalle)
                {
                    if (reciboDetalle.Cantidad - reciboDetalle.Recibido <= 0)
                        continue;
                    cantidadRecibida = reciboDetalle.Cantidad - reciboDetalle.Recibido > cantidadPorAcomodar
                        ? cantidadPorAcomodar
                        : reciboDetalle.Cantidad - reciboDetalle.Recibido;
                    reciboDetalle.Recibido += cantidadRecibida;
                    cantidadPorAcomodar -= cantidadRecibida;
                    if (cantidadPorAcomodar <= 0)
                        break;
                }
                decimal? cantidadAcomodada = cantidad - cantidadPorAcomodar;
                recibo.CantidadRecibida += cantidadAcomodada;

                //validar si existe la ubicacion con el recibo.idRecibo y ubicacion.ubcClave
                ReciboAlmacenT reciboT = db.ReciboAlmacenT.FirstOrDefault(x => x.IdRecibo == recibo.IdRecibo && x.UBCClave == ubicacion.UBCClave);
                if (reciboT == null)
                {
                    reciboT = new ReciboAlmacenT
                    {
                        IdRecibo = recibo.IdRecibo,
                        UBCClave = ubicacion.UBCClave,
                        Estado = 1,
                        MFechaHora = DateTime.Now,
                        MUsuarioId = usrClave
                    };
                    db.ReciboAlmacenT.Add(reciboT);
                }
                else
                {
                    reciboT.Estado = 1;
                    reciboT.MFechaHora = DateTime.Now;
                    reciboT.MUsuarioId = usrClave;

                }

                db.SaveChanges();

                //      agregara el material a la existencia del Transito los cuales estarán bloqueados 
                prd_exist_uba prdExistUba = ubicacion.prd_exist_uba.FirstOrDefault(x => x.PROClave == producto.PROClave);
           
                if (prdExistUba != null)
                {
                    prdExistUba.Existencia += cantidadAcomodada;
                    prdExistUba.Bloqueado += cantidadAcomodada;
                }
                else
                {

                    prdExistUba = new prd_exist_uba
                    {
                        UBCClave = ubicacion.UBCClave,
                        PROClave = producto.PROClave,
                        Existencia = cantidadAcomodada,
                        Estado = 0,
                        MFechaHora = DateTime.Now,
                        MUsuarioId = usrClave,
                        Apartado = 0,
                        Bloqueado = cantidadAcomodada
                    };

                    db.prd_exist_uba.Add(prdExistUba);
                }
                db.SaveChanges();

                //      e incrementar la cantidad de bloqueados por Almacen  y producto
                Existencia existenciaAlmacen =
                    db.Existencia.FirstOrDefault(x => x.PROClave == producto.PROClave && x.ALMClave == recibo.ALMClave);
                if (existenciaAlmacen != null)
                {
                    existenciaAlmacen.Existencia1 += cantidadAcomodada;
                    existenciaAlmacen.Bloqueado += cantidadAcomodada;
                }
                else
                {
                    existenciaAlmacen = new Existencia
                    {
                        ALMClave = ALMClave,
                        Apartado = 0,
                        Bloqueado = cantidadAcomodada,
                        Existencia1 = cantidadAcomodada,
                        MFechaHora = DateTime.Now,
                        MUsuarioId = usrClave,
                        PROClave = producto.PROClave
                    };
                    db.Existencia.Add(existenciaAlmacen);
                }
                try
                {
                    //Agregar un MovUbc
                    var nuevaReferencia = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();
                    db.Database.ExecuteSqlCommand(
                        "INSERT INTO MovUbc(MOVClave,Periodo,Mes,SUCClave,ALMClave,UBCClaveO,UBCClaveD,PROClave,TipoMov,Motivo,Cantidad,TipoEstado,Nota,MFechaHora,MUsuarioId,Plataforma) " +
                        " VALUES(Right(newid(),20),@Periodo,@Mes,@SUCClave,@ALMClave,@UBCClaveO,@UBCClaveD,@PROClave,@TipoMov,@Motivo,@Cantidad,@TipoEstado,@Nota,@MFechaHora,@MUsuarioId,@Plataforma)",
                        new SqlParameter("@Periodo", DateTime.Now.Year),
                        new SqlParameter("@Mes", DateTime.Now.Month),
                        new SqlParameter("@SUCClave", recibo.Almacen.SUCClave),
                        new SqlParameter("@ALMClave", recibo.ALMClave),
                        new SqlParameter("@UBCClaveO", recibo.Anden),
                        new SqlParameter("@UBCClaveD", ubicacion.UBCClave),
                        new SqlParameter("@PROClave", producto.PROClave),
                        new SqlParameter("@TipoMov", 1), //Recibo
                        new SqlParameter("@Motivo", 9), //Ingreso
                        new SqlParameter("@Cantidad", cantidadAcomodada),
                        new SqlParameter("@TipoEstado", prdExistUba.Estado),
                        new SqlParameter("@Nota", recibo.IdRecibo),
                        new SqlParameter("@MFechaHora", DateTime.Now),
                        new SqlParameter("@MUsuarioId", usrClave),
                        new SqlParameter("@Plataforma", "RF")
                    );

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Mensajes.General_Error));
                }

                if (cantidadPorAcomodar > 0)
                {
                    //Imprimir a Archivo de Log
                    log.Info(
                        String.Format(
                            "Excedente!! IdRecibo:{0}, PROClave:{1}, cantidad:{2}, cantidadPorAcomodar:{3}, Fecha:{4}, Usuario:{5}",
                            IdRecibo, producto.PROClave, cantidad, cantidadPorAcomodar, DateTime.Now, usrClave));
                    var idReciboSobrante = db.Database.SqlQuery<string>("SELECT Right(newid(),20)").First();
                    //Agregar a ReciboSobrante
                    db.Database.ExecuteSqlCommand(
                        "INSERT INTO ReciboSobrante(IdSobrante,IdRecibo,PROClave,TProducto,Cantidad,MFechaHora,MUsuarioId) " +
                        " VALUES(@idReciboSobrante,@IdRecibo,@PROClave,@TProducto,@Cantidad,@MFechaHora,@MUsuarioId)",
                        new SqlParameter("@IdReciboSobrante", idReciboSobrante),
                        new SqlParameter("@IdRecibo", IdRecibo),
                        new SqlParameter("@PROClave", producto.PROClave),
                        new SqlParameter("@TProducto", producto.TProducto),
                        new SqlParameter("@Cantidad", cantidadPorAcomodar),
                        new SqlParameter("@MFechaHora", DateTime.Now),
                        new SqlParameter("@MUsuarioId", usrClave)
                        );
                    log.Info(
                        String.Format(
                            "Excedente registrado!! IdRecibo:{0}, PROClave:{1}, cantidad:{2}, cantidadPorAcomodar:{3}, Fecha:{4}, Usuario:{5}",
                            IdRecibo, producto.PROClave, cantidad, cantidadPorAcomodar, DateTime.Now, usrClave));
                    String mensaje = "Se ha excedido "+cantidadPorAcomodar+" unidad(es) del material "+producto.Clave;
                    return Request.CreateResponse(HttpStatusCode.OK, new {idReciboSobrante,mensaje});

                    //Mandar mensaje de los cantidad por acomodar del producto
                    //Se ha excedido cantidadPorAcomodar unidades del material producto.clave
                }
        }
            return Request.CreateResponse(HttpStatusCode.OK, new {Exito = true, Ubicacion = ubicacion.UBCClave});
        }

        // GET api/Ubicacion/Andenes
        /// <summary>
        /// Andenes disponibles en un Almacén
        /// </summary>
        /// <param name="ALMClave">El identificador del Almacén.</param>
        /// <returns>ApiProductoInventario</returns>
        [HttpGet]
        public IEnumerable<ApiUbicacionAndenes> Andenes(string ALMClave)
        {
            //Una ubicación se considera Anden cuando se encuentra asociada a una Estructura que sea de Tipo Anden (TESTClave=0).
            IEnumerable<ApiUbicacionAndenes> ubicaciones = from u in db.Ubicacion
                                                           where u.Baja == false
                                                           join e in db.Estructura
                                                              on new { u.ESTClave, ALMClave, TESTClave = (int?)0,  Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.TESTClave, e.Baja }
                                                           join ra in db.ReciboAlmacen
                                                              on new { UBCClave = u.UBCClave, ALMClave, Estado = (int?)1 } equals new { UBCClave = ra.Anden, ra.ALMClave, ra.Estado }
                                                           select new ApiUbicacionAndenes
                                                           {
                                                               IdRecibo = ra.IdRecibo,
                                                               Folio = ra.Folio,
                                                               Anden = u.Ubicacion1,
                                                               PorcentajeRecibo = ra.CantidadRecibida / ra.CantidadSolicitada * 100,
                                                               NumPiezas = ra.CantidadSolicitada
                                                           };

            return ubicaciones;
        }

        // GET api/Ubicacion/AlmacenajeDirigido/
        /// <summary>
        /// Devuelve una ubicación de sugerencia para el almacenaje Dirigido.
        /// </summary>
        /// <param name="ALMClave">La clave del Almacén.</param>
        /// <param name="Producto">La clave del Producto.</param>
        /// <param name="cantidad">Cantidad de Producto a almacenar</param>
        /// <returns>HttpStatusCode</returns>
        [HttpGet]
        public HttpResponseMessage AlmacenajeDirigido(string ALMClave, string Producto, decimal cantidad)
        {
            Producto productoInstance = (
                from p in db.Producto
                where p.Baja==false &&
                      (p.Clave.Replace("-", "") == Producto.Replace("-", "") ||
                      p.NumParte.Replace("-", "") == Producto.Replace("-", "") ||
                      p.Alterno1.Replace("-", "") == Producto.Replace("-", "") ||
                      p.Alterno2.Replace("-", "") == Producto.Replace("-", "") ||
                      p.Alterno3.Replace("-", "") == Producto.Replace("-", "") ||
                      p.ProductoUnidad.Any(x => x.GTIN.Replace("-", "") == Producto.Replace("-", "") && x.Factor == 1))
                select p
            ).FirstOrDefault();

            if(productoInstance==null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Producto"));

            //C 4.1 Primero buscara colocarla en su ubicación de picking asignada
            var pickingAsignada = (
                from estra in db.Estrategia
                where estra.ALMClave == ALMClave && estra.PROClave == productoInstance.PROClave
                join u in db.Ubicacion
                    on new { estra.UBCClave, Baja = (bool?)false } equals new { u.UBCClave, u.Baja }
                where u.Estado != 0 //Que la ubicación no este bloqueada.
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.Baja }
                join peu1 in db.prd_exist_uba
                    on new { u.UBCClave, productoInstance.PROClave } equals new { peu1.UBCClave, peu1.PROClave } into peuLeft
                from peu in peuLeft.DefaultIfEmpty()
                group peu by new { e, estra, u } into peuGroup
                //validara que la  capacidad máxima de piezas de la ubicación – existencia actual sea mayor o igual a la cantidad a Almacenar.
                where (peuGroup.Key.estra.Capacidad - (peuGroup.Sum(x => x.Existencia) ?? 0)) >= cantidad
                select new
                {
                    peuGroup.Key.u.UBCClave,
                    Ubicacion = peuGroup.Key.u.Ubicacion1,
                    Area = peuGroup.Key.estra.Area.Nombre,
                    Existencia = peuGroup.Sum(x => x.Existencia) ?? 0
                }
            ).FirstOrDefault();
            

            if(pickingAsignada != null)
                return Request.CreateResponse(HttpStatusCode.OK, pickingAsignada);

            //C 5.1.1 Busca ubicación vacia en la misma área que tiene asignada como picking (Estrategia.AREClave) , 
            //        si es ubicación vacia suma de existencia en PRD_EXIST_UBA sea cero o que no tenga un registro en prd_exist_uba.
            if (!productoInstance.Estrategia.Any())
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    Resources.Mensajes.Almacenaje_Estrategia_NotFound));
            Estrategia estrategiaArea = productoInstance.Estrategia.First(ar => ar.ALMClave == ALMClave && ar.PROClave == productoInstance.PROClave);
            
            IEnumerable<VolumenUbicacion> sugerencias = (
                from u in db.Ubicacion
                where u.Baja==false
                join est in db.Estructura
                    on new { u.ESTClave, ALMClave, Baja = (bool?)false } equals new { est.ESTClave, est.ALMClave, est.Baja }
                join are in db.Area
                    on new { AREClave1 = est.AREClave, AREClave2 = estrategiaArea.AREClave, Baja = (bool?)false } equals new { AREClave1 = are.AREClave, AREClave2 = are.AREClave, are.Baja }
                join peu1 in db.prd_exist_uba
                    on u.UBCClave equals peu1.UBCClave into peuJ
                from peu in peuJ.DefaultIfEmpty()
                group peu by new
                {
                    are.Nombre,
                    are.AREClave,
                    u.UBCClave,
                    u.Ubicacion1
                } into grouped
                select new 
                {
                    Area = grouped.Key.Nombre,
                    grouped.Key.AREClave,
                    grouped.Key.UBCClave,
                    Ubicacion = grouped.Key.Ubicacion1,
                    Cantidad = grouped.Sum(peu1 => peu1.Existencia)
                }).Where(x => x.Cantidad > 0 && x.Cantidad != null).Select(y => new VolumenUbicacion { Area = y.Area, AREClave = y.AREClave, UBCClave = y.UBCClave, Ubicacion = y.Ubicacion });

            if (sugerencias.Any())
                return Request.CreateResponse(HttpStatusCode.OK, sugerencias.First());
            
            //Si no se cumple lo anterior, se busca una ubicación de tipo almacenaje que contenga producto que sea del mismo grupo de material (clasprod.PROClave y ClasProd.CLAClave) que el producto que se quiera colocar 
            //y el volumen disponible sea suficiente para colocar el material 
            //y que no estén bloqueadas
            var volumenOcupar = productoInstance.ProductoUnidad.First(x => x.Factor == 1).Volumen * cantidad;
            int grupo = productoInstance.ClasProd.First(cp1 => cp1.Clasificacion.TClasificacion == TClasificacionProducto && cp1.Clasificacion.TGrupo == TGrupoFamilia).CLAClave;
            IEnumerable<VolumenUbicacion> sugerencias2 = db.Database.SqlQuery<VolumenUbicacion>(
                "select distinct " +
                "a.AREClave, " +
                "a.Nombre as Area, " +
                "u.UBCClave, " +
                "u.Ubicacion, " +
                "u.Volumen * (t.Porc_Aprob_Hueco /100) as Volumen, " +
                "ISNULL( " +
                "    (select sum(pe.Existencia * pu.Volumen ) from prd_exist_uba pe inner join ProductoUnidad pu on pe.UBCClave=u.UBCClave and pe.PROClave=pu.PROClave and pu.Factor=1 and pe.Existencia > 0 ) " +
                ",0) VolumenOcupado " +
                "from Estructura e " +
                "inner join TipoEstructura t on e.Baja=0 and e.TESTClave=t.TESTClave and e.ALMClave = @ALMClave and e.TESTClave = 1 " +
                "inner join Ubicacion u on u.Baja=0 and e.ESTClave=u.ESTClave " +
                "inner join Area a on a.Baja=0 and e.AREClave=a.AREClave " +
                "inner join prd_exist_uba pe on u.UBCClave=pe.UBCClave and pe.PROClave in " +
                "(select cp.PROClave from ClasProd cp where  cp.CLAClave = @Grupo ) ",
                new SqlParameter("@ALMClave", ALMClave),
                new SqlParameter("@Grupo", grupo)
            ).Where(vu => (vu.Volumen - vu.VolumenOcupado - volumenOcupar >= 0 || vu.Volumen == 0));

            if (sugerencias2.Any())
                return Request.CreateResponse(HttpStatusCode.OK, sugerencias2.First());

            //No se encontro ubicación sugerida
            return Request.CreateResponse(HttpStatusCode.OK, new { encontrado = false });
        }

        // GET api/Ubicacion/ReciboAnden/
        /// <summary>
        /// Valida si un andén es valido para recibir
        /// </summary>
        /// <param name="IdRecibo">Clave del Recibo</param>
        /// <param name="ALMClave">Clave del Almacén</param>
        /// <param name="UBCClave">Nombre de la ubicacion</param>
        /// <returns>HttpStatusCode</returns>
        [HttpGet]
        public HttpResponseMessage ReciboAnden(string IdRecibo, string ALMClave, string UBCClave)
        {
            string usrClave = HttpContext.Current.Items["USRClave"].ToString();

            ReciboAlmacen recibo = db.ReciboAlmacen.FirstOrDefault(x => x.ALMClave == ALMClave && x.IdRecibo == IdRecibo);
            if (recibo == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Recibo_IdRecibo_NotFound));

            //Si el recibo ya no está en Proceso (Estado == 1) regresar error
            if (recibo.Estado != 1)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { enProceso = false }));

            var anden = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == UBCClave.Replace("-", "") && u.Baja == false
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, TESTClave = (int?)0, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.TESTClave, e.Baja }
                select new { Ubicacion = u }
            ).FirstOrDefault();

            if (anden == null) //No existe el código de la ubicación (anden)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { andenNoExiste = true }));

            var andenRecibo = (
                from u in db.Ubicacion
                where u.Ubicacion1.Replace("-", "") == UBCClave.Replace("-", "") && u.Baja == false
                join e in db.Estructura
                    on new { u.ESTClave, ALMClave, TESTClave = (int?)0, Baja = (bool?)false } equals new { e.ESTClave, e.ALMClave, e.TESTClave, e.Baja }
                join ra in db.ReciboAlmacen
                    on new { IdRecibo, UBCClave = u.UBCClave, ALMClave, Estado = (int?)1 } equals new { ra.IdRecibo, UBCClave = ra.Anden, ra.ALMClave, ra.Estado }
                select new { Ubicacion = u }
            ).FirstOrDefault();

            if (andenRecibo == null) //El código del anden leído no corresponde al esperado pare el recibo.
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.OK, new { andenNoCorresponde = true }));


            return Request.CreateResponse(HttpStatusCode.OK, new { Exito = true });
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
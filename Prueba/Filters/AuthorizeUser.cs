using Prueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private usuarios oUsuario;
        private AVCEntities db = new AVCEntities();
        private int idOperacion;

        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                oUsuario = (usuarios)HttpContext.Current.Session["User"];
                var lstMisOperaciones = from m in db.permisos
                          where m.permiso_id_rol == oUsuario.usuario_id_rol
                              && m.permiso_id_pantalla == idOperacion
                          select m;


                if (lstMisOperaciones.ToList().Count() ==0)
                {
                    var oOperacion = db.pantallas.Find(idOperacion);
                    int? idModulo =oOperacion.id_pantalla;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreDelModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=" + ex.Message);
            }
        }

        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.pantallas
                      where op.id_pantalla == idOperacion
                      select op.pantalla_nombre;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.roles
                         where m.id_rol == idModulo
                         select m.rol_nombre;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }

    }
}
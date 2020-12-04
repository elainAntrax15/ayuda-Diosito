using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.Service;
using System;
using System.Web.Mvc;

namespace RecetasMvc.Controllers
{
    public class RecetaController : Controller
    {
        // = Seria comparar numeros 7 = 7;
        // == Seria para cualquier cosas que no sea valor, 'Texto' == 'Texto' || VAlor == null;
        // GET: Receta
        TblRecetaCTRL Receta = new TblRecetaCTRL();

        [HttpGet]
        public ActionResult RecetasEdit(int id=0)
        {
            //Receta receta1 = new Receta();
            return View();
        }

        public ActionResult Ver()
        {
            ViewBag.RecetaList = Receta.TraerReceta();
            return View();
        }

        public ActionResult Agregar()
        {
            
            return View();
        }

        public int AgregarReceta()
        {
            TblRecetaBO Actualizacion = new TblRecetaBO();
            string receta = Request.Form.Get("RECETA");
            string tiempo = Request.Form.Get("TIEMPO");
            string ingredientes = Request.Form.Get("INGREDIENTES");
            string preparacion = Request.Form.Get("PREPARACION");
           
            Actualizacion.RECETA = receta;
            Actualizacion.TIEMPO = tiempo;
            Actualizacion.INGREDIENTES = ingredientes;
            Actualizacion.PREPARACION = preparacion;


            try
            {
                int X = 0;
                X = Receta.Agregar(Actualizacion);
                return X;
            }
            catch(Exception ex)
            {
                return 0;
            }
            //Quien sabe porque marca asi, no deberia hacerlo, ERES UN MASTER O.OAJJAJAJAJAJ TU ME ENSEÑASTE CHEES XD, qUE Considerado
        }

        public int UpdateStatus()
        {
            int estatus = 1;
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int res = Administrador.Baja(id, estatus);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
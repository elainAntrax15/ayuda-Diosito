﻿using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RecetasMvc.Controllers
{
    public class UsuariosController : Controller
    {
        TblUsuarioCTRL Total = new TblUsuarioCTRL();
        // GET: Usuarios
        public ActionResult Ver()
        {
            ViewBag.UsuarioLista = Total.Traer();
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        public int New()
        {
            TblUsuariosBO Actualizacion = new TblUsuariosBO();
            string nombre = Request.Form.Get("Nombre");
            string apellido = Request.Form.Get("Apellido");
            string genero = Request.Form.Get("Genero");
            string correo = Request.Form.Get("Correo");
            string contraseña = Request.Form.Get("Contraseña");
            string rol = Request.Form.Get("Rol");

            Actualizacion.Nombre = nombre;
            Actualizacion.Apellido = apellido;
            Actualizacion.Genero = genero;
            Actualizacion.Correo = correo;
            Actualizacion.Contraseña = contraseña;
            Actualizacion.Rol = rol;

            try
            {
                int X = 0;
                X = Total.Agregar(Actualizacion);
                return X;
            }
            catch(Exception ex)
            {
                return 0;
            }
                
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrando_Apis_con_ADO.NET.Repository;
using Integrando_Apis_con_ADO.NET.Models;
using System.Data.SqlClient;
using System.Data;

namespace Integrando_Apis_con_ADO.NET.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Usuario> GetUsuario()
        {
            return ADO_Usuario.ObtenerUsuarios();
        }

        [HttpPut]
        public void ActualizarUsuario(Usuario Usu)
        {
            ADO_Usuario.ModificarUsuario(Usu);
        }


    }
}
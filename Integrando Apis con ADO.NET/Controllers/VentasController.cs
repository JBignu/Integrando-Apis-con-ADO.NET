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
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Venta> GetVenta()
        {
            return ADO_Ventas.ObtenerVentas();
        }

        [HttpPost]
        public void ActualizarVentas(Venta Vent)
        {
            ADO_Ventas.CargarVenta(Vent);
        }



    }
}
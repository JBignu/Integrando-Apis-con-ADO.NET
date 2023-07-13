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
    public class ProductoVendidoController : Controller
    {
        // GET: ProductoVendido
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<ProductoVendido> getProductoVendido()
        {
            return ADO_ProductoVendido.ObtenerProductosVendidos();
        }

        [HttpPost]
        public void CrearProductoVendido(List<ProductoVendido> ProdVend)
        {
            ADO_ProductoVendido.CargarProductoVendido(ProdVend);
        }


    }
}
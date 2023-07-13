using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Integrando_Apis_con_ADO.NET.Models;
using Integrando_Apis_con_ADO.NET.Repository;

namespace Integrando_Apis_con_ADO.NET.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public List<Producto> GetProductos()
        {
            return ADO_Producto.ObtenerProductos();
        }


        [HttpPut]
        public void Actualizar(Producto Prod)
        {
            ADO_Producto.ModificarProducto(Prod);
        }


        [HttpPost]
        public void crear(Producto Prod)
        {
            ADO_Producto.CrearProducto(Prod);
        }


        [HttpDelete]
        public void Eliminar(long id)
        {
            ADO_Producto.EliminarProducto(id);
        }

    }
}
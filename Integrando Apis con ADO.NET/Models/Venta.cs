using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrando_Apis_con_ADO.NET.Models
{
    public class Venta
    {
        public int id { get; set; }
        public string Comentarios { get; set; }
        public int idUsuario { get; set; }

        public Venta()
        {
            id = 0;
            Comentarios = string.Empty;
            idUsuario = 0;
        }


    }
}
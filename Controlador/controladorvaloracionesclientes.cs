using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class controladorvaloracionesclientes
    {

        public controladorvaloracionesclientes() { }

        public int id_valoracion { get; set; }
        public int calificacion_valoracion { get; set; }
        public string comentario { get; set; }
        public DateTime fecha_comentario { get; set; }
        public int id_detallepedido { get; set; }
        public bool estado_comentario { get; set; }

        public bool IngresarValoracion()
        {
            return modelovaloracionesclientes.InsertarValoraciones(calificacion_valoracion, comentario, fecha_comentario, id_detallepedido, estado_comentario);
        }

        public bool ActualizarValoracion()
        {
            return modelovaloracionesclientes.ActualizarValoraciones(id_valoracion, calificacion_valoracion, comentario, fecha_comentario, id_detallepedido, estado_comentario);
        }

        public bool EliminarValoracion()
        {
            return modelovaloracionesclientes.EliminarValoraciones(id_valoracion);
        }
        public DataTable ObtenerValoraciones()
        {
            return modelovaloracionesclientes.ObtenerValoraciones();
        }

    }
}

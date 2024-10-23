using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class controladordevoluciones
    {
        public controladordevoluciones() { }

        public int id_devolucion { get; set; }
        public int id_detalle_pedido { get; set; }
        public DateTime fecha_devolucion { get; set; }
        public string motivo_devolucion { get; set; }
        public int id_estado_devolucion { get; set; }
        public int cantidad_devuelta { get; set; }

        public int IngresarDatos()
        {
            return modelodevoluciones.AgregarDevolucion(id_detalle_pedido, fecha_devolucion, motivo_devolucion, id_estado_devolucion, cantidad_devuelta);
        }

        public int ActualizarDatos()
        {
            return modelodevoluciones.ActualizarDevolucion(id_devolucion, id_detalle_pedido, fecha_devolucion, motivo_devolucion, id_estado_devolucion, cantidad_devuelta);
        }


        public int EliminarDatos()
        {
            return modelodevoluciones.EliminarDevolucion(id_devolucion);
        }

        public DataTable ObtenerDatos()
        {
            return modelodevoluciones.CargarDevoluciones();
        }

    }
}

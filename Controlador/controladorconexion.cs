using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelo;


namespace Controlador
{
    public class controladorconexion
    {

        public static SqlConnection ConectarModelo()
        {

            return modeloconexion.Conectar();
        }


    }
}

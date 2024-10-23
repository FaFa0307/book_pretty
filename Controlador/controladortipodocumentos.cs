using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Controlador
{
    public class controladortipodocumentos
    {
        public controladortipodocumentos() { }

        public static int id_tipodoc { get; set; }
        private string _tipo_documento;
        public string tipo_documento
        {
            get { return _tipo_documento; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _tipo_documento = value;
                }
                else
                {
                    MessageBox.Show("El nombre del tipo de documento debe contener solo letras.",
                    "Error con el tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public int InsertarTipoDocumento()
        {
            return modelotipodocumento.agregardatoscrudtipodocumento(tipo_documento);
        }

        public int ActualizarTipoDocumento()
        {
            return modelotipodocumento.actualizardatoscrudtipodocumento(id_tipodoc, tipo_documento);
        }

        public int EliminarTipoDocumento()
        {
            return modelotipodocumento.eliminardatoscrudtipodocumento(id_tipodoc);
        }

        public DataTable ObtenerTiposDocumentos()
        {
            return modelotipodocumento.CargarTipoDocumento();
        }

    }
}

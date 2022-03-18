using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string TipoUsuario { get; set; }

        public Usuario()
        {
        }
        //CONSTRUCTOR
        public Usuario(string codigoUsuario, string clave, string nombre, string apellido, string dni, string telefono, string tipoUsuario)
        {
            Codigo = codigoUsuario;
            Clave = clave;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            TipoUsuario = tipoUsuario;
        }
    }
}

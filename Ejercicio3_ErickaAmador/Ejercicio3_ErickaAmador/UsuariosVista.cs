using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3_ErickaAmador
{
    public partial class UsuariosVista : Form
    {
        public UsuariosVista()
        {
            InitializeComponent();
        }

        UsuariosDA_ usuariosDA_ = new UsuariosDA_();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void UsuariosVista_Load(object sender, EventArgs e)
        {
            //Llamado a los metodos
            ListarUsuarios();
        }

        //Mostrar los usuarios
        private void ListarUsuarios()
        {
           UsuariosdataGridView2.DataSource = usuariosDA_.ListarUsuarios();

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            //LLAMADO AL PROCEDIMIENTO
            Habilitar();
            operacion = "Nuevo";
        }

        //METODO PARA HABILITAR CONTROLES
        private void Habilitar()
        {
            //TextBox
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;   
            ClaveTextBox.Enabled = true;    
            DniTextBox.Enabled = true;  
            TipoUsuarioComboBox.Enabled = true; 
            ApellidoTextBox.Enabled = true; 
            TelefonoTextBox.Enabled = true;

            //Botonoes
            CancelarButton.Enabled = true;
            GuardarButton.Enabled = true;
            NuevoButton.Enabled = false;
        }

        private void DesHabilitar()
        {
            //TextBox
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            DniTextBox.Enabled = false;
            TipoUsuarioComboBox.Enabled = false;
            ApellidoTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;

            //Botonoes
            CancelarButton.Enabled = false;
            GuardarButton.Enabled = false;
            NuevoButton.Enabled = true;
        }





        private void Limpiar()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            DniTextBox.Clear();
            TipoUsuarioComboBox.Text = String.Empty;
            ApellidoTextBox.Clear();
            TelefonoTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            user.Codigo = CodigoTextBox.Text;
            user.Clave = ClaveTextBox.Text; 
            user.Nombre = NombreTextBox.Text;   
            user.Apellido = ApellidoTextBox.Text;   
            user.Dni = DniTextBox.Text;
            user.Telefono = TelefonoTextBox.Text;
            user.TipoUsuario = TipoUsuarioComboBox.Text;

            if (operacion == "Nuevo")
            {
                bool guardo = usuariosDA_.Guardar(user);

                if (guardo)
                {
                    MessageBox.Show("Usuario Creado Correctamente");
                    ListarUsuarios();
                    Limpiar();
                    DesHabilitar();
                }
                else
                {
                    MessageBox.Show("Error al crear el usuario");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = usuariosDA_.Modificar(user);

                if (modifico)
                {
                    MessageBox.Show("Usuario Modificado Correctamente");
                    ListarUsuarios();
                    Limpiar();
                    DesHabilitar();
                }
                else
                {
                    MessageBox.Show("Error al modificar el usuario");
                }
            }

          
        }

        //Modificar
        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if(UsuariosdataGridView2.SelectedRows.Count > 0)
            {

                CodigoTextBox.Text = UsuariosdataGridView2.CurrentRow.Cells["Codigo"].Value.ToString();
                ClaveTextBox.Text = UsuariosdataGridView2.CurrentRow.Cells["Clave"].Value.ToString();
                NombreTextBox.Text = UsuariosdataGridView2.CurrentRow.Cells["Nombre"].Value.ToString(); 
                ApellidoTextBox.Text = UsuariosdataGridView2.CurrentRow.Cells["Apellido"].Value.ToString();
                DniTextBox.Text = UsuariosdataGridView2.CurrentRow.Cells["Dni"].Value.ToString();
                TelefonoTextBox.Text = UsuariosdataGridView2.CurrentRow.Cells["Telefono"].Value.ToString();
                TipoUsuarioComboBox.Text = UsuariosdataGridView2.CurrentRow.Cells["TipoUsuario"].Value.ToString();

                Habilitar();
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosdataGridView2.SelectedRows.Count > 0)
            {
                bool elimino = usuariosDA_.Eliminar(UsuariosdataGridView2.CurrentRow.Cells["Codigo"].Value.ToString());

              

                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                    
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario");
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesHabilitar();
            Limpiar();
        }
    }
}

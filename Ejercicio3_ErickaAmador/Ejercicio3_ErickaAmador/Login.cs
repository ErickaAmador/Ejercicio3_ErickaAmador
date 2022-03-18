using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.Accesos;
using Datos.Entidades;
  
namespace Ejercicio3_ErickaAmador
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            UsuariosDA_ usuariosDA_ = new UsuariosDA_();
            Usuario usuario = new Usuario();

            usuario = usuariosDA_.Login(UsuarioTextBox.Text, ClaveTextBox.Text);

            if(usuario == null)
            {
                MessageBox.Show("Datos Incorrectos");
                return;
            }
            

            UsuariosVista usuariosVista = new UsuariosVista();
            usuariosVista.Show();



        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}

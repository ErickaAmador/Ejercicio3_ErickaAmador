using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos
{
    public class UsuariosDA_
    {
        //Cadena de coneccion
        readonly string cadena = "Server=localhost; Port=3306; Database=Ejercicio3; Uid=root; Pwd=ErickaAmador26@;";

        MySqlConnection conectar;
        MySqlCommand cmd;

        //Conectarnos a la base
        public Usuario Login(String codigo, string clave)
        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo AND Clave = @Clave;";

                conectar = new MySqlConnection(cadena);
                conectar.Open();

                cmd = new MySqlCommand(sql, conectar);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();
                    user.Codigo = reader[0].ToString();
                    user.Clave = reader[1].ToString();
                    user.Nombre = reader[2].ToString();
                    user.Apellido = reader[3].ToString();
                    user.Dni = reader[4].ToString();
                    user.Telefono = reader[5].ToString();
                    user.TipoUsuario = reader[6].ToString();
                }
                reader.Close();
                conectar.Close();

            }
            catch (Exception ex)
            {

            }
            return user;
        }


        //Mostrar los usuarios 
        public DataTable ListarUsuarios()
        {
            DataTable ListaUsuariosDT = new DataTable();

            try
            {
                String sql = "SELECT * FROM usuario;";

                conectar = new MySqlConnection(cadena);
                conectar.Open();

                cmd = new MySqlCommand(sql, conectar);

                MySqlDataReader reader = cmd.ExecuteReader();
                ListaUsuariosDT.Load(reader);   
                reader.Close(); 
                conectar.Close();   
            }
            catch (Exception ex)
            {   

               
            }
            return ListaUsuariosDT; //Regresar la lista
        }
       
        //GUARDAR
        public bool Guardar(Usuario usuario)
        {
            bool guardo = false;

            try
            {
                string sql = "INSERT INTO usuario VALUES (@Codigo,@Clave,@Nombre,@Apellido,@Dni,@Telefono,@TipoUsuario)"; //Insertar la tabla creada

                conectar = new MySqlConnection(cadena);
                conectar.Open();

                cmd = new MySqlCommand(sql, conectar);
                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);

                cmd.ExecuteNonQuery();  //Ejecuta datos
                guardo = true;
                
                conectar.Close();



            }
            catch (Exception)
            {

            }
            return guardo;
        }

        //Modificar
        public bool Modificar(Usuario usuario)
        {
            bool modifico = false;

            try
            {
                string sql = "UPDATE usuario SET Codigo = @Codigo, Clave = @Clave, Nombre = @Nombre, Apellido = @Apellido, Dni= @Dni, Telefono = @Telefono, TipoUsuario = @TipoUsuario WHERE Codigo = @Codigo;"; //Insertar la tabla creada

                conectar = new MySqlConnection(cadena);
                conectar.Open();

                cmd = new MySqlCommand(sql, conectar);

                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);

                cmd.ExecuteNonQuery();  //Ejecuta datos

                modifico = true;

                conectar.Close();

            }
            catch (Exception)
            {

            }
            return modifico;
        }

        //ELIMINAR      
        public bool Eliminar(string codigo)
        {
            bool elimino = false;

            try
            {
                string sql = "DELETE FROM usuario WHERE Codigo = @Codigo;"; //Insertar la tabla creada

                conectar = new MySqlConnection(cadena);
                conectar.Open();

                cmd=new MySqlCommand(sql, conectar);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cmd.ExecuteNonQuery();  //Ejecuta datos
                elimino = true;
                
                conectar.Close();

            }
            catch (Exception ex)
            {

            }
            return elimino;
        }
    }
    
}

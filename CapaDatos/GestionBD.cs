using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Controlador para pegarme a BD Microsoft SQL
using CapaDatos;
using System.Data;
using System.Configuration;
using CapaDatos;

namespace CapaDatos
{
   public class GestionBD
    {
        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionPruebas"].ConnectionString;

        public int actualizarCarro(CarroD objCarroD)
        {
            int cantidadRegistros = -1;
           
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                //Todos los recursos que se crean dentro de este bloque, serán automaticamente destruidos cuando se termine el bloque de programacion
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update carro " +
                                  "set Marca = @Marca, " +
                                  "    Modelo = @Modelo, " +
                                  "    Pais = @Pais, " +
                                  "    Costo = @Costo " +
                                  "Where IdCarro = @IdCarro ";
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarroD.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarroD.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarroD.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarroD.Costo));
                cmd.Parameters.Add(new SqlParameter("@IdCarro", objCarroD.IdCarro));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int eliminarCarro(CarroD objCarroD)
        {
            int cantidadRegistros = -1;
            
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                //Todos los recursos que se crean dentro de este bloque, serán automaticamente destruidos cuando se termine el bloque de programacion
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from carro Where IdCarro = @IdCarro";
                cmd.Parameters.Add(new SqlParameter("@IdCarro", objCarroD.IdCarro));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); //Aqui estamos realizando el Insert en base de datos.
                sqlCon.Close();
            }

            return cantidadRegistros;
        }
        public int registrarCarro(CarroD objCarroD)
        {
            int cantidadRegistros = -1;
           
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {

                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into carro (Marca,Modelo,Pais,Costo) Values (@Marca,@Modelo,@Pais,@Costo)";
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarroD.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarroD.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarroD.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarroD.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); 
                sqlCon.Close();
            }

            return cantidadRegistros;

        }
        public DataTable cargaCarrosD()
        {
            DataTable objTabla = new DataTable(); //Inicializamos la Tabla
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from carro";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla); //Cargamos la tabla con los datos que me retorna el Comando.
            return objTabla;
        }



    }

}

using RecetaSpawn.Domain.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.DAO
{
	public class TblUsuarioDAO
	{
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		//Vienes aqui, te posicionas sobre el nombre del metodo (Agregar), click derecho y crear pruebas unitarias

		public int Agregar(TblUsuariosBO Crear)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "INSERT INTO TblUsuarios(Nombre, Apellido, Correo, Contraseña, Genero, Rol)" +
						 "VALUES (@Nombre, @Apellido, @Correo, @Contraseña, @Genero, @Rol)";
			cmd.Parameters.AddWithValue("@Nombre", Crear.Nombre);
			cmd.Parameters.AddWithValue("@Apellido", Crear.Apellido);
			cmd.Parameters.AddWithValue("@Correo", Crear.Correo);
			cmd.Parameters.AddWithValue("@Contraseña", Crear.Contraseña);
			cmd.Parameters.AddWithValue("@Genero", Crear.Genero);
			cmd.Parameters.AddWithValue("@Rol", Crear.Rol);

			cmd.CommandText = sql;
			int x = cmd.ExecuteNonQuery();

			cmd.Parameters.Clear();
			if (x <= 0)
			{
				return 0;
			}
			return 1;
		}

		public bool Editar(object obj)
		{
			bool res = false;
			TblUsuariosBO Modificar = (TblUsuariosBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblUsuarios set Nombre = @Nombre, Apellido = @Apellido ,Correo = @Correo ,Contraseña = @Contraseña ,Genero = @Genero where IDUsuario = @IDUsuario";

			cmd.Parameters.AddWithValue("@Nombre", Modificar.Nombre);
			cmd.Parameters.AddWithValue("@Apellido", Modificar.Apellido);
			cmd.Parameters.AddWithValue("@Correo", Modificar.Correo);
			cmd.Parameters.AddWithValue("@Contraseña", Modificar.Contraseña);
			cmd.Parameters.AddWithValue("@Genero", Modificar.Genero);
			cmd.Parameters.AddWithValue("@IDUsuario", Modificar.IDUsuario);

			cmd.CommandText = sql;
			int Y = cmd.ExecuteNonQuery();

			cmd.Parameters.Clear();
			if (Y <= 0)
			{
				return res = false;

			}
			return res = true;
		}
		public bool Eliminar(object obj)
        {
			bool res = false;
			TblUsuariosBO Eliminar = (TblUsuariosBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "delete  TblUsuarios where IDUsuario = @IDUsuario";
			cmd.Parameters.AddWithValue("IDUsuario", Eliminar.IDUsuario);
			cmd.CommandText = sql;
			int Y = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			if (Y <= 0)
            {
				return res = false;

            }
			return res = true;
		}

		//List<TblEmpleadoBO>

		public List<TblUsuariosBO> BuscarUsuarios()
		{
			List<TblUsuariosBO> lista = new List<TblUsuariosBO>();
			sql = "SELECT * FROM TblUsuarios";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblUsuariosBO obj = new TblUsuariosBO();
					obj.IDUsuario = int.Parse(row["IDUsuario"].ToString());
					obj.Nombre = row["Nombre"].ToString();
					obj.Apellido = row["Apellido"].ToString();
					obj.Correo = row["Correo"].ToString();
					obj.Contraseña = row["Contraseña"].ToString();
					obj.Genero = row["Genero"].ToString();
					obj.Rol = row["Rol"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}


	}

}

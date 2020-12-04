using System.Data.SqlClient;

namespace RecetaSpawn.Domain.DAO
{
    public class Conexion
	{
		SqlConnection con;
		public SqlConnection establecerconexion()
		{
			string cadena = "SERVER=DESKTOP-27FSFUB\\SQLEXPRESS;Initial Catalog=ProyectoRecetas;Integrated Security=True";
			con = new SqlConnection(cadena);
			return con;
		}
		public void AbrirConexion()
		{
			con.Open();
		}
		public void CerrarConexion()
		{
			con.Close();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.DAO;

namespace RecetaSpawn.Domain.Service
{
	public class TblRecetaCTRL
    {
		TblRecetaDAO metodo = new TblRecetaDAO();
		public List<TblRecetaBO> TraerReceta()
        {
			List<TblRecetaBO> data = new List<TblRecetaBO>();
			data = metodo.ListarTablaReceta();
			return data;
        }

		public int Agregar(TblRecetaBO obj)
		{
			int final = 0;
			final = metodo.Agregar(obj);
			return final;
		}
		

	}
}

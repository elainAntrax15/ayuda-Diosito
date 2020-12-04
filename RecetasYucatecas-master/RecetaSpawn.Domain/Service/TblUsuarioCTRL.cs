using RecetaSpawn.Domain.BO;
using RecetaSpawn.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaSpawn.Domain.Service
{
    public class TblUsuarioCTRL
    {

		//int
		TblUsuarioDAO Metodo = new TblUsuarioDAO();
		
		public int Agregar(TblUsuariosBO obj)
        {
			int final=0;
			final = Metodo.Agregar(obj);
			return final;
        }


		public List<TblUsuariosBO> Traer()  
		{
			List<TblUsuariosBO> datos = new List<TblUsuariosBO>();
			datos = Metodo.BuscarUsuarios();
			return datos;
		}


		public bool editar(object obj)
        {
			bool final;
			final = Metodo.Editar(obj);
			return final;
        }
		public bool eliminar(object obj)
        {
			bool final;
			final = Metodo.Eliminar(obj);
			return final;
        }


	}
}

	
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
	public  interface IProductoRepositorio
	{
        Task<bool> Nuevo(Producto producto);
        Task<bool> Actualizar(Producto producto);
        Task<bool> Eliminar(int codigo);
        Task<IEnumerable<Producto>> GetLista();
        Task<Producto> GetPorCodigo(int codigo);
    }
}

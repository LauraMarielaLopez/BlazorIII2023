using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisProductos
{
	public partial class Productos
	{
        [Inject] private IProductoServicio productoServicio { get; set; }

         IEnumerable<Producto> listaProducto { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaProducto = await productoServicio.GetLista();
        }
    }
}

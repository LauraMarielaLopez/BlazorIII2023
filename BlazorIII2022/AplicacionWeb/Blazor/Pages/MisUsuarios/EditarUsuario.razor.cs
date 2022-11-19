using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisUsuarios
{
	public partial class EditarUsuario
	{
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }

        private Usuario user = new Usuario();

        [Parameter] public string Codigo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                user = await usuarioServicio.GetPorCodigo(Codigo);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre)
                || string.IsNullOrEmpty(user.Clave) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
            {
                return;
            }

            bool edito = await usuarioServicio.Actualizar(user);

            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Usuario actulizado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo actualizar el usuario", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Usuarios");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Usuarios");
        }
        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el usuario?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await usuarioServicio.Eliminar(Codigo);
                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Usuario eliminado con exito", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Usuarios");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el usuario", SweetAlertIcon.Error);
                }
            }


        }

    }
}

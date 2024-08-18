using Base2.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AvisosPage : ContentPage
    {
        public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();

        public AvisosPage()
        {
            InitializeComponent();
            BindingContext = this;
            CargarUsuarios();
            btnEnviarAviso.Clicked += BtnEnviarAviso_Clicked;
        }

        private async void CargarUsuarios()
        {
            var repository = new FBUserRepository();
            var usuarios = await repository.GetUsuariosByRol(2); // Obtén los usuarios con rol 2 (Padres)

            if (usuarios != null && usuarios.Any())
            {
                foreach (var usuario in usuarios)
                {
                    Usuarios.Add(usuario);
                }
            }
            else
            {
                await DisplayAlert("Aviso", "No se encontraron usuarios con el rol especificado.", "OK");
            }
        }

        private async void BtnEnviarAviso_Clicked(object sender, EventArgs e)
        {
            if (AsuntoEntry == null || MensajeEditor == null)
            {
                await DisplayAlert("Error", "Hubo un problema inicializando los controles.", "OK");
                return;
            }

            string asunto = AsuntoEntry.Text;
            string mensaje = MensajeEditor.Text;

            if (string.IsNullOrEmpty(asunto) || string.IsNullOrEmpty(mensaje))
            {
                await DisplayAlert("Error", "Debe ingresar un asunto y un mensaje.", "OK");
                return;
            }

            var seleccionados = Usuarios.Where(u => u.IsSelected).Select(u => u.IdUser).ToList();
            if (!seleccionados.Any())
            {
                await DisplayAlert("Error", "Debe seleccionar al menos un usuario.", "OK");
                return;
            }

            var aviso = new Aviso
            {
                TipoAviso = asunto,
                FechaEnvio = DateTime.Now,
                Mensaje = mensaje,
                IdUsers = seleccionados,  // Lista de IDs de usuarios seleccionados
                IdEstudiante = null // Ajusta si es necesario
            };

            var repository = new FBUserRepository();
            bool isSaved = await repository.SaveAviso(aviso);

            if (isSaved)
            {
                await DisplayAlert("Éxito", "Aviso enviado correctamente.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Hubo un problema al enviar el aviso.", "OK");
            }
        }


    }
}

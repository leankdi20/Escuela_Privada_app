using Base2.models;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesPage : ContentPage
    {
        public ObservableCollection<Aviso> Avisos { get; set; }

        public NotificacionesPage()
        {
            InitializeComponent();
            
            var userId = SessionData.IdUser;

            
            BindingContext = this;

            CargarAvisos(userId);
        }

        private async void CargarAvisos(string userId)
        {
            try
            {
                var fbRepository = new FBUserRepository();
                var avisos = await fbRepository.GetAvisosByUserId(userId);

                if (avisos != null && avisos.Any())
                {
                    Avisos = new ObservableCollection<Aviso>(avisos);
                    NotificacionesListView.ItemsSource = Avisos;
                }
                else
                {
                    await DisplayAlert("Aviso", "No se encontraron avisos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error cargando avisos: {ex.Message}", "OK");
            }
        }

        private async void OnNotificationTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Aviso aviso)
            {
                // Formatear la fecha de envío para mostrarla en la alerta
                string fechaFormateada = aviso.FechaEnvio.ToString("dd/MM/yyyy HH:mm");

                // Combinar el mensaje con la fecha para mostrar en la alerta
                string mensajeCompleto = $"{aviso.Mensaje}\n\nFecha de Envío: {fechaFormateada}";

                // Mostrar una alerta con el mensaje completo y la fecha del aviso
                await DisplayAlert(aviso.TipoAviso, mensajeCompleto, "OK");

                // Desmarcar la selección
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
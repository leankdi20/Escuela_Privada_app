using Base2.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificacionesPage : ContentPage
    {
        public ObservableCollection<Notificacion> Notificaciones { get; set; }

        public NotificacionesPage()
        {
            InitializeComponent();

            // Inicializar la lista de notificaciones
            Notificaciones = new ObservableCollection<Notificacion>
            {
                new Notificacion
                {
                    Titulo = "Aviso Importante",
                    Mensaje = "Reunión de padres el lunes.",
                    Fecha = DateTime.Now,
                    Leida = false
                },
                new Notificacion
                {
                    Titulo = "Examen programado",
                    Mensaje = "Examen de matemáticas el miércoles.",
                    Fecha = DateTime.Now.AddDays(-1),
                    Leida = false
                },
                new Notificacion
                {
                    Titulo = "Salida Escolar",
                    Mensaje = "Salida escolar programada para el viernes.",
                    Fecha = DateTime.Now.AddDays(-2),
                    Leida = false
                }
            };
            // Verificar las fechas en la consola de depuración
            foreach (var notificacion in Notificaciones)
            {
                Debug.WriteLine($"Notificación: {notificacion.Titulo}, Fecha: {notificacion.Fecha}");
            }

            // Establecer el BindingContext a esta página
            BindingContext = this;

            // Configurar el evento de tap en el ListView
            NotificacionesListView.ItemTapped += OnNotificationTapped;
        }

        private async void OnNotificationTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Notificacion notificacion)
            {
                // Muestra una alerta con el mensaje completo de la notificación.
                await DisplayAlert(notificacion.Titulo, notificacion.Mensaje, "OK");

                // Marca la notificación como leída, si es necesario
                notificacion.Leida = true;

                // Actualizar la lista para reflejar cambios
                NotificacionesListView.ItemsSource = null;
                NotificacionesListView.ItemsSource = Notificaciones;

                // Desmarca la selección
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
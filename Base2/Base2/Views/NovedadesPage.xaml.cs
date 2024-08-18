using Base2.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovedadesPage : ContentPage
	{
        public ObservableCollection<Notificacion> NovedadesList { get; set; }

        private FBUserRepository _repository;
        public NovedadesPage ()
		{
			InitializeComponent ();
            _repository = new FBUserRepository();  // Instanciar el repositorio de Firebase
            NovedadesList = new ObservableCollection<Notificacion>();
            BindingContext = this;
            LoadNovedades();  // Cargar las notificaciones desde Firebase

            // Crear lista de novedades de ejemplo
            //NovedadesList = new List<Novedad>
            //{
            //    new Novedad { Titulo = "Matrícula Abierta", Descripcion = "La matrícula para el próximo curso ya está abierta. ¡Inscríbete ahora!", Fecha = DateTime.Now.AddDays(-2) },
            //    new Novedad { Titulo = "Nuevo Curso de Inglés", Descripcion = "Anunciamos un nuevo curso intensivo de inglés para todos los niveles.", Fecha = DateTime.Now.AddDays(-5) },
            //    new Novedad { Titulo = "Día de la Familia", Descripcion = "El próximo sábado celebraremos el Día de la Familia en el colegio. ¡No te lo pierdas!", Fecha = DateTime.Now.AddDays(-10) },
            //    new Novedad { Titulo = "Concierto Escolar", Descripcion = "El próximo viernes tendrá lugar nuestro concierto anual en el auditorio principal.", Fecha = DateTime.Now.AddDays(-15) }
            //};

            
        }

        private async void LoadNovedades()
        {
            try
            {
                // Obtener todas las notificaciones
                var notificaciones = await _repository.GetAllNotificaciones();

                // Limpiar la lista actual
                NovedadesList.Clear();

                // Agregar cada notificación a la lista observable
                foreach (var notificacion in notificaciones)
                {
                    NovedadesList.Add(notificacion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las novedades: {ex.Message}");
                await DisplayAlert("Error", "No se pudieron cargar las novedades", "OK");
            }
        }
    }
}
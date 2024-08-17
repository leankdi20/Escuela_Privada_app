using Base2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvisosPadre : ContentPage
    {

        private string userId;
        private FBUserRepository userRepo;

        public AvisosPadre(string currentUserId)
        {
            InitializeComponent();
            userId = currentUserId;
            userRepo = new FBUserRepository();
            LoadAvisosAsync();
        }

        private async void LoadAvisosAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    await DisplayAlert("Error", "User ID is not set.", "OK");
                    return;
                }

                var avisos = await userRepo.GetAvisosByUserId(userId);
                AvisosStackLayout.Children.Clear();

                if (avisos != null && avisos.Count > 0)
                {
                    foreach (var aviso in avisos)
                    {
                        var estudiante = await userRepo.GetEstudianteById(aviso.IdEstudiante);
                        var studentName = estudiante != null ? $"{estudiante.FirstName} {estudiante.LastName}" : "Estudiante"; //fijarse en esto despues

                        AvisosStackLayout.Children.Add(new Label
                        {
                            Text = $"Estudiante: {studentName}\nTipo de aviso: {aviso.TipoAviso}\nMensaje: {aviso.Mensaje}\nFecha de Envio: {aviso.FechaEnvio} \n-----------------------------------------------",
                            TextColor = Color.White,
                            FontSize = 20,
                            Margin = new Thickness(0, 5, 0, 5)
                        });
                    }
                }
                else
                {
                    AvisosStackLayout.Children.Add(new Label
                    {
                        Text = "No hay avisos disponibles.",
                        TextColor = Color.White,
                        FontSize = 16,
                        Margin = new Thickness(0, 5, 0, 5)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading avisos: {ex.Message}");
                await DisplayAlert("Error", "Ocurrió un error al cargar los avisos.", "Aceptar");
            }
        }


    }
}

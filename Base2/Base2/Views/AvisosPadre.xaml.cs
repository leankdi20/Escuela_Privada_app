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
        public AvisosPadre()
        {
            InitializeComponent();
        }


        private string userId; // Set this according to your logic to retrieve the current user's ID
        private FBUserRepository userRepo; // Assuming this is already initialized

        public AvisosPadre(string currentUserId)
        {
            InitializeComponent();
            userId = currentUserId; // Assign the userId from the constructor parameter
            userRepo = new FBUserRepository(); // Initialize your repository
            LoadAvisosAsync(); // Load the avisos for the current user
        }

        private async void LoadAvisosAsync()
        {
            try
            {
                var avisos = await userRepo.GetAvisosByUserId(userId);
                AvisosStackLayout.Children.Clear();

                if (avisos != null && avisos.Count > 0)
                {
                    foreach (var aviso in avisos)
                    {
                        AvisosStackLayout.Children.Add(new Label
                        {
                            Text = $"{aviso.TipoAviso}: {aviso.Mensaje}",
                            TextColor = Color.White,
                            FontSize = 16,
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

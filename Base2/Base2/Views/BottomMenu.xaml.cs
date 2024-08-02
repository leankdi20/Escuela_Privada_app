using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BottomMenu : ContentView
	{

        public Usuario usuario { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public BottomMenu ()
		{
			InitializeComponent ();

            btnHome.Clicked += BtnHome_Clicked;
            btnEstudiante.Clicked += BtnEstudiante_Clicked;
            btnNovedades.Clicked += BtnNovedades_Clicked;
            btnPerfil.Clicked += BtnPerfil_Clicked;
        }



        private async void BtnPerfil_Clicked(object sender, EventArgs e)
        {

            ShowMessage("Perfil del usuario");
            await Task.Delay(2000);
            HideMessage();
            await Navigation.PushAsync(new Perfil());
        }

        private async void BtnNovedades_Clicked(object sender, EventArgs e)
        {
            ShowMessage("Novedades de la escuela");
            await Task.Delay(2000);
            HideMessage();
        }

        private async void BtnEstudiante_Clicked(object sender, EventArgs e)
        {
            ShowMessage("Información del estudiante");
            await Task.Delay(2000);
            HideMessage();
        }

        private async void BtnHome_Clicked(object sender, EventArgs e)
        {
            ShowMessage("Página principal");
            await Task.Delay(2000);
            HideMessage();
            await Navigation.PushAsync(new MenuPrincipal());
        }

        private void ShowMessage(string message)
        {
            messageLabel.Text = message;
            messageLabel.IsVisible = true;
        }

        private void HideMessage()
        {
            messageLabel.IsVisible = false;
        }
    }
}
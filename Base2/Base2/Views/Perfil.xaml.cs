using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Perfil : ContentPage
	{
		public Perfil (string firstName, string email)
		{
			InitializeComponent ();
			lblName.Text = firstName;
			lblEmail.Text = email;
            btnInfoPersonal.Clicked += BtnInfoPersonal_Clicked;
            btnNotificaciones.Clicked += BtnNotificaciones_Clicked;
		}

        private async void BtnNotificaciones_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Notificaciones", "Notificaciones de la escuela", "OK");
        }

        private async void BtnInfoPersonal_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info Personal", "Notificaciones de la escuela", "OK");
        }
    }
}
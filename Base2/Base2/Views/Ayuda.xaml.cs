using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ayuda : ContentPage
	{
		public Ayuda ()
		{
			InitializeComponent ();
		}

        private async void OnLabelTapped(object sender, EventArgs e)
        {
            var url = "https://www.youtube.com/watch?v=TXK7v49QwcI";
            await Launcher.OpenAsync(url);
        }
    }
}
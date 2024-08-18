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
	public partial class ButtomMenuProfe : ContentView
	{
		public ButtomMenuProfe ()
		{
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Menú Inferior", HorizontalOptions = LayoutOptions.Center },
                    new Button { Text = "Opción 1" },
                    new Button { Text = "Opción 2" }
                }
            };
        }
	}
}
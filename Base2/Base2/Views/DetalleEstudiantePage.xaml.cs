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
	public partial class DetalleEstudiantePage : ContentPage
	{
		public DetalleEstudiantePage (Estudiante estudiante)
		{
			InitializeComponent ();
            BindingContext = estudiante; // Establece el contexto de enlace con el estudiante pasado
        }
	}
}
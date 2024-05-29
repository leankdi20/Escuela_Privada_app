using Escuela_privada.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Escuela_privada.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
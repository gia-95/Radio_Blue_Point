using Radio_Blue_Point.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Radio_Blue_Point.Views
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
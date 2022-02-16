using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

using Radio_Blue_Point.ViewModels;

namespace Radio_Blue_Point.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StreamingPage : ContentPage
    {

        private StreamingPageViewModel ViewModel { get { return (StreamingPageViewModel)this.BindingContext; } }
        public StreamingPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

          
        }

        private void Play_tapped(object sender, EventArgs e)
        {
            ViewModel.Play();
        }

        private void Stop_tapped(object sender, EventArgs e)
        {
            ViewModel.Stop();
        }
    }
}
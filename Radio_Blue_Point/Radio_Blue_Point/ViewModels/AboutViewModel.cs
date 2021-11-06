using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Radio_Blue_Point.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Radio Streaming";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://nrf1.newradio.it:10090/stream"));
            nuovoComando = new Command(async () => await Browser.OpenAsync("https://radio-blue-point.jimdosite.com/"));
        }

        public ICommand OpenWebCommand { get; }

        public ICommand nuovoComando { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Radio_Blue_Point.Views
{
    public interface IStreaming
    {
        void Play();
        void Pause();
        void Stop();
    }
}

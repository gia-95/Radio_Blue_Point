using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Radio_Blue_Point.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Android.Media;
using Xamarin.Forms;
using Radio_Blue_Point.Droid;



[assembly: Xamarin.Forms.Dependency(typeof(StreamingService))]




namespace Radio_Blue_Point.Droid
{
    class StreamingService : IStreaming
    {
        MediaPlayer player;
        string dataSource = "http://nrf1.newradio.it:10090/stream";



        bool isPrepared = false;



        public void Play()
        {
            if (!isPrepared)
            {
                if (player == null)
                    player = new MediaPlayer();
                else
                    player.Reset();



                player.SetDataSource(dataSource);
                player.PrepareAsync();
            }



            player.Prepared += (sender, args) =>
            {
                player.Start();
                isPrepared = true;
            };
        }



        public void Pause()
        {
            player.Pause();
        }



        public void Stop()
        {
            player.Stop();
            isPrepared = false;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Radio_Blue_Point.ViewModels
{
    class SearchingPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<SongPage> Song;

        public ObservableCollection<SongPage> song
        {
            get { return Song; }

            set { Song = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("song"));
            }
        }

        public SearchingPageViewModel ()
        {
            song = new ObservableCollection<SongPage>();
            addSong();
        }

        public void addSong ()
        {
            song.Add(new SongPage
            {
                id = 0,
                titolo = "AAAA",
                album = "BBBBB",
                imageSong = "https://images.pexels.com/photos/534283/pexels-photo-534283.jpeg"
            });

            song.Add(new SongPage
            {
                id = 0,
                titolo = "CCCCC",
                album = "DDDDDD",
                imageSong = "https://images.pexels.com/photos/534283/pexels-photo-534283.jpeg"
            });

        }

    }
}

using Newtonsoft.Json.Linq;
using Radio_Blue_Point.Models;
using Radio_Blue_Point.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radio_Blue_Point.ViewModels
{
    class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public SearchViewModel()
        {
            canzoni = new ObservableCollection<Song>();
            EseguiQueryCommand = new Command(RunQuery);
            TextCommand = new Command(ApriTesto);
            SaveSongCommand = new Command(SaveSong);
            Routing.RegisterRoute("TextPage", typeof(TextPage));
        }



        private ObservableCollection<Song> canzoni;
        public ObservableCollection<Song> Canzoni
        {
            get { return canzoni; }

            set
            {
                canzoni = value;
                OnPropertyChanged(nameof(Canzoni));
            }
        }

        string artistEntry = string.Empty;
        public String ArtistEntry
        {
            get { return artistEntry; }
            set
            {
                artistEntry = value;
                OnPropertyChanged(nameof(ArtistEntry));
            }
        }

        string testoCanzone = string.Empty;
        public String TestoCanzone
        {
            get { return testoCanzone; }
            set { testoCanzone = value;
                OnPropertyChanged(nameof(TestoCanzone));
            }
        }


        public Command EseguiQueryCommand { get; }
        public Command TextCommand { get; }
        public Command SaveSongCommand { get; }



        async void RunQuery()
        {
            Canzoni.Clear();

            string q = "https://api.musixmatch.com/ws/1.1/track.search?q_artist={0}&page_size=20&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";

            string query = string.Format(q, artistEntry);

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(query);

            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK

            string responseBody = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(responseBody);

            var track_list = data["message"]["body"]["track_list"];

            foreach (var item in track_list)
            {
                addSong((string)item["track"]["track_name"],
                        (string)item["track"]["album_name"],
                        (string)item["track"]["artist_name"],
                        (int)item["track"]["track_id"],
                        (int)item["track"]["has_lyrics"]);
            }

            System.Diagnostics.Debug.Print(" > {0} ", query);

            System.Diagnostics.Debug.Print(" > {0} ", (string) track_list[0]["track"]["track_name"]);

        }

        async void SaveSong (object obj)
        {
            var content = obj as Song;
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = content.Titolo,
                Description = content.Artista 
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);

        }

        async void ApriTesto(object obj)
        {
            var content = obj as Song;
            if (content.Has_Lyrics == 1)
            {
                string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";

                string query = String.Format(q, content.Id);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(query);
                response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(responseBody);

                string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

                TestoCanzone = testo;

                System.Diagnostics.Debug.Print(" > {0} ", TestoCanzone);

                await Shell.Current.GoToAsync(nameof(TextPage));

            }

        }

        public void addSong(string titolo, string album,string artista, int id, int hl)
        {
            Canzoni.Add(new Song
            {
                Id = id,
                Titolo = titolo,
                Artista = artista,
                Album = album,
                Has_Lyrics = hl,
                Image = ""
            });
        }


    }
}

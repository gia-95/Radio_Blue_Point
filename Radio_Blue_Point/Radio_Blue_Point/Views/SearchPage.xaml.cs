using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Radio_Blue_Point.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = this;
            SearchButton.IsEnabled = false;
            BottoneTesto1.IsEnabled = false;
            BottoneTesto2.IsEnabled = false;
            BottoneTesto3.IsEnabled = false;
        }

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton.IsEnabled = SearchEntry.Text.Length >= 1;
        }

        int track_id1;
        string track_name1;
        int has_lyrics1;

        int track_id2;
        string track_name2;
        int has_lyrics2;

        int track_id3;
        string track_name3;
        int has_lyrics3;
        async void SearchButton_ClickedAsync(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.search?q_artist={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";

            string query = String.Format(q, SearchEntry.Text);

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(query);

            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK

            string responseBody = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(responseBody);

            var track_list = data["message"]["body"]["track_list"];

            FirstTrack.Text = (string)track_list[0]["track"]["track_name"];
            FirstAlbum.Text = (string)track_list[0]["track"]["album_name"];
            track_id1 = (int)track_list[0]["track"]["track_id"];
            track_name1 = (string)track_list[1]["track"]["track_name"];
            has_lyrics1 = (int)track_list[0]["track"]["has_lyrics"];

            SecondTrack.Text = (string)track_list[1]["track"]["track_name"];
            SecondAlbum.Text = (string)track_list[1]["track"]["album_name"];
            track_id2 = (int)track_list[1]["track"]["track_id"];
            track_name2 = (string)track_list[1]["track"]["track_name"];
            has_lyrics2 = (int)track_list[1]["track"]["has_lyrics"];

            ThirdTrack.Text = (string)track_list[2]["track"]["track_name"];
            ThirdAlbum.Text = (string)track_list[2]["track"]["album_name"];
            track_name3 = (string)track_list[1]["track"]["track_name"];
            track_id3 = (int)track_list[2]["track"]["track_id"];
            has_lyrics3 = (int)track_list[2]["track"]["has_lyrics"];


            System.Diagnostics.Debug.Print(" > {0} ", has_lyrics1);
            System.Diagnostics.Debug.Print(" > {0} ", track_id1);
            System.Diagnostics.Debug.Print(" > {0} ", track_name1);

            System.Diagnostics.Debug.Print(" > {0} ", has_lyrics2);
            System.Diagnostics.Debug.Print(" > {0} ", track_id2);

            if (has_lyrics1 == 1) BottoneTesto1.IsEnabled = true;
            if (has_lyrics2 == 1) BottoneTesto2.IsEnabled = true;
            if (has_lyrics3 == 1) BottoneTesto3.IsEnabled = true;

            //System.Diagnostics.Debug.Print(" > {0} ", track_album_name0);
        }

        private async void BottoneTesto1_ClickedAsync(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id1);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(track_name1, testo, "OK");
        }

        private async void BottoneTesto2_ClickedAsync(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id2);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(track_name2, testo, "OK");
        }

        private async void BottoneTesto3_ClickedAsync(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id3);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(track_name3, testo, "OK");

        }

    }
}
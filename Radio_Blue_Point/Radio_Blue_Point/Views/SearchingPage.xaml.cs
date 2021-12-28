using Newtonsoft.Json.Linq;
using Radio_Blue_Point.Models;
using Radio_Blue_Point.ViewModels;
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
    public partial class SearchingPage : ContentPage
    {
        public SearchingPage()
        {
            InitializeComponent();
            BindingContext = this;
            SongStack.IsVisible = false;
            SearchButton.IsEnabled = false;
            BottoneTesto2.IsVisible = false;
            BottoneTesto3.IsVisible = false;
            BottoneTesto4.IsVisible = false;
            BottoneTesto5.IsVisible = false;
            BottoneTesto6.IsVisible = false;
            BottoneTesto7.IsVisible = false;
            BottoneTesto8.IsVisible = false;
            BottoneTesto9.IsVisible = false;
            BottoneTesto10.IsVisible = false;


        }

        public string titolo1;
        public string album1;
        public int track_id1;
        int has_lyrics1;
        public string titolo2;
        public string album2;
        public int track_id2;
        int has_lyrics2;
        public string titolo3;
        public string album3;
        public int track_id3;
        int has_lyrics3;
        public string titolo4;
        public string album4;
        public int track_id4;
        int has_lyrics4;
        public string titolo5;
        public string album5;
        public int track_id5;
        int has_lyrics5;
        public string titolo6;
        public string album6;
        public int track_id6;
        int has_lyrics6;
        public string titolo7;
        public string album7;
        public int track_id7;
        int has_lyrics7;
        public string titolo8;
        public string album8;
        public int track_id8;
        int has_lyrics8;
        public string titolo9;
        public string album9;
        public int track_id9;
        int has_lyrics9;
        public string titolo10;
        public string album10;
        public int track_id10;
        int has_lyrics10;

        async void Button_Clicked(object sender, EventArgs e)
        {

            string q = "https://api.musixmatch.com/ws/1.1/track.search?q_artist={0}&page_size=10&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";

            string query = string.Format(q, EntryArtista.Text);

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(query);

            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK

            string responseBody = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(responseBody);

            var track_list = data["message"]["body"]["track_list"];

            System.Diagnostics.Debug.Print(" > {0} ", titolo1);

            System.Diagnostics.Debug.Print(" > {0} ", response.EnsureSuccessStatusCode().ToString());

            SongStack.IsVisible = true;

            titolo1 = (string)track_list[0]["track"]["track_name"];
            labelT1.Text = titolo1;
            album1 = (string)track_list[0]["track"]["album_name"];
            labelA1.Text = album1;
            has_lyrics1 = (int)track_list[0]["track"]["has_lyrics"];
            track_id1 = (int)track_list[0]["track"]["track_id"];


            titolo2 = (string)track_list[1]["track"]["track_name"];
            labelT2.Text = titolo2;
            album2 = (string)track_list[1]["track"]["album_name"];
            labelA2.Text = album2;
            has_lyrics2 = (int)track_list[1]["track"]["has_lyrics"];
            track_id2 = (int)track_list[1]["track"]["track_id"];

            titolo3 = (string)track_list[2]["track"]["track_name"];
            labelT3.Text = titolo3;
            album3 = (string)track_list[2]["track"]["album_name"];
            labelA3.Text = album3;
            has_lyrics3 = (int)track_list[2]["track"]["has_lyrics"];
            track_id3 = (int)track_list[2]["track"]["track_id"];

            titolo4 = (string)track_list[3]["track"]["track_name"];
            labelT4.Text = titolo4;
            album4 = (string)track_list[3]["track"]["album_name"];
            labelA4.Text = album4;
            has_lyrics4 = (int)track_list[3]["track"]["has_lyrics"];
            track_id4 = (int)track_list[3]["track"]["track_id"];

            titolo5 = (string)track_list[4]["track"]["track_name"];
            labelT5.Text = titolo5;
            album5 = (string)track_list[4]["track"]["album_name"];
            labelA5.Text = album5;
            has_lyrics5 = (int)track_list[4]["track"]["has_lyrics"];
            track_id5 = (int)track_list[4]["track"]["track_id"];

            titolo6 = (string)track_list[5]["track"]["track_name"];
            labelT6.Text = titolo6;
            album6 = (string)track_list[5]["track"]["album_name"];
            labelA6.Text = album6;
            has_lyrics6 = (int)track_list[5]["track"]["has_lyrics"];
            track_id6 = (int)track_list[5]["track"]["track_id"];

            titolo7 = (string)track_list[6]["track"]["track_name"];
            labelT7.Text = titolo7;
            album7 = (string)track_list[6]["track"]["album_name"];
            labelA7.Text = album7;
            has_lyrics7 = (int)track_list[6]["track"]["has_lyrics"];
            track_id7 = (int)track_list[6]["track"]["track_id"];

            titolo8 = (string)track_list[7]["track"]["track_name"];
            labelT8.Text = titolo8;
            album8 = (string)track_list[7]["track"]["album_name"];
            labelA8.Text = album8;
            has_lyrics8 = (int)track_list[7]["track"]["has_lyrics"];
            track_id8 = (int)track_list[7]["track"]["track_id"];

            titolo9 = (string)track_list[8]["track"]["track_name"];
            labelT9.Text = titolo9;
            album9 = (string)track_list[8]["track"]["album_name"];
            labelA9.Text = album9;
            has_lyrics9 = (int)track_list[8]["track"]["has_lyrics"];
            track_id9 = (int)track_list[8]["track"]["track_id"];

            titolo10 = (string)track_list[9]["track"]["track_name"];
            labelT10.Text = titolo10;
            album10 = (string)track_list[9]["track"]["album_name"];
            labelA10.Text = album10;
            has_lyrics10 = (int)track_list[9]["track"]["has_lyrics"];
            track_id10 = (int)track_list[9]["track"]["track_id"];


            if (has_lyrics1 == 1) BottoneTesto1.IsVisible = true;
            if (has_lyrics2 == 1) BottoneTesto2.IsVisible = true;
            if (has_lyrics3 == 1) BottoneTesto3.IsVisible = true;
            if (has_lyrics4 == 1) BottoneTesto4.IsVisible = true;
            if (has_lyrics5 == 1) BottoneTesto5.IsVisible = true;
            if (has_lyrics6 == 1) BottoneTesto6.IsVisible = true;
            if (has_lyrics7 == 1) BottoneTesto7.IsVisible = true;
            if (has_lyrics8 == 1) BottoneTesto8.IsVisible = true;
            if (has_lyrics9 == 1) BottoneTesto9.IsVisible = true;
            if (has_lyrics10 == 1) BottoneTesto10.IsVisible = true;

        }

        private void EntryArtista_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton.IsEnabled = EntryArtista.Text.Length >= 1;
        }

        /* Bottoni visualizzazione TESTO */
        private async void BottoneTesto1_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id1);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo1, testo, "OK");

        }
        private async void BottoneTesto2_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id2);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo2, testo, "OK");

        }
        private async void BottoneTesto3_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id3);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo3, testo, "OK");
        }
        private async void BottoneTesto4_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id4);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo4, testo, "OK");
        }
        private async void BottoneTesto5_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id5);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo5, testo, "OK");
        }
        private async void BottoneTesto6_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id6);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo6, testo, "OK");
        }
        private async void BottoneTesto7_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id7);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo7, testo, "OK");
        }
        private async void BottoneTesto8_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id8);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo8, testo, "OK");
        }
        private async void BottoneTesto9_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id9);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo9, testo, "OK");
        }
        private async void BottoneTesto10_Clicked(object sender, EventArgs e)
        {
            string q = "https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={0}&page_size=3&page=1&s_track_rating=desc&apikey=aea40b403142b19db04d7dbe3a92ed6a";
            string query = String.Format(q, track_id10);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode(); // Verifica che risposta corretta -> status 200 OK
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(responseBody);

            string testo = (string)data["message"]["body"]["lyrics"]["lyrics_body"];

            await DisplayAlert(titolo10, testo, "OK");
        }


        /* Bottoni SALVA NELLA PLAYLIST */
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo1,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_2(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_3(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_4(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_5(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_6(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_7(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_8(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_9(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
        private async void Button_Clicked_10(object sender, EventArgs e)
        {

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = titolo2,
                Description = EntryArtista.Text
            };

            BaseViewModel modello = new BaseViewModel();

            await modello.DataStore.AddItemAsync(newItem);
        }
    }
}
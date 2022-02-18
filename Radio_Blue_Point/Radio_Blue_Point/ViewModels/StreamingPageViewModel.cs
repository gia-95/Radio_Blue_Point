using Radio_Blue_Point.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Radio_Blue_Point.ViewModels
{
    public class StreamingPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool DisplayPlay { get => !isPlaying; }
        public bool DisplayStop { get => isPlaying; }


        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<ProgramPage> Program;

        public ObservableCollection<ProgramPage> program
        {
            get { return Program; }
            set { Program = value;

                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("program"));
            }
        }

        public void Play()
        {
            DependencyService.Get<IStreaming>().Play();
            IsPlaying = true;
        }      

        public void Stop()
        {
            DependencyService.Get<IStreaming>().Stop();
            IsPlaying = false;
        }

        bool isPlaying;
        bool IsPlaying
        {
            get => isPlaying;
            set
            {
                isPlaying = value;
                // Notify the property has changed
                OnPropertyChanged("DisplayPlay");
                OnPropertyChanged("DisplayStop");
            }
        }

        public Command PlayCommand { get; }
        public Command SiteCommand { get; }

        public Command FaceBookCommand { get; }

        public StreamingPageViewModel()
        {
            program = new ObservableCollection<ProgramPage>();
            PlayCommand = new Command(async () => await Browser.OpenAsync("http://nrf1.newradio.it:10090/stream"));
            SiteCommand = new Command(async () => await Browser.OpenAsync("https://radio-blue-point.jimdosite.com/"));
            FaceBookCommand = new Command(async () => await Browser.OpenAsync("https://www.facebook.com/radiobluepoint.civitavecchia"));
            addProgram();
        }

        public void addProgram()
        {
            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Ti ricordi Syd",
                nomeProgramma = "Bruno Martini",
                imgProgram = "bm.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Salute e Benessere e Atlantide",
                nomeProgramma = "Lety La Noxe",
                imgProgram = "ll.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Dietro la musica",
                nomeProgramma = "Angelo Lucigniani",
                imgProgram = "al.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Casino in blu",
                nomeProgramma = "Riccardo Battaglini",
                imgProgram = "rb.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Parole e Musica",
                nomeProgramma = "Ugo Scialdone",
                imgProgram = "ug.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Musica dalla A alla Z",
                nomeProgramma = "Luca Scialdone",
                imgProgram = "ls.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Responsabile Tecnico",
                nomeProgramma = "Alessandro Conti",
                imgProgram = "ac.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Appuntamento con l'Astronomia",
                nomeProgramma = "Carlo Rossi",
                imgProgram = "cr.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "Redazione Giornalistica",
                nomeProgramma = "Francesco Vitale",
                imgProgram = "fv.jpg"
            });
        }

    }
}

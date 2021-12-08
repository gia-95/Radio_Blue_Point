using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Radio_Blue_Point.ViewModels
{
    public class StreamingPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<ProgramPage> Program;

        public ObservableCollection<ProgramPage> program
        {
            get { return Program; }
            set { Program = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("program"));
            }
        }

        public Command PlayCommand { get; }
        public Command SiteCommand { get; }

        public StreamingPageViewModel()
        {
            program = new ObservableCollection<ProgramPage>();
            PlayCommand = new Command(async () => await Browser.OpenAsync("http://nrf1.newradio.it:10090/stream"));
            SiteCommand = new Command(async () => await Browser.OpenAsync("https://radio-blue-point.jimdosite.com/"));
            addProgram();
        }

        public void addProgram()
        {
            program.Add(new ProgramPage
            {
                id = 0,
                orario = "12.00",
                nomeProgramma = "I Soliti Idioti",
                imgProgram = "https://images.pexels.com/photos/6966/abstract-music-rock-bw.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "14.00",
                nomeProgramma = "L'Eredità",
                imgProgram = "https://images.pexels.com/photos/1047442/pexels-photo-1047442.jpeg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "16.00",
                nomeProgramma = "Bella Ciao",
                imgProgram = "https://images.pexels.com/photos/675960/mic-music-sound-singer-675960.jpeg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "18.00",
                nomeProgramma = "PinguPingu",
                imgProgram = "https://images.pexels.com/photos/761963/pexels-photo-761963.jpeg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "20.00",
                nomeProgramma = "Aieiaieie",
                imgProgram = "https://images.pexels.com/photos/191240/pexels-photo-191240.jpeg"
            });

        }

    }
}

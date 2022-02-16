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
                orario = "12.00",
                nomeProgramma = "Marcantonio",
                imgProgram = "Avicii.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "14.00",
                nomeProgramma = "Aldo e Giovanni",
                imgProgram = "Aldo.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "16.00",
                nomeProgramma = "Franchino 126",
                imgProgram = "Linus.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "18.00",
                nomeProgramma = "Pippo e Pluto",
                imgProgram = "Avicii.jpg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "20.00",
                nomeProgramma = "Paperino",
                imgProgram = "Aldo.jpg"
            });

        }

    }
}

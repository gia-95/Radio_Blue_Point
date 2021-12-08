using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

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


        public StreamingPageViewModel()
        {

            program = new ObservableCollection<ProgramPage>();
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
                imgProgram = "https://images.pexels.com/photos/1105666/pexels-photo-1105666.jpeg"
            });

            program.Add(new ProgramPage
            {
                id = 0,
                orario = "16.00",
                nomeProgramma = "Bella Ciao",
                imgProgram = "https://images.pexels.com/photos/675960/mic-music-sound-singer-675960.jpeg"
            });

        }

    }
}

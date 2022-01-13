using Radio_Blue_Point.Data;
using Radio_Blue_Point.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Radio_Blue_Point.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prova2 : ContentPage
    {
        public Prova2()
        {
            InitializeComponent();
        }

		

		private void Salva_Clicked(object sender, EventArgs e)
        {
            RecipeModel entry1 = new RecipeModel();
            entry1.Mail = "fwdkjnjhv";
            entry1.Nome = Nome.Text;
            entry1.Cognome = Cognome.Text;
            entry1.Password = "ffdvv";
            entry1.Id = 0;
            System.Diagnostics.Debug.Print(" >{0}", Nome.Text);
            App.Database.SaveRecipe(entry1);
            this.Navigation.PopAsync();
        }

        private void Stampa_Clicked(object sender, EventArgs e)
        {
            RecipeModel appoggio = new RecipeModel();
            appoggio = App.Database.GetRecipe("francesco");
            Stampa1.Text = appoggio.Nome;
            Stampa2.Text = appoggio.Cognome;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace magicnumber.views
{
    public partial class GamePage : ContentPage
    {
        const int NB_MIN = 1;
        const int NB_MAX = 10;
        int magicNumber = 0;

        public GamePage()
        {
            InitializeComponent();
            magicNumber = new Random().Next(NB_MIN, NB_MAX);
            minMaxLabel.Text = "Entre " + NB_MIN + " et " + NB_MAX;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public GamePage(Entry entryNumber)
        {
            this.entryNumber = entryNumber;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            int nombreUtilisateur = 0;

            try
            {
                nombreUtilisateur = Int32.Parse(entryNumber.Text);
            }
            catch (Exception)
            {
                DisplayAlert("Oops", "Vous devez saisie un nombre entier", "OK");
                entryNumber.Text = "";
                return;
            }

            if (((nombreUtilisateur < NB_MIN) || (nombreUtilisateur > NB_MAX)) && (String.IsNullOrWhiteSpace(entryNumber.Text))) {
                DisplayAlert("Attention", "Vous devez rentrer un nombre entre " + NB_MIN + " et" + NB_MAX, "OK");
                entryNumber.Text = "";
                return;
            }

            if (magicNumber > nombreUtilisateur)
            {
                DisplayAlert("Perdu", "Le nombre magique est supérieur à " + nombreUtilisateur, "OK");
                return;
            }
            if (magicNumber < nombreUtilisateur)
            {
                DisplayAlert("Perdu",  "Le nombre magique est inférieur à " + nombreUtilisateur, "OK");
                return;
            }
            if (magicNumber == nombreUtilisateur)
            {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                WinAction();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                return;
            }
        }


        private async Task WinAction()
        {
            await DisplayAlert("Gagné", "Vous avez trouvé le nombre magique", "OK");
            await this.Navigation.PopAsync();
        }

    }
}

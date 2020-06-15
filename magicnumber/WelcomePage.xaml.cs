using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using magicnumber.views;
using Xamarin.Forms;

namespace magicnumber
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            InfiniteRotation(star1, 5000);
            InfiniteRotation(star1, 7000);
            InfiniteRotation(star1, 9000);
            InfiniteScale(playButton, 1000);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }

        private async Task InfiniteRotation(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await star1.RotateTo(360, length);
                star1.Rotation = 0;
            }
        }

        private async Task InfiniteScale(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.ScaleTo(1.1, length);
                await view.ScaleTo(1.0, length);
            }
        }

        void PlayButton(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }
    }
}

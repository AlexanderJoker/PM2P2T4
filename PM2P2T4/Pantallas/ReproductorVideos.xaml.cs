using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2T4.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReproductorVideos : ContentPage
    {
        public ReproductorVideos(string pathVideo)
        {
            InitializeComponent();
            UriVideoSource urivideo = new UriVideoSource()
            {
                Uri = pathVideo
            };
            videop.Source = urivideo;
        }


        private async void Cerrarvideo_Clicked(object sender, EventArgs e)
        {
            videop.Pause();
            await Navigation.PopAsync();
        }

        private void videop_PlayCompletion(object sender, EventArgs e)
        {

        }
    }

}

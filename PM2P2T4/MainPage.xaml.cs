using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PM2P2T4.Pantallas;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2P2T4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void btnAddVideo_Clicked(object sender, EventArgs e)
        {
            var AddPage = new AgregarVideo();

            await Navigation.PushAsync(AddPage);
        }

        private async void btnViewVideos_Clicked(object sender, EventArgs e)
        {
            var ViewVideosPages = new ListaVideos();

            await Navigation.PushAsync(ViewVideosPages);

        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {

        }
    }
}


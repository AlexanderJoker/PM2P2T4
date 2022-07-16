using System;
using System.Collections.Generic;
using PM2P2T4.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2T4.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVideos : ContentPage
    {
        public List<Fotos> AllVideos { get; set; }
        string pathSelectedVideo;

        public ListaVideos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            chargeListView();
        }


        private async void chargeListView()
        {
            AllVideos = await App.BaseDatos.getListVideos();
            Listasvideos.ItemsSource = AllVideos;
        }


        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem Vvideo = sender as SwipeItem;
            Fotos video = (Fotos)Vvideo.BindingContext;
            await Navigation.PushAsync(new ReproductorVideos(video.pathFile));
        }

        private void ListaVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        private void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
        {
            var selectedContact = currentSelectedContact.FirstOrDefault() as Fotos;
         
            pathSelectedVideo = selectedContact.pathFile;
            Console.WriteLine(pathSelectedVideo);
          
        }
    }
}

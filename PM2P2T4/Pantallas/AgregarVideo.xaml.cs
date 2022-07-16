using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using PM2P2T4.Models;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2T4.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarVideo : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VIDEOS.db3");
        string rutaDeVideo;

        public AgregarVideo()
        {
            InitializeComponent();
            btnvideo.Clicked += Btnvideo_Clicked;
        }
        void eliminar()
        {
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            camara.Source = null;
        }
        private async void Btnvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No hay camara", "No se detecta la camara.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "VideosGrabados",
                });

                if (file == null)
                    return;

                await DisplayAlert("Video grabado", "Ubicacion: " + file.Path, "OK");
                rutaDeVideo = file.Path;
                file.Dispose();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso denegado", "Da permisos de cámara al dispositivo.\nError: " + ex.Message, "Ok");
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteAsyncConnection(dbPath);

            var video = new Fotos
            {
                nombre = txtnombre.Text,
                descripcion = txtdescripcion.Text,
                pathFile = rutaDeVideo
            };

            var result = await App.BaseDatos.saveVideo(video);
            if (result == 1)
            {
                await DisplayAlert("Grabacion", "Video guardado correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
       
    }
    
}

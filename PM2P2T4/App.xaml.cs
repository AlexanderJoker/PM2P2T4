using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2P2T4.Pantallas;
using PM2P2T4.Controles;
using System.IO;

namespace PM2P2T4
{
    public partial class App : Application
    {
        static BaseDatos database;
        public static BaseDatos BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VIDEOS.db3"));
                }

                return database;
            }


        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

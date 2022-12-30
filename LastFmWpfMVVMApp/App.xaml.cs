using GalaSoft.MvvmLight;
using LastFmWpfMVVMApp.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LastFmWpfMVVMApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Container Services { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
            Start<HomeViewModel>();
        }
        private void RegisterServices()
        {
            Services = new Container();

            //Services.RegisterSingleton<IArtistSearchApiClient, ArtistSearchApiClient>();
            Services.RegisterSingleton<HomeViewModel>();
            Services.RegisterSingleton<DetailsViewModel>();
            Services.RegisterSingleton<MainViewModel>();

            Services.Verify();
        }

        private void Start<T>() where T : ViewModelBase
        {
            var windowViewModel = Services.GetInstance<MainViewModel>();
            windowViewModel.CurrentViewModel = Services.GetInstance<T>();
            var window = new MainWindow { DataContext = windowViewModel };
            window.ShowDialog();
        }
    }
}

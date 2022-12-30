using GalaSoft.MvvmLight;
using LastFmWpfMVVMApp.Services;
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

            Services.Register<IArtistSearchApiClient, ArtistSearchApiClient>();
            Services.Register<HomeViewModel>();
            Services.Register<DetailsViewModel>();
            Services.Register<MainViewModel>();

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

using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace LastFmWpfMVVMApp.ViewModels
{
    class MainViewModel:ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }
    }
}

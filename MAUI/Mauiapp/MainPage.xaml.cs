using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Windows.Input;

namespace Mauiapp {
    public partial class MainPage : ContentPage {
        private int _count;
        public int Count {
            get => _count;
            set => SetProperty(ref _count, value);
        }
        public ICommand IncrementCommand { get; }
        
    }
}

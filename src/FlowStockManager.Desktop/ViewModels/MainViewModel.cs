using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FlowStockManager.Desktop.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object? _currentViewModel;

        public MainViewModel()
        {
            _currentViewModel = new ProductViewModel();
        }

        [RelayCommand]
        private void AbrirProdutos() => CurrentViewModel = new ProductViewModel();
    }
}

using CommunityToolkit.Mvvm.ComponentModel;

namespace FlowStockManager.Desktop.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        [ObservableProperty] 
        private string titulo = "Produtos";
    }
}

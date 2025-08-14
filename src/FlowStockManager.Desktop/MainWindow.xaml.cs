using CommunityToolkit.Mvvm.Input;
using FlowStockManager.Desktop.Models;
using System.Windows;

namespace FlowStockManager.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowModel();
        }

        [RelayCommand]
        private void AbrirInicio()
        {
            // Trocar o conteúdo principal
        }

        [RelayCommand]
        private void AbrirProdutos()
        {
            // Trocar para tela de produtos
        }

        [RelayCommand]
        private void AbrirConfiguracoes()
        {
            // Trocar para tela de configurações
        }
    }
}
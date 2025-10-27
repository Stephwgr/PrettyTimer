using Avalonia.Controls;
using PrettyTimer.ViewModels; //créer dans le script MainViewModel avce le NameSpace

namespace PrettyTimer;

public partial class MainWindow : Window
{
    private readonly MainViewModel _vm;

    public MainWindow()
    {
        InitializeComponent();

        _vm = new MainViewModel();
        DataContext = _vm; // c'est ici qu'on relie la vue ViewModel

    }

    private void Start_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _vm.Start();
    }

    private void Pause_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _vm.Pause();
    }

    private void Reset_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _vm.Reset();
    }

}
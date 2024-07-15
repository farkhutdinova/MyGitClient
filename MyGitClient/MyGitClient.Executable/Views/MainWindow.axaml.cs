using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MyGitClient.Executable.ViewModels;
using ReactiveUI;

namespace MyGitClient.Executable.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}
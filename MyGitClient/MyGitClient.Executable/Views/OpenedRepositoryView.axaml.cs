using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MyGitClient.Executable.ViewModels;
using ReactiveUI;

namespace MyGitClient.Executable.Views;

public partial class OpenedRepositoryView : ReactiveUserControl<OpenedRepositoryViewModel>
{
    public OpenedRepositoryView()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}
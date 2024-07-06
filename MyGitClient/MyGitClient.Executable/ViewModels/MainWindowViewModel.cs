using System.Reactive;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        OpenNewRepoCommand = ReactiveCommand.Create(OpenNewRepo);
    }

    public ReactiveCommand<Unit, Unit> OpenNewRepoCommand { get; }

    private void OpenNewRepo()
    {
        // TODO open folder explorer
    }
}
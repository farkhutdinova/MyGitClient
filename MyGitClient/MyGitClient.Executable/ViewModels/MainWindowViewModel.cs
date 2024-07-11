using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private string? _selectedFolder;

    public MainWindowViewModel()
    {
        OpenNewRepoCommand = ReactiveCommand.CreateFromTask(SelectFolderAsync);
    }

    public Interaction<string, string?> SelectFilesInteraction { get; } = new();

    private async Task SelectFolderAsync()
    {
        _selectedFolder = await SelectFilesInteraction.Handle("Hello from Avalonia");
    }

    public ReactiveCommand<Unit, Unit> OpenNewRepoCommand { get; }
}
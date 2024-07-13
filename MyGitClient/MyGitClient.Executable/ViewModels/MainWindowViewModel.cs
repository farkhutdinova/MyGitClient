using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        BrowseRepoCommand = ReactiveCommand.CreateFromTask(SelectFolderAsync);
    }

    public string SelectedFolderPath { get; private set; } = string.Empty;

    public Interaction<string, string> SelectFolder { get; } = new();

    private async Task SelectFolderAsync()
    {
        SelectedFolderPath = await SelectFolder.Handle("Select a repository to open");
    }

    public ReactiveCommand<Unit, Unit> BrowseRepoCommand { get; }

    public ObservableCollection<string> PreviouslyOpenedRepositories { get; set; }
}
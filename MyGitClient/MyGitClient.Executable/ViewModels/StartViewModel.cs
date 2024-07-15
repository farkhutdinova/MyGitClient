using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MyGitClient.Executable.Views;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public class StartViewModel : ReactiveObject, IRoutableViewModel
{
    public StartViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        PreviouslyOpenedRepositories = new ObservableCollection<string>();
        BrowseRepoCommand = ReactiveCommand.CreateFromTask(SelectFolderAsync);
    }

    public string? UrlPathSegment => "start";

    public IScreen HostScreen { get; }
    
    public string SelectedFolderPath { get; private set; } = string.Empty;
    
    public Interaction<string, string> SelectFolder { get; } = new();
    
    private async Task SelectFolderAsync()
    {
        SelectedFolderPath = await SelectFolder.Handle("Select a repository to open");
        PreviouslyOpenedRepositories.Add(SelectedFolderPath);
    }
    
    public ReactiveCommand<Unit, Unit> BrowseRepoCommand { get; }
    
    public ObservableCollection<string> PreviouslyOpenedRepositories { get; set; }
}
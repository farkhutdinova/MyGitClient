using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IStartViewModelFactory
{
    StartViewModel Create(IScreen hostScreen);
}

public sealed class StartViewModelFactory(IOpenedRepositoryViewModelFactory openedRepositoryViewModelFactory) : IStartViewModelFactory
{
    public StartViewModel Create(IScreen hostScreen)
    {
        return new StartViewModel(hostScreen, openedRepositoryViewModelFactory);
    }
}

public sealed class StartViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly IOpenedRepositoryViewModelFactory _openedRepositoryViewModelFactory;

    public StartViewModel(IScreen hostScreen, IOpenedRepositoryViewModelFactory openedRepositoryViewModelFactory)
    {
        HostScreen = hostScreen;
        _openedRepositoryViewModelFactory = openedRepositoryViewModelFactory;
        OpenedHistory = RxApp.SuspensionHost.GetAppState<OpenedHistoryViewModel>();
        BrowseRepoCommand = ReactiveCommand.CreateFromTask(SelectFolderAsync);
        OpenRepoCommand = ReactiveCommand.CreateFromTask<string>(OpenSelectedRepo);
    }

    public string UrlPathSegment => "start";

    public IScreen HostScreen { get; }

    public string SelectedFolderPath { get; private set; } = string.Empty;

    public Interaction<string, string> SelectFolder { get; } = new();

    public ReactiveCommand<Unit, Unit> BrowseRepoCommand { get; }

    public ReactiveCommand<string, Unit> OpenRepoCommand { get; }

    public OpenedHistoryViewModel OpenedHistory{ get; }

    private async Task OpenSelectedRepo(string d)
    {
        await HostScreen.Router.Navigate.Execute(_openedRepositoryViewModelFactory.Create(HostScreen, d));
    }

    private async Task SelectFolderAsync()
    {
        SelectedFolderPath = await SelectFolder.Handle("Select a repository to open");
        OpenedHistory.AddNew(SelectedFolderPath);
        await HostScreen.Router.Navigate.Execute(_openedRepositoryViewModelFactory.Create(HostScreen, SelectedFolderPath));
    }
}
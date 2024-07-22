using MyGitClient.GitCommands;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IOpenedRepositoryViewModelFactory
{
    OpenedRepositoryViewModel Create(IScreen hostScreen, string repoPath);
}

public sealed class OpenedRepositoryViewModelFactory(IRepositoryStatusProvider repositoryStatusProvider) : IOpenedRepositoryViewModelFactory
{
    public OpenedRepositoryViewModel Create(IScreen hostScreen, string repoPath)
    {
        return new OpenedRepositoryViewModel(hostScreen, repoPath, repositoryStatusProvider);
    }
}

public sealed class OpenedRepositoryViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly string _selectedFolderPath;
    private readonly IRepositoryStatusProvider _repositoryStatusProvider;

    public OpenedRepositoryViewModel(IScreen hostScreen, string selectedFolderPath, IRepositoryStatusProvider repositoryStatusProvider)
    {
        _selectedFolderPath = selectedFolderPath;
        _repositoryStatusProvider = repositoryStatusProvider;
        HostScreen = hostScreen;
        Status = GetStatus();
    }

    public string UrlPathSegment => "opened-repository";

    public IScreen HostScreen { get; }

    public string Status { get; }

    private string GetStatus() => _repositoryStatusProvider.GetStatus(_selectedFolderPath);
}
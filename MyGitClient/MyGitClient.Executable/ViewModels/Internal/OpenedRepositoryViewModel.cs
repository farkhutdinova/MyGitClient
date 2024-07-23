using MyGitClient.GitCommands;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels.Internal;

internal sealed class OpenedRepositoryViewModel(
    IScreen hostScreen,
    string selectedFolderPath,
    IRepositoryStatusProvider repositoryStatusProvider) : ViewModelBase, IOpenedRepositoryViewModel
{
    public string UrlPathSegment => "opened-repository";

    public IScreen HostScreen { get; } = hostScreen;

    public RepositoryStatus Status => repositoryStatusProvider.GetStatus(selectedFolderPath);
}
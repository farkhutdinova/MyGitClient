using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IOpenedRepositoryViewModelFactory
{
    IOpenedRepositoryViewModel Create(IScreen hostScreen, string repoPath);
}
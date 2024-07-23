using MyGitClient.GitCommands;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IOpenedRepositoryViewModel : IRoutableViewModel
{
    RepositoryStatus Status { get; }
}
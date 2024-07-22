using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IOpenedRepositoryViewModel : IRoutableViewModel
{
    string Status { get; }
}
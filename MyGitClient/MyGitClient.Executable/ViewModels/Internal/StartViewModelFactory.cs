using ReactiveUI;

namespace MyGitClient.Executable.ViewModels.Internal;

internal sealed class StartViewModelFactory(IOpenedRepositoryViewModelFactory openedRepositoryViewModelFactory) : IStartViewModelFactory
{
    public IStartViewModel Create(IScreen hostScreen)
    {
        return new StartViewModel(hostScreen, openedRepositoryViewModelFactory);
    }
}
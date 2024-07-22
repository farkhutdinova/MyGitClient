using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IStartViewModelFactory
{
    IStartViewModel Create(IScreen hostScreen);
}
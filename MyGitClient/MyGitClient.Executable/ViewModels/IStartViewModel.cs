using System.Reactive;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IStartViewModel : IRoutableViewModel
{
    OpenedHistoryViewModel OpenedHistory { get; }

    Interaction<string, string> SelectFolder { get; }

    ReactiveCommand<Unit, Unit> BrowseRepoCommand { get; }

    ReactiveCommand<string, Unit> OpenRepoCommand { get; }
}
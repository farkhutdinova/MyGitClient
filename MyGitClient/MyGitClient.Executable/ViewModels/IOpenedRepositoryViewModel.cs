using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public interface IOpenedRepositoryViewModel : IRoutableViewModel
{
    string BranchName { get; }

    IEnumerable<IModifiedRepoFileViewModel> ModifiedFiles { get; }

    IEnumerable<IModifiedRepoFileViewModel> StagedFiles { get; }

    ReactiveCommand<Unit, Unit> CommitCommand { get; }
}
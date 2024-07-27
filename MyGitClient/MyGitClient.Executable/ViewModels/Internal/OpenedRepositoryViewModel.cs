using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using MyGitClient.GitCommands;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels.Internal;

internal sealed class OpenedRepositoryViewModel : ViewModelBase, IOpenedRepositoryViewModel
{
    private readonly string _selectedFolderPath;
    private readonly ICommitCommand _commitCommand;
    private readonly RepositoryStatus _status;

    public OpenedRepositoryViewModel(
        IScreen hostScreen,
        string selectedFolderPath,
        IRepositoryStatusProvider repositoryStatusProvider,
        ICommitCommand commitCommand)
    {
        _selectedFolderPath = selectedFolderPath;
        _commitCommand = commitCommand;
        _status = repositoryStatusProvider.GetStatus(selectedFolderPath);
        HostScreen = hostScreen;
        CommitCommand = ReactiveCommand.Create(CommitChanges, CanCommitChanges);
    }

    public string UrlPathSegment => "opened-repository";

    public IScreen HostScreen { get; }

    public string BranchName => _status.BranchName;

    public IEnumerable<IModifiedRepoFileViewModel> ModifiedFiles =>
        _status.ModifiedFiles
            .Where(x => !x.IsStaged)
            .Select(x => new ModifiedRepoFileViewModel(x));

    public IEnumerable<IModifiedRepoFileViewModel> StagedFiles =>
        _status.ModifiedFiles
            .Where(x => x.IsStaged)
            .Select(x => new ModifiedRepoFileViewModel(x));

    public ReactiveCommand<Unit, Unit> CommitCommand { get; }

    private IObservable<bool> CanCommitChanges => Observable.Return(_status.ModifiedFiles.Any(x => !x.IsStaged));

    private void CommitChanges() => _commitCommand.Execute(_selectedFolderPath);
}
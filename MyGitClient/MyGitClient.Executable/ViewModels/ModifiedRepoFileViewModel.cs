using MyGitClient.GitCommands;

namespace MyGitClient.Executable.ViewModels;

internal sealed class ModifiedRepoFileViewModel(ModifiedRepoFile modifiedRepoFile) : ViewModelBase, IModifiedRepoFileViewModel
{
    public State State => modifiedRepoFile.IsStaged ? State.Staged : State.Modified;

    public string Name => modifiedRepoFile.Path;

    public string Path => modifiedRepoFile.Path;
}

public interface IModifiedRepoFileViewModel
{
    State State { get; }

    string Name { get; }

    string Path { get; }
}

public enum State
{
    Modified,
    Staged
}
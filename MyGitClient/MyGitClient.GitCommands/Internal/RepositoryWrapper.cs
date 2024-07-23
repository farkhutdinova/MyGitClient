using LibGit2Sharp;

namespace MyGitClient.GitCommands.Internal;

internal sealed class RepositoryWrapper(string repoPath) : IRepositoryWrapper
{
    private readonly Repository _repository = new(repoPath);

    public RepositoryStatus RetrieveStatus()
    {
        var status = _repository.RetrieveStatus();
        var modifiedFiles = status.Modified.Select(x => new RepoFile(x.FilePath, x.State == FileStatus.ModifiedInIndex));
        return new RepositoryStatus(status.IsDirty, _repository.Head.FriendlyName, modifiedFiles);
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}
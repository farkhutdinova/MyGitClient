using LibGit2Sharp;

namespace MyGitClient.GitCommands.Internal;

internal sealed class RepositoryWrapper(string repoPath) : IRepositoryWrapper
{
    private readonly Repository _repository = new(repoPath);

    public RepositoryStatus RetrieveStatus()
    {
        var status = _repository.RetrieveStatus();
        var staged = status.Staged.ToList();
        var stagedFiles = staged.Select(x => new ModifiedRepoFile(x.FilePath, true));
        var unstagedFiles = status.Modified.Where(x => !staged.Contains(x)).Select(x => new ModifiedRepoFile(x.FilePath, false));
        return new RepositoryStatus(status.IsDirty, _repository.Head.FriendlyName, stagedFiles.Concat(unstagedFiles));
    }

    public void Commit()
    {
        _repository.Commit("this is a hardcoded message >.<", new Signature("username", "email", DateTimeOffset.Now),
            new Signature("username", "email", DateTimeOffset.Now));
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}
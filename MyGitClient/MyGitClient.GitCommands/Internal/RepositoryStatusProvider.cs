namespace MyGitClient.GitCommands.Internal;

internal sealed class RepositoryStatusProvider(IRepositoryFactory repositoryFactory) : IRepositoryStatusProvider
{
    public RepositoryStatus GetStatus(string repoPath)
    {
        using var repo = repositoryFactory.Create(repoPath);
        var status = repo.RetrieveStatus();
        return status;
    }
}
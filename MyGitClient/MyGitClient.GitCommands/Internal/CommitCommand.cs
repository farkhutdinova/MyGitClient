namespace MyGitClient.GitCommands.Internal;

internal sealed class CommitCommand(IRepositoryFactory repositoryFactory) : ICommitCommand
{
    public void Execute(string repoPath)
    {
        using var repo = repositoryFactory.Create(repoPath);
        repo.Commit();
    }
}
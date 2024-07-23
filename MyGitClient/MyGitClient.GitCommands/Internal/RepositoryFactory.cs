namespace MyGitClient.GitCommands.Internal;

internal sealed class RepositoryFactory : IRepositoryFactory
{
    public IRepositoryWrapper Create(string repoPath) => new RepositoryWrapper(repoPath);
}

internal interface IRepositoryFactory
{
    IRepositoryWrapper Create(string repoPath);
}
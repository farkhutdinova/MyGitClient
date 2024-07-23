namespace MyGitClient.GitCommands;

public interface IRepositoryStatusProvider
{
    RepositoryStatus GetStatus(string repoPath);
}
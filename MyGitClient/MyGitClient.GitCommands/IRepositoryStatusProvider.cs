namespace MyGitClient.GitCommands;

public interface IRepositoryStatusProvider
{
    string GetStatus(string repoPath);
}
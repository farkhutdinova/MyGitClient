namespace MyGitClient.GitCommands;

public interface IRepositoryWrapper : IDisposable
{
    RepositoryStatus RetrieveStatus();

    void Commit();
}
namespace MyGitClient.GitCommands;

public interface ICommitCommand
{
    void Execute(string repoPath);
}
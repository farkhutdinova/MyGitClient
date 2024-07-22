using System.Text;
using LibGit2Sharp;

namespace MyGitClient.GitCommands;

public interface IRepositoryStatusProvider
{
    string GetStatus(string repoPath);
}

internal sealed class RepositoryStatusProvider : IRepositoryStatusProvider
{
    public string GetStatus(string repoPath)
    {
        var statusStringBuilder = new StringBuilder();
        using var repo = new Repository(repoPath);
        var status = repo.RetrieveStatus();
        var isDirty = status.IsDirty;
        statusStringBuilder.Append($"On branch {repo.Head.FriendlyName}");
        statusStringBuilder.AppendLine();
        statusStringBuilder.Append(isDirty ? "There are some changes" : "No changes");
        return statusStringBuilder.ToString();
    }
}
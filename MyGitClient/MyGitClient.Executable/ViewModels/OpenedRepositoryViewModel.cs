using System.Text;
using LibGit2Sharp;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public sealed class OpenedRepositoryViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly string _selectedFolderPath;

    public OpenedRepositoryViewModel(IScreen hostScreen, string selectedFolderPath)
    {
        _selectedFolderPath = selectedFolderPath;
        HostScreen = hostScreen;
        Status = GetStatus();
    }

    public string UrlPathSegment => "opened-repository";

    public IScreen HostScreen { get; }

    public string Status { get; }

    private string GetStatus()
    {
        // TODO @evgn move to separate assembly
        var statusStringBuilder = new StringBuilder();
        using var repo = new Repository(_selectedFolderPath);
        var status = repo.RetrieveStatus();
        var isDirty = status.IsDirty;
        statusStringBuilder.Append($"On branch {repo.Head.FriendlyName}");
        statusStringBuilder.AppendLine();
        statusStringBuilder.Append(isDirty ? "There are some changes" : "No changes");
        return statusStringBuilder.ToString();
    }
}
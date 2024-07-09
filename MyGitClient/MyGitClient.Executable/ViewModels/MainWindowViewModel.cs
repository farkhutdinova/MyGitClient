using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IStorageProvider _storageProvider;

    public MainWindowViewModel(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
        OpenNewRepoCommand = ReactiveCommand.CreateFromTask(OpenNewRepoTask);
    }

    private async Task OpenNewRepoTask()
    {
        var storageFiles = await _storageProvider.OpenFolderPickerAsync(
            new FolderPickerOpenOptions
            {
                Title = "Select folder to open as a repository"
            });

        var folder = storageFiles.Count == 0 ? null : storageFiles[0].Path.LocalPath;
    }

    public ReactiveCommand<Unit, Unit> OpenNewRepoCommand { get; }
}
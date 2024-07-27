using Avalonia.Headless.XUnit;
using MyGitClient.Executable.ViewModels;
using MyGitClient.Executable.ViewModels.Internal;
using MyGitClient.Executable.Views;
using MyGitClient.GitCommands;
using NSubstitute;
using ReactiveUI;

namespace MyGitClient.Tests;

public sealed class MainViewTests
{
    [AvaloniaFact]
    public void CanBrowseRepo()
    {
        var vm = new MainWindowViewModel(Substitute.For<IStartViewModelFactory>());

        var window = new MainWindow
        {
            DataContext = vm
        };

        window.Show();

        Assert.NotNull(vm.Router.CurrentViewModel);
    }

    [AvaloniaFact]
    public void CanSelectFolder()
    {
        var vm = new StartViewModel(Substitute.For<IScreen>(), Substitute.For<IOpenedRepositoryViewModelFactory>());
        vm.SelectFolder.RegisterHandler(interaction => interaction.SetOutput("MyPath"));

        vm.BrowseRepoCommand.Execute();

        Assert.Equal("MyPath", vm.SelectedFolderPath);
    }

    [AvaloniaFact]
    public void SelectedRepoDisplaysBranchName()
    {
        var repoStatus = new RepositoryStatus(false, "MyBranch", new List<ModifiedRepoFile>());
        var repoStatusProvider = Substitute.For<IRepositoryStatusProvider>();
        repoStatusProvider.GetStatus("MyPath").Returns(repoStatus);

        var vm = new OpenedRepositoryViewModel(Substitute.For<IScreen>(), "MyPath", repoStatusProvider, Substitute.For<ICommitCommand>());

        Assert.Equal("MyBranch", vm.BranchName);
    }

    [AvaloniaFact]
    public void CanStageWhenRepoHasUnstagedModifiedFile()
    {
        var repoFile = new ModifiedRepoFile("FilePath", false);
        var repoStatus = new RepositoryStatus(true, "MyBranch", new List<ModifiedRepoFile> {repoFile});
        var repoStatusProvider = Substitute.For<IRepositoryStatusProvider>();
        repoStatusProvider.GetStatus("MyPath").Returns(repoStatus);

        var vm = new OpenedRepositoryViewModel(Substitute.For<IScreen>(), "MyPath", repoStatusProvider, Substitute.For<ICommitCommand>());

        // Assert.True(vm.StageCommand.Subscribe());
    }
}
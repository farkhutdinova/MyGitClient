using Avalonia.Headless.XUnit;
using MyGitClient.Executable.ViewModels;
using MyGitClient.Executable.ViewModels.Internal;
using MyGitClient.Executable.Views;
using NSubstitute;
using ReactiveUI;

namespace MyGitClient.Tests;

public class MainViewTests
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
    public void SelectedRepoDisplaysItsStatus()
    {
        // TODO @evgn check that once a repo is selected, the status is displayed
    }
}